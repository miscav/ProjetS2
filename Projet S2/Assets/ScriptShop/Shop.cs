using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using System;
using System;
using System.Collections.Generic;
using System.IO;

public class Shop : MonoBehaviour
{
    public List<Article> Stock;

    public Shop(Article[] stock)
    {
        foreach(Article VARIABLE in stock)
        {
            Stock.Append(VARIABLE);
        }
    }

    private void Start()
    {
        Stock= new List<Article>(0);
    }

    public void Buy(Player player, int indice)
    {
       
    }
}