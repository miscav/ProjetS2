using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Article[] Stock;

    public Shop(Article[] stock)
    {
        foreach(Article VARIABLE in stock)
        {
            Stock.Append(VARIABLE);
        }
    }

    private void Start()
    {
        Stock= new Article[0];
    }
}