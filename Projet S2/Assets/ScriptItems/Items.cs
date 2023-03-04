using UnityEngine;

public class Items : MonoBehaviour
{
    public int Poids;
    public int Durabilite;
    public string Name;

    public void detruire()
    {
    }

    public void isbroken()
    {
        if (Durabilite <= 0)
            detruire();
    }
}