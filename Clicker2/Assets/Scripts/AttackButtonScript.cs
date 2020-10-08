using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AttackButtonScript : MonoBehaviour
{
    public IconCreator myObj;
    Button me;
    public TextMeshProUGUI amount;
    public float itemNo;
    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.currentTurn)
        {
            me.onClick.RemoveAllListeners();
            me.onClick.AddListener(delegate{AttackingEnemy();});
        }
        UpdateText();
    }
    void AttackingEnemy()
    {
        if(myObj.amount > 0)
        {
            GameManager.Instance.DoDamage(GameManager.Instance.player.attack + myObj.attackPower);
            if(!myObj.infinite)
            {
                myObj.amount -=1;
            }
            GameManager.Instance.currentTurn = false;
        }
        if(myObj.amount <= 0)
        {
            GameManager.Instance.myPowerups.RemoveAt((int)itemNo);
            Destroy(this.gameObject);
        }
    }
    void UpdateText()
    {
        if(!myObj.infinite)
        {
            amount = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            if(myObj.amount > 1)
            {
                amount.text = myObj.amount.ToString();
            }
            if(myObj.amount == 1)
            {
                amount.text = "";
            }
        }
        if(myObj.infinite)
        {
            amount = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            amount.text = "+++";
        }
    }
}
