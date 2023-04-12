using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialisation : MonoBehaviour
{
    [SerializeField] public QuetePNJ Pnj1;
    [SerializeField] public QuetePNJ Pnj2;
    [SerializeField] public QuetePNJ Pnj3;
    [SerializeField] public QuetePNJ Pnj4;
    [SerializeField] public QuetePNJ Pnj5;

    void Start()
    {
        Pnj1.Initialize();
        Pnj2.Initialize();
        Pnj3.Initialize();
        Pnj4.Initialize();
        Pnj5.Initialize();
    }
}
