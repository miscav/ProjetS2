
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items/new Item")]

public class ItemsData : ScriptableObject
{
    [SerializeField] public Sprite Visual;
    [SerializeField] public GameObject Prefab;
    public int Poids;
    public int Durabilite;
    [SerializeField] public string Name;

    public void detruire(Player player)
    {
        int i = 0;
        foreach (Items items in player.Bag)
        {
            if (items == this)
            {
                player.Bag.RemoveAt(i);
                break;
            }
            i++;
        }
    }

    public void isbroken(Player player)
    {
        if (Durabilite <= 0)
            detruire(player);
    }

    /*public void Use(Player player)
    {
        Durabilite -= 1;
        isbroken(player);
    }
    */
}