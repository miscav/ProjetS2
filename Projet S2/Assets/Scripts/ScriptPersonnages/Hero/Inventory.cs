using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemsData> Content;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject SlotContent;
    [SerializeField] private GameObject ActionItemPanel;
    [SerializeField] private GameObject UseButton;
    [SerializeField] private GameObject DropButton;
    [SerializeField] private GameObject EquipButton;
    [SerializeField] private GameObject RepairButton;
    [SerializeField] private GameObject DestroyButton;

    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Content = new List<ItemsData>();
        CloseInventory();
        CloseActionItemPanel();
        QueteManagement.inventory = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            Refresh();
        }
    }

    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
        CloseActionItemPanel();
    }

    public void Add(ItemsData item)
    {
        if(item != null)
        {
            Content.Add(item);
            Refresh();
        }
    }

    public bool Search(ItemsData item)
    {
        return item == null || Content.Contains(item);
    }

    public void Remove(ItemsData item) 
    {
        if(Search(item))
        {
            Content.Remove(item);
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < Content.Count; i++)
        {
            Slot slot = SlotContent.transform.GetChild(i).GetComponent<Slot>();
            slot.Item = Content[i];
            slot.Visual.sprite = Content[i].Visual;
        }
    }

    public void OpenActionItemPanel(ItemsData item)
    {
        // use drop equip repair destroy
        switch (item.itemType)
        {
            case ItemsData.ItemType.Weapon:
                UseButton.SetActive(false);
                EquipButton.SetActive(true);
                DropButton.SetActive(true);
                RepairButton.SetActive(true);
                DestroyButton.SetActive(true);
                break;

            case ItemsData.ItemType.Tool:
                UseButton.SetActive(false);
                EquipButton.SetActive(true);
                DropButton.SetActive(true);
                RepairButton.SetActive(true);
                DestroyButton.SetActive(true);
                break;

            case ItemsData.ItemType.Food:
                UseButton.SetActive(true);
                EquipButton.SetActive(false);
                DropButton.SetActive(true);
                RepairButton.SetActive(false);
                DestroyButton.SetActive(false);
                break;

            case ItemsData.ItemType.Piece:
                UseButton.SetActive(false);
                EquipButton.SetActive(false);
                DropButton.SetActive(true);
                RepairButton.SetActive(false);
                DestroyButton.SetActive(false);
                break;
        }

        ActionItemPanel.SetActive(true);
    }

    public void CloseActionItemPanel()
    {
        ActionItemPanel.SetActive(false);
    }
}
