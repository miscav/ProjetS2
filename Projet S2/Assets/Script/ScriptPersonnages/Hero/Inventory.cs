using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemsData> Content;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject ActionItemPanel;

    public static Inventory instance;

    private void Awake()
    {
        instance= this;
    }

    void Start()
    {
        Content = new List<ItemsData>();
        CloseInventory();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            Refresh();
        }
    }

    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
    }

    public void Add(ItemsData item)
    {
        Content.Add(item);
        Refresh();
    }

    public void Refresh()
    {
        for(int i = 0; i < Content.Count; i++)
        {
            inventoryPanel.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<Image>().sprite = Content[i].Visual;
        }
    }



    public void CloseActionItemPanel()
    {
        ActionItemPanel.SetActive(false);
    }
}
