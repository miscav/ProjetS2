using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PNJ : Personnages
{
    // Start is called before the first frame update
    void Start()
    {
        Health = 10f;
        Coordinates = new Vector3(0, 0, 0);
        Speed = 1f;
        Damages = 0f;
        Bag = new List<Items> { };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
