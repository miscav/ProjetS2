using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTrigger : MonoBehaviour
{
    [SerializeField] public GameObject PickUpPanel;
    [SerializeField] private GameObject Item;
    [SerializeField] private Inventory inventory;

    private void Start()
    {
        PickUpPanel.SetActive(false);
        Item = null;
    }

    private void Update()
    {
        if (Item != null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("aaa");
            inventory.Add(Item.transform.gameObject.GetComponent<Items>().dataItem);
            Destroy(Item.transform.gameObject);
            PickUpPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log("aa");
            Item = other.gameObject;
            PickUpPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Item = null;
            PickUpPanel.SetActive(false);
        }
    }
}
