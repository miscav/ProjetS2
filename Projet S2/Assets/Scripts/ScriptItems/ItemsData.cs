using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsData : ScriptableObject
{
    [SerializeField] public string Name;
    [SerializeField] public Sprite Visual;
    [SerializeField] public GameObject Prefab;
    [SerializeField] public ItemType itemType;

    public enum ItemType
    {
        Weapon,
        Food,
        Piece,
        Tool
    }
}
