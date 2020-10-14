using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy1", menuName = "GeneralEnemy/New Enemy")]
public class GeneralEnemy : ScriptableObject
{
    public Sprite enemySprite;
    public string monsterName;
    public string monsterInfo;
    public float health;
    public float attack;
    public float defense;
    public float goldToWin;
    public float evade;
    public float criticalAttackPercentage;
    public float criticalAttackMultiplier;

    public WeakAgainst weakAgainst;
    public StrongAgainst strongAgainst;
    public WeakAgainst weakAgainst2;
    public StrongAgainst strongAgainst2;
    public WeaponStrong weaponStrong;
    public WeaponWeak weaponWeak;
    public specialItemDropped ItemDrop;
    public enum WeakAgainst
    {
        None,
        Earth,
        Fire,
        Water,
        Wind,
        Electric,
        Dark,
        Holy,
        Normal
    }
    public enum StrongAgainst
    {
        None,
        Earth,
        Fire,
        Water,
        Wind,
        Electric,
        Dark,
        Holy,
        Normal
    }
    public enum WeaponStrong
    {
        None, 
        axe,
        lance,
        dagger,
        sword,
        bow
    }
    public enum WeaponWeak
    {
        None,
        axe,
        lance,
        dagger,
        sword,
        bow
    }
    public enum specialItemDropped
    {
       none,
       item1,
       item2,
       item3,
       item4,
       item5,
       item6,
       item7,
       item8,
       item9,
       item10
    }
}
