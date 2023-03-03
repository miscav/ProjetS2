using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private bool Succed_Quest_1;
    private bool Failed_Quest_1;
    private int Chrono_1;
    
    public bool Succed_Quest
    {
        get { return Succed_Quest_1;}
        set { Succed_Quest_1 = value; }
    }

    public bool Failed_Quest
    {
        get { return Failed_Quest_1; }
        set { Failed_Quest_1 = value; }
    }

}
