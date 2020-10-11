using System.Collections;
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

    public bool currentTurn = true;
    public Player player;
    public Enemy enemy;
    [SerializeField]float gold = 100;
    public GameObject parentPanel;
    public List<IconCreator> myPowerups;
    public List<GeneralEnemy> Tier1Enemy;
    public List<GeneralEnemy> Tier2Enemy;
    public List<GeneralEnemy> Tier3Enemy;
    public GeneralEnemy myEnemyObj;
    public GameObject enemyPrefab;
    public GameObject slotPrefab;
    public int tempType; // Received from attackButtonSccript
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
            player.currentHp -= damage - (Random.value * player.permDefense);
            Debug.Log("Player " + player.currentHp);
        }
        else if(currentTurn)
        {
            currentTurn = false;
            if(tempType != -1 && tempType == (int)myEnemyObj.weakAgainst)
            {
                enemy.health -= (Random.value+1) *damage -(Random.value * enemy.defense);
                tempType = -1;
            }
            else if(tempType != -1 && tempType == (int)myEnemyObj.strongAgainst)
            {
                enemy.health -= (Random.value) *damage;
                tempType = -1;
            }
            else
            {
                enemy.health -= damage;
            }
            Debug.Log("Enemy " + enemy.health);
        }
    }
    //Slot Instantiation
    public void SlotInstantiation()
    {
        foreach (var item in myPowerups)
        {
            float number = 0;
            if(item.amount > 0&& !item.infinite)
            {
                var prefabInstantiated = (GameObject)Instantiate(slotPrefab,transform.position,Quaternion.identity);
                prefabInstantiated.transform.SetParent(parentPanel.transform,false);
                prefabInstantiated.GetComponent<Image>().sprite = item.iconSprite;
                prefabInstantiated.GetComponent<AttackButtonScript>().myObj = item;
                prefabInstantiated.GetComponent<AttackButtonScript>().itemNo = number;
            }
            else if(item.infinite)
            {
                var prefabInstantiated = (GameObject)Instantiate(slotPrefab,transform.position,Quaternion.identity);
                prefabInstantiated.transform.SetParent(parentPanel.transform,false);
                prefabInstantiated.GetComponent<Image>().sprite = item.iconSprite;
                prefabInstantiated.GetComponent<AttackButtonScript>().myObj = item;
            }
            number += 1;
        }
    }
    void EnemyRandomise()
    {
        int randomNum = Random.Range(0,Tier1Enemy.Count);
        currentTurn = true;
        enemy = null;
        myEnemyObj = Tier1Enemy[randomNum];
        GameObject enemyG = (GameObject)Instantiate(enemyPrefab,new Vector2(31,370),Quaternion.identity);
        enemyG.transform.SetParent(GameObject.Find("War Panel").transform,false);
        enemyG.GetComponent<Image>().sprite = myEnemyObj.enemySprite;
        enemy = enemyG.GetComponent<Enemy>();
        enemy.attack = myEnemyObj.attack;
        enemy.health = myEnemyObj.health;
        enemy.defense = myEnemyObj.defense;

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
    public void AddGold(float coins)
    {
        gold += coins;
    }
}
