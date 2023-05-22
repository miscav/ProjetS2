using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionTrigger : MonoBehaviour
{
    [SerializeField] private GameObject PickUpPanel;
    [SerializeField] private GameObject ShopPanel;
    [SerializeField] private GameObject Item;
    [SerializeField] private Inventory inventory;
    private Shop Shopping;

    private void Start()
    {
        PickUpPanel.SetActive(false);
        Item = null;
    }

    private void Update()
    {
        if (Item != null && Input.GetKeyDown(KeyCode.E))
        {
            inventory.Add(Item.transform.gameObject.GetComponent<Items>().dataItem);
            Destroy(Item.transform.gameObject);
            PickUpPanel.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.E) && Shopping != null) 
        {
            ShopPanel.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            PickUpPanel.GetComponentInChildren<Text>().text = "Pick Up";
            Item = other.gameObject;
            PickUpPanel.SetActive(true);
        }

        if (other.CompareTag("Shop"))
        {
            PickUpPanel.GetComponentInChildren<Text>().text = "Shopping";
            PickUpPanel.SetActive(true);
            Shopping = other.GetComponent<Shop>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Item = null;
            PickUpPanel.SetActive(false);
        }

        if (other.CompareTag("Shop"))
        {
            PickUpPanel.SetActive(false);
        }
    }
}
