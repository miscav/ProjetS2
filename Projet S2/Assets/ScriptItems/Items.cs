using UnityEngine;

public class Items : ScriptableObject
{
    public int Poids;
    public int Durabilite;
    public string Name;

    public void detruire(Player player)
    {
        int i = 0;
        foreach(Items items in player.Bag)
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

    public void Use(Player player)
    {
        Durabilite -= 1;
        isbroken(player);
    }
}