using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MyPlayer : MonoBehaviourPunCallbacks
{
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 180.0f;
    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            ProcessInput();
        }
    }
    public void ProcessInput()
    {
        // Deplacement du Player vers l'avant
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        // Deplacement du Player vers l'arrière 
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        // Rotation du Player avec la souris 
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotateSpeed);
    }
}
