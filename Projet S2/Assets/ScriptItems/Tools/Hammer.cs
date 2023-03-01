public class Hammer : Items
{
    public int Efficacite;
    public int Portee;
    public int Duramax;

    public Hammer()
    {
        Efficacite = -1;
        Portee = -1;
        Poids = -1;
        Duramax = -1;
        Durabilite= -1;
    }

    public void reparer()
    {
        Durabilite = Duramax;
    }
}