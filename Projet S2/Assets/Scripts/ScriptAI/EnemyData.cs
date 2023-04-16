using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "testBis",menuName = "Enemy/Robot du chateau")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public string description;
    public GameObject enemyModel;
    public int health = 100;
    public float speed = 1.5f;
    public int damage = 1;
    
    

}
