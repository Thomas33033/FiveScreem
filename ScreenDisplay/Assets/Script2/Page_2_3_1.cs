using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Page_2_3_1_Data
{
    public string title = "";
    public string content;
}

public class Page_2_3_1 : MonoBehaviour {
    public List<GameObject> itemList;
    public GameObject button;
	// Use this for initialization
    public void InitData(List<Page_2_3_1_Data> itemDatas)
    {
        GameTools.AddClickEvent(button.gameObject, this.BackBtn_ClickEvent);
        for (int i = 0; i < itemList.Count; i++)
        {
            itemList[i].SetActive(false);
        }

        for (int i = 0; i < itemDatas.Count; i++)
        {
            GameObject go = itemList[i];
            Text txt_title = go.transform.Find("txt_title").gameObject.GetComponent<Text>();
            txt_title.text = itemDatas[i].title;
            itemList[i].SetActive(true);
            Text txt_content = go.transform.Find("Scroll View/Viewport/Content/Text").gameObject.GetComponent<Text>();
            txt_content.text = itemDatas[i].content;
            int curIndex = i;
            GameTools.AddClickEvent(go.gameObject, ()=>{
                ClickItem(go, curIndex);
            });
        }
    }

    void ClickItem(GameObject go,int index)
    {
        if (index == 0)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                RectTransform rt = itemList[i].gameObject.GetComponent<RectTransform>();
                rt.SetAsFirstSibling();
            }
        }
        int curLayer = index;
        for (int i = itemList.Count - 1; i > index; i--)
        {
            RectTransform rt = itemList[i].gameObject.GetComponent<RectTransform>();
            rt.SetSiblingIndex(--curLayer);
        }

        for (int i = 0; i < index; i++)
        {
            RectTransform rt1 = go.gameObject.GetComponent<RectTransform>();
            rt1.SetSiblingIndex(i);
        }

        RectTransform curRt = go.gameObject.GetComponent<RectTransform>();
        curRt.SetSiblingIndex(itemList.Count);
        
    }
	
	// Update is called once per frame
    void BackBtn_ClickEvent()
    {
        GameObject.Destroy(this.gameObject);
	}
}
