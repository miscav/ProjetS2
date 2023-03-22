using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Personnages
{
    private int Balance;
    public int GetBalance() { return Balance; }
    private float run = 1;
    private Vector3 playerVelocity;

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

    public float rotateSpeed = 180.0f;

    // Start is called before the first frame update
    void Start()
    {
        Health = 200f;
        Coordinates = new Vector3(0,0,0);
        Speed = 5f;
        Damages = 10f;
        Bag = new List<Items> {  };
        Character = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            run = 1.5f;
        }

        Coordinates = transform.position;

        if (Character.velocity.y < 0 && Character.isGrounded) playerVelocity.y = 0f;

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Character.Move(transform.right * move.x * Time.deltaTime * Speed * run);
        Character.Move(transform.forward * move.z * Time.deltaTime * Speed * run);

        // Changes the height position of the player..
        if (Input.GetKeyDown(KeyCode.Space) && Character.isGrounded)
        {
            playerVelocity.y += -0.7f * Gravity;
        }

        playerVelocity.y += Gravity * Time.deltaTime;

        Character.Move(playerVelocity * Time.deltaTime);

        run = 1f;

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed);
    }
}

