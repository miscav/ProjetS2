using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Robots : Personnages
{
    public Quetes Quete { get; private set; }
    public int Reward { get; private set; }

    // Start is called before the first frame update
    Robots(Quetes quete, int reward)
    {
        Health = 10f;
        Coordinates = new Vector3(0, 0, 0); // a definir 
        Speed = 1f;
        Damages = 0f;
        Bag = new List<Items> {  };
        Quete = quete;
        Reward = reward;
    }

    public void QueteCompleted(Player player)
    {
        player.AddBalance(Reward);
        player.AddBag(Bag);
    }
}
