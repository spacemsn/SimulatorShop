using UnityEngine;
using UnityEngine.UI;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    public Image _image;
    private Ray _ray;
    private RaycastHit _hit;

    public bool See;

    [SerializeField] private float _maxDistanceRay;

    InventoryMeneger _inventoryMeneger;

    private void Ray()
    {
        _ray = _camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

    }

    private void DrawRay()
    {
        if (Physics.Raycast(_ray, out _hit, _maxDistanceRay))
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.blue);
        }

        if(_hit.transform == null)
        {
            _image.enabled = false;
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.red);
        }
    }

    private void Interact()
    {
        if(_hit.transform != null && _hit.transform.GetComponent<openDoor>())
        {
            _image.enabled = true;
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green);
            if(Input.GetKeyDown(KeyCode.E))
            {
                _hit.transform.GetComponent<openDoor>().Open();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _inventoryMeneger = GetComponent<InventoryMeneger>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray();
        DrawRay();
        Interact();
    }
}
