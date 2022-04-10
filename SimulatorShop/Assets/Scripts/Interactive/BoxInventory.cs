using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInventory : MonoBehaviour
{
    [Header("Prefab ������")]
    public GameObject product;

    [Header("����������� ������")]
    [SerializeField] string productName;

    [Header("����������� ������ � �������")]
    public int prodAmount;

    [Header("List ������ � �������")]
    public List<GameObject> products = new List<GameObject>();

    [Header("������ ������ � �������")]
    public GameObject[] _products;

    private void Start()
    {
        productName = product.name;
        prodAmount = transform.childCount;

        _products = new GameObject[prodAmount];

        for (int i = 0; i < transform.childCount; i++)
        {
            products.Add(transform.GetChild(i).gameObject);
            

        }

        for(int i = 0; i < transform.childCount; i++)
        {
            _products[i] = transform.GetChild(i).gameObject;
        }
    }
}
