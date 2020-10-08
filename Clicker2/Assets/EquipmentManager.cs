using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipmentManager : MonoBehaviour
{
    private static EquipmentManager instance;
    public static EquipmentManager Instance
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
    void Awake()
    {
        instance = this;
    }
    public List<IconCreator> Equipment;
    public IconCreator head;
    public IconCreator chest;
    public IconCreator torso;
    public IconCreator shoes;
    public GameObject headSp;
    public GameObject chestSp;
    public GameObject torsoSp;
    public GameObject shoesSp;
    public GameObject slotPrefab;
    public GameObject parentPanel;
    void Update()
    {
        SpriteEx(headSp,head);
        SpriteEx(chestSp,chest);
        SpriteEx(torsoSp,torso);
        SpriteEx(shoesSp,shoes);
        foreach (var item in Equipment)
        {
            GameObject equipmentSlots = Instantiate(slotPrefab,transform.position,Quaternion.identity);
            equipmentSlots.transform.SetParent(parentPanel.transform,false);
        }
    }
    void SpriteEx(GameObject sp,IconCreator ic)
    {
        if(ic != null)
        {
            Color c = sp.GetComponent<Image>().color;
            c.a = 1;
            sp.GetComponent<Image>().color = c;
            sp.GetComponent<Image>().sprite = ic.iconSprite;
        }
    }

}
