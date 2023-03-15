using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items/Food")]

public class Food : ItemsData
{
    public int Miam;
    public int Bouchees;
    protected ItemType itemtype = ItemType.Food;
}