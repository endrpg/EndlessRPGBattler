using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy1", menuName = "GeneralEnemy/New Enemy")]
public class GeneralEnemy : ScriptableObject 
{
    public enum WeakAgainst
    {
        Earth,
        Fire,
        Cold,
        None
    }
    public enum StrongAgainst
    {
        Earth,
        Fire,
        Cold,
        None
    }
    public WeakAgainst weakAgainst;
    public StrongAgainst strongAgainst;
    public float health;
    public float defense;
    public Sprite enemySprite;
    public float attack;
}
