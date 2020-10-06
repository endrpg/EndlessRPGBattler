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
    public float magicPower;
}