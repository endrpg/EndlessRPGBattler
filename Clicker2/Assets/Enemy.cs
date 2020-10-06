using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Update is called once per frame
    public float attack = 5f;
    public float health = 100f;
    void Update()
    {
        if(!GameManager.Instance.currentTurn)
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(5f);
        GameManager.Instance.DoDamage(attack);
    }
}
