using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "IconCreator", menuName = "Icon/New Icon")]
public class IconCreator : ScriptableObject
{
    public float attackPower;
    public float defense;
    public Sprite iconSprite;
    public float healPower;
    public float amount;
    public float maxAmount;
    public float price;
    public bool infinite;
    public float permanenntStrengthInc;
    public float permanenntDefenseInc;
    public float hpIncrease;
    public float lifeIncrease;
    public GameObject effect;
    [System.Serializable]
    public enum Tiers
    {
        Tier1,
        Tier2,
        Tier3,
        Tier4,
        Tier5
    }
    [System.Serializable]
    public enum Type
    {
        Earth,
        Fire,
        Cold,
        Normal
    }
    [System.Serializable]
    public enum Equipment
    {
        None,
        Head,
        Chest,
        Torso,
        Shoes
    }
    public Tiers tiers;
    public Type type;
    public Equipment equipment;
}