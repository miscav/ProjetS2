using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Quetevolcan : ScriptableObject
{

    [SerializeField] public Queue<Quetes> quete;
    [SerializeField] public int pnj;
    [SerializeField] public static Quetes QuetesActuelle;
    [SerializeField] public static Player player;
    [SerializeField] public static Inventory inventory;
    [SerializeField] public Transform transform;
    private void Start()
    {
        QuetesActuelle = null;
        quete = QuetePNJ.AllQuetes[pnj];
    }

    public void Reussi()
    {
        Quetes succeed = quete.Dequeue();
        QuetesActuelle = null;
        player.AddBalance(succeed.RewardMoney);
        inventory.Add(succeed.RewardItem);
    }
    /*public void QuetePerdue()
    {
        if (player.transform.position == "Le truc qui a le tag volcan trou"")
        {
            Abandon();
            player.transform.position == point de départ de la quête ou fin du jeu
        }
    }*/

    public void Abandon()
    {
        QuetesActuelle = null;
    }
}
