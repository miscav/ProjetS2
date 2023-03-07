using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personnages : MonoBehaviour
{
    protected float Health;
    [SerializeField]
    public Vector3 Coordinates { get; protected set; }
    public float Speed { get; protected set; }
    public float Damages { get; protected set; }
    public List<Items> Bag { get; protected set; }

    protected CharacterController Character;
    protected float Gravity = -9.81f;

    public void ReceiveDamages(float damage) { } 

    public void Attack(float damage) { }

    public void Use(int index)
    {
        Bag[index].Use();
    }

    public bool IsAlive()
    {
        return Health > 0;
    }
}
