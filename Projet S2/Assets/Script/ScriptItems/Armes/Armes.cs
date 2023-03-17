public class Armes : Items
{
    public int Degat;
    public int Portee;
    public int Duramax;

    public void reparer()
    {
        Durabilite = Duramax;
    }

    public void use()
    {
    }
}