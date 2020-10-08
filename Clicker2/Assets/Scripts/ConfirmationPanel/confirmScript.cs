using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class confirmScript : MonoBehaviour
{
    public IconCreator myObj;
    AudioSource audioSource;
    public AudioClip cashRegister;
    Button me;
    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        me = GetComponent<Button>();
        me.onClick.RemoveAllListeners();
        me.onClick.AddListener(delegate{Confirm();});
        audioSource = GetComponent<AudioSource>();
    }
    void Confirm()
    {
        if(GameManager.Instance.ReturnGold() >= myObj.price)
        {
            GameManager.Instance.RemoveGold(myObj.price);
            if(!GameManager.Instance.myPowerups.Contains(myObj))
            {
                GameManager.Instance.myPowerups.Add(myObj);
            }
            else if(GameManager.Instance.myPowerups.Contains(myObj))
            {
                myObj.amount += myObj.maxAmount;
            }
            if(cashRegister != null)
            {
                audioSource.PlayOneShot(cashRegister,1f);
            }
            Destroy(transform.parent.gameObject,1f);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
