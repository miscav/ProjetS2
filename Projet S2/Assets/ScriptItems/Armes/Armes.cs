using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items/Armes")]
public class Armes : ItemsData
{
    public int Degat;
    public int Portee;
    public int Duramax;
    protected ItemType itemtype = ItemType.Armes;

    /*public void reparer()
    {
        Durabilite = Duramax;
    }

    public void use()
    {
    }*/
}