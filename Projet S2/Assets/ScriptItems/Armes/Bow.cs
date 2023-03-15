public class Bow : Armes
{
    public bool isloaded;
    private int nbrfleche;

    public void load()
    {
    }

    public void unload()
    {
    }

    public Bow()
    {
        isloaded = false;
        Poids = 2;
        Portee = 10;
        Duramax = 100;
        Durabilite = Duramax;
        Degat = 10;
    }

    void Start()
    {
        isloaded = false;
        Poids = 2;
        Portee = 10;
        Duramax = 100;
        Durabilite = Duramax;
        Degat = 10;
    }
}