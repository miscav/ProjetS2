using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Personnages
{
    private int Balance;
    public int GetBalance() { return Balance; }
    private float run = 1;
    private Vector3 playerVelocity;
    protected float Hungry;
    public AudioClip sonmarche;
    public float delaybetweenstep;
    private float nextPlay;

    void Start()
    {
        Health = 200f;
        Coordinates = new Vector3(0, 0, 0);
        Speed = 5f;
        Damages = 10f;
        Bag = new List<Items> { };
        Character = GetComponent<CharacterController>();
        Hungry = 100;
        QueteManagement.player = this;
        delaybetweenstep = 0.65f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = 1.5f;
        }

        Coordinates = transform.position;

        if (Character.velocity.y < 0 && Character.isGrounded) playerVelocity.y = 0f;

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Character.Move(transform.right * move.x * Time.deltaTime * Speed * run);
        Character.Move(transform.forward * move.z * Time.deltaTime * Speed * run);
        ReduiceHungry(Time.deltaTime * run);

        if (move != new Vector3(0,0,0) && Time.time > nextPlay && Character.isGrounded)
        {
            nextPlay = Time.time + delaybetweenstep;
            GetComponent<AudioSource>().PlayOneShot(sonmarche);
        }


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

    public void ReduiceHungry(float hungry)
    {
        if (Hungry <= 0f)
        {
            Hungry = 0f;
            ReceiveDamages(5*Time.deltaTime);
        }
        else
        {
            Hungry -= hungry*Time.deltaTime * 0.1f;
        }
    }

    public void AddBalance(int balance)
    {
        if (balance > 0) Balance += balance;
    }

    public void Eat(ItemsData item)
    {
        if(item is Food)
        {
            if (Health == MaxHealth)
            {
                // Ne peux pas manger
            }
            else
            {
                Health += ((Food)item).PV;
            }
        }
    }

    public float rotateSpeed = 180.0f;

}

