using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_4_1_Item : MonoBehaviour {
    public List<Text> list;
	// Use this for initialization
    void Awake()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].gameObject.SetActive(false);
        }
    }

	public void InitData (Page_4_1_ItemData data) 
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < data.list.Count; i++)
        {
            list[i].text = data.list[i];
            list[i].gameObject.SetActive(true);
        }
	}
	
	
}
