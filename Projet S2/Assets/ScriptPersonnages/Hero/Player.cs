using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Player : Personnages
{
    private int Balance;
    public int GetBalance() { return Balance; }
    private Rigidbody character;
    bool isGrounded = true;

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
        Speed = 5f;
        Damages = 10f;
        Bag = new List<Items> {  };
        character = GetComponent<Rigidbody>();
    }

    public float rotateSpeed = 180.0f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            character.AddForce(Vector3.up * 5000);
            isGrounded = false;
        }
        // Deplacement du Player vers l'avant
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }
        // Deplacement du Player vers l'arrière 
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
        // Rotation du Player avec la souris 
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed);


    }

    void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
    }
}

