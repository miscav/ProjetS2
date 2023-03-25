using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsData : ScriptableObject
{
    [SerializeField] protected string Name;
    [SerializeField] public Sprite Visual;
    [SerializeField] protected GameObject Prefab;
    [SerializeField] protected ItemType itemType;

    public enum ItemType
    {
        Weapon,
        Food,
        Piece,
        Tool
    }
}
