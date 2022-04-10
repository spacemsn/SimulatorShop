using UnityEngine;
using UnityEngine.UI;

public class moveObject : MonoBehaviour
{
    Ray _ray;
    RaycastHit _hit;

    Rigidbody _rb;
    controllPlayer _cp;

    [Header("Игрок")]
    public GameObject _player;
    private float distance;
    public float interactDistance = 4f;

    [Header("Камера")]
    public Camera playerCamera;
    
    [Header("Рука")]
    public Transform arm;

    [Header("Клавиша взаимодействия")]
    public KeyCode takeObj = KeyCode.E;
    public KeyCode removeObj = KeyCode.Mouse1;

    [Header("Индикатор (Показывает клавишу)")]
    public Image _image;

    private void OnMouseOver()
    {
        distance = Vector3.Distance(_player.GetComponent<Transform>().position, transform.position);
        if(distance < interactDistance && _cp.Take == false)
        {
            _image.enabled = true;
            if(Input.GetKeyDown(takeObj))
            { 
                transform.position = arm.position;
                transform.rotation = arm.rotation;
                transform.SetParent(arm);
                _rb.isKinematic = true;
                _cp.Take = true;
            }
        }

        if(distance > interactDistance)
        {
            _image.enabled = false;
        }
    }

    private void OnMouseExit()
    {
        _image.enabled = false;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _cp = GameObject.Find("Player").GetComponent<controllPlayer>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(removeObj))
        {
            transform.parent = null;
            _rb.isKinematic = false;
            _cp.Take = false;
        }
    }

    public void putShelf()
    {

    }
}
