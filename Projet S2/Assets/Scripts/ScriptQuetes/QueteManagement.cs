using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueteManagement : MonoBehaviour
{
    [SerializeField] public Quetes quete;
    [SerializeField] public static Quetes QuetesActuelle;
    [SerializeField] public static Player player;
    [SerializeField] public static Inventory inventory;

    private void Start()
    {
        QuetesActuelle = null;
    }

    public static void Reussi()
    {
        QuetesActuelle = null;
        player.AddBalance(QuetesActuelle.RewardMoney);
        inventory.Add(QuetesActuelle.RewardItem);
    }
    public void Abandon()
    {
        QuetesActuelle = null;
    }
}
