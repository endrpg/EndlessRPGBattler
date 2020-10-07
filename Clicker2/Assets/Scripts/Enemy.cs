using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Update is called once per frame
    public float attack = 5f;
    public float health = 100f;
    bool attackDone = false;
    void Update()
    {
        if(!GameManager.Instance.currentTurn&&!attackDone)
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        attackDone = true;
        yield return new WaitForSeconds(2f);
        GameManager.Instance.DoDamage(attack);
        attackDone = false;
    }
}
