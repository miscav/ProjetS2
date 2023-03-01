using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personnages : MonoBehaviour
{
    protected float Health;
    protected Vector3 Coordinates;
    protected float Speed;
    protected float Damages;
    protected List<Items> Bag;

    public float GetHealth() { return Health; }
    public (float,float) GetCoordinates() { return Coordinates; }
    public float GetSpeed() { return Speed; }
    public float GetDamage() { return Damages; }
    public List<Items> GetItems() { return Bag; }

    public void ReceiveDamages(float damage) { }

    public void Use(int index)
    {
        Bag[index].Use();
    }

    public bool IsAlive()
    {
        return Health > 0;
    }
}
