using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMeneger : MonoBehaviour
{
    public GameObject UIPanel;
    public Transform inventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    bool isOpened;
    public float reachDistance = 4f;

    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < inventoryPanel.childCount; i++)
        {
            if(inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        UIPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            isOpened = !isOpened;
            if(isOpened)
            {
                UIPanel.SetActive(true);
            }
            else
            {
                UIPanel.SetActive(false);
            }
        }

        Ray ray = mainCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, reachDistance))
        {
            if(hit.collider.gameObject.GetComponent<Item>() != null)
            {
                Debug.DrawRay(ray.origin, ray.direction * reachDistance, Color.black);
                AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
                Destroy(hit.collider.gameObject);
            }
        }
    }

    public void AddItem(ItemUIobject _item, int _amount)
    {
        foreach(InventorySlot slot in slots)
        {
            if(slot.item == _item)
            {
                slot.amount += _amount;
                return;
            }
        }
        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty == true)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                break;
            }
        }
    }
}
