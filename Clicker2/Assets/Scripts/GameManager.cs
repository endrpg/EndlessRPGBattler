using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.Log("Not found");
            }
            return instance;
        }
    }

    public bool currentTurn = false;
    Player player;
    Enemy enemy;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
    }
    public void DoDamage(float damage)
    {
        if(!currentTurn)
        {
            currentTurn = true;
            player.health -= damage;
            Debug.Log("Player " + player.health);
        }
        else if(currentTurn)
        {
            currentTurn = false;
            enemy.health -= damage;
            Debug.Log("Enemy " + enemy.health);
        }
    }
}
