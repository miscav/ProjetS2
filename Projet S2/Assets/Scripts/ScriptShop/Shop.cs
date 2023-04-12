using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using System;
#pragma warning disable CS0105 // La directive using de 'System' est apparue précédemment dans cet espace de noms
using System;
#pragma warning restore CS0105 // La directive using de 'System' est apparue précédemment dans cet espace de noms
using System.Collections.Generic;
using System.IO;

public class Shop : MonoBehaviour
{
    public List<Article> Stock;

    public Shop()
    {
        
    }

    public Shop(Article[] stock)
    {
        foreach(Article VARIABLE in stock)
        {
            Stock.Append(VARIABLE);
        }
    }

    public void Show()
    {

    }

    private void Start()
    {
        Stock= new List<Article>(0);
    }

    public void Buy(Player player, int indice)
    {
       
    }
}