using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_2_3_ItemData
{
    public string id;
    public string riqi;
    public string week;
    public string content;
    public string times;
    public string address;
    public string owner;
    public string emphases;
}

public class Page_2_4_ItemData
{
    public string id;
    public string riqi;
    public string week;
    public string times;
    public string content;
    public string address;
    public string enters;
    public string classStr;
}


public class Page_2_3_Item : MonoBehaviour {
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;
    public Text text7;
    public Text text8;
	// Use this for initialization
    public void InitData(Page_2_3_ItemData itemData) 
    {
        text1.text = itemData.riqi ;
        text2.text = itemData.week;
        text3.text = itemData.emphases;
        text4.text = itemData.times;
        text5.text = itemData.address;
        text6.text = itemData.owner;

        if (text3.preferredHeight > 85)
        {
            float height = text3.preferredHeight + 30;
            LayoutElement element = this.gameObject.GetComponent<LayoutElement>();
            element.preferredHeight = height;
            RectTransform rt = this.gameObject.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, height);

            Image image = this.gameObject.transform.Find("Image_1").GetComponent<Image>();
            RectTransform rt2 = image.gameObject.GetComponent<RectTransform>();
            rt2.sizeDelta = new Vector2(rt2.sizeDelta.x, height+4);

            SetHeight(text1, height);
            SetHeight(text2, height);
            SetHeight(text3, height);
            SetHeight(text4, height);
            SetHeight(text5, height);
            SetHeight(text6,height);

        }
       
	}


    public void InitData2(Page_2_4_ItemData itemData)
    {
        text1.text = itemData.riqi;
        text2.text = itemData.week;
        text3.text = itemData.times;
        text4.text = itemData.content;
        text5.text = itemData.address;
        text6.text = itemData.enters;
        text7.text = itemData.classStr;

        if (text4.preferredHeight > 74)
        {
            float height = text4.preferredHeight + 30;
            LayoutElement element = this.gameObject.GetComponent<LayoutElement>();
            element.preferredHeight = height;
            RectTransform rt = this.gameObject.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, height);

            Image image = this.gameObject.transform.Find("Image_1").GetComponent<Image>();
            RectTransform rt2 = image.gameObject.GetComponent<RectTransform>();
            rt2.sizeDelta = new Vector2(rt2.sizeDelta.x, height);

            SetHeight(text1, height);
            SetHeight(text2, height);
            SetHeight(text3, height);
            SetHeight(text4, height);
            SetHeight(text5, height);
            SetHeight(text6, height);
            SetHeight(text7, height);
        }

    }

    void SetHeight(Text itemObj ,float height)
    {
        RectTransform rt2 = itemObj.transform.parent.gameObject.GetComponent<RectTransform>();
        float temp = height - rt2.sizeDelta.y;
        rt2.sizeDelta = new Vector2(rt2.sizeDelta.x, height);
        rt2.anchoredPosition = new Vector2(rt2.anchoredPosition.x, rt2.anchoredPosition.y - temp/2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
