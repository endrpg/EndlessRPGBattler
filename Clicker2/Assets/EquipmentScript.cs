using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipmentScript : MonoBehaviour
{
    Button me;
    public IconCreator meObj;
    void Start()
    {
        me = GetComponent<Button>();
    }
    void Update()
    {
        me.onClick.RemoveAllListeners();
        me.onClick.AddListener(delegate{ContactEquipManager();});
    }
    void ContactEquipManager()
    {
        if((int)meObj.equipment == 1)
        {
            EquipmentManager.Instance.head = meObj;
        }
        else if((int)meObj.equipment == 2)
        {
            EquipmentManager.Instance.chest = meObj;
        }
        else if((int)meObj.equipment == 3)
        {
            EquipmentManager.Instance.torso = meObj;
        }
        else if((int)meObj.equipment == 4)
        {
            EquipmentManager.Instance.shoes = meObj;
        }
    }
}
