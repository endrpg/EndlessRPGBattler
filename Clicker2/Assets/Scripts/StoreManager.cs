using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreManager : MonoBehaviour
{
    public List<IconCreator> allIcons;
    public List<IconCreator> selectedIcons;
    public GameObject parentPanel;
    public GameObject slotPrefab;
    void Start()
    {
        RandomiseStore();
    }
    public void RandomiseStore()
    {
        for(int i = 0; i < 2;i+=1)
        {
            int presentIcon = Random.Range(0,allIcons.Count);
            IconCreator presentPrefab = allIcons[presentIcon];
            if(!selectedIcons.Contains(presentPrefab))
            {
                selectedIcons.Add(presentPrefab);
            }
            else
            {
                i-=1;
            }
        }
        foreach (var item in selectedIcons)
        {
            var prefabInstantiated = (GameObject)Instantiate(slotPrefab,transform.position,Quaternion.identity);
            prefabInstantiated.transform.SetParent(parentPanel.transform,false);
            prefabInstantiated.GetComponent<Image>().sprite = item.iconSprite;
            prefabInstantiated.GetComponent<ToreButtonScript>().myStoreObj = item;
        }
    }
}
