using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Player : Personnages
{
    private int Balance;
    public int GetBalance() { return Balance; }

    public void AddBalance(int balance)
    {
        if(balance > 0) Balance += balance;
    }

    public void Eat(int index)
    {
        if (Bag[index] is Food) 
        {
            ((Food)Bag[index]).Use(this); // Food
        }
    }

    public void Drop(int index)
    {
        // Drop
    }

    public void PickUp(Items item)
    {
        // Pick Up
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = 200f;
        Coordinates = new Vector3(0,0,0);
        Speed = 2f;
        Damages = 10f;
        Bag = new List<Items> { new Torch() };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
