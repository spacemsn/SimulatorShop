using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShelfInventory : MonoBehaviour
{
    [Header(" олличество €чеек на полке")]
    public int cellAmount;

    [Header("List €чеек на полке")]
    public List<GameObject> cells = new List<GameObject>();

    [Header("ћассив €чеек на полке")]
    public GameObject[] _cells;

    [SerializeField] float maxDistance = 4f;
    [SerializeField] Camera mainCamera;

    Ray ray;
    RaycastHit hit;

    public Image E;

    public BoxInventory inventory;

    private void Start()
    {
        cellAmount = transform.childCount;

        _cells = new GameObject[cellAmount];

        for(int i = 0; i < transform.childCount; i++)
        {
            cells.Add(transform.GetChild(i).gameObject);
        }

        for(int i = 0; i < cells.Count; i++)
        {
            _cells[i] = transform.GetChild(i).gameObject;
        }
    }

    public void Ray()
    {
        ray = mainCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    private void Update()
    {
        Ray();

        if(Physics.Raycast(ray, out hit, maxDistance))
        {
            if(hit.collider.gameObject.GetComponent<ShelfInventory>() != null)
            {
                Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.black);
                if(Input.GetKeyDown(KeyCode.F))
                {
                    for(int i = 0; i < _cells.Length; i++)
                    {
                        //inventory._products[i].gameObject.transform.position = _cells[i].transform.position;
                        Debug.Log("Ёлемент массива коробки" + i + " = " + _cells[i].name);
                    }
                }
            }
        }
    }
}
