using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ItemsData Item;
    public Image Visual;
    [SerializeField] private GameObject Player;

    public void OnClickSlot()
    {
        Inventory.instance.OpenActionItemPanel(Item);
    }

    public void Use()
    {
        Player.GetComponent<Player>().Eat(Item); 
    }
}
