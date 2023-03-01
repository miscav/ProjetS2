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

    void Start()
    {
        nbrfleche= -1;
        isloaded = false;
        Poids = -1;
        Portee = -1;
        Duramax = -1;
        Durabilite = Duramax;
        Degat = -1;
    }
}