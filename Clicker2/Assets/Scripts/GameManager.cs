﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public Player player;
    public Enemy enemy;
    float gold = 100;
    public GameObject parentPanel;
    public List<IconCreator> myPowerups;
    public GameObject slotPrefab;
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
    //Slot Instantiation
    void SlotInstantiation()
    {
        foreach (var item in myPowerups)
        {
            if(item.amount > 0&& !item.infinite)
            {
                var prefabInstantiated = (GameObject)Instantiate(slotPrefab,transform.position,Quaternion.identity);
                prefabInstantiated.transform.SetParent(parentPanel.transform,false);
                prefabInstantiated.GetComponent<Image>().sprite = item.iconSprite;
                prefabInstantiated.GetComponent<AttackButtonScript>().myObj = item;
            }
            else if(item.infinite)
            {
                var prefabInstantiated = (GameObject)Instantiate(slotPrefab,transform.position,Quaternion.identity);
                prefabInstantiated.transform.SetParent(parentPanel.transform,false);
                prefabInstantiated.GetComponent<Image>().sprite = item.iconSprite;
                prefabInstantiated.GetComponent<AttackButtonScript>().myObj = item;
            }
        }
    }
    //Gold Related methods
    public void RemoveGold(float coins)
    {
        gold -= coins;
    }
    public float ReturnGold()
    {
        return gold;
    }
}
