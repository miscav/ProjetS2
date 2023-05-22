using UnityEngine;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Article> Stock;

    private void Start()
    {
        Stock = new List<Article>();
    }

    public void Buy(int index)
    {
       
    }
}