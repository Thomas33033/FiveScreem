using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Page_5_2_1 : MonoBehaviour {

    public Image image1;
    public Image image2;
    public Text title_1;
    public Text title_2;
    public Text txt_content;

    public Button button;
    // Use this for initialization
    public void InitData(Page_5_2_ItemData data)
    {
        GameTools.AddClickEvent(button.gameObject, this.BackButton_ClickEvent);
        title_1.text = data.title;
        title_2.text = data.title;
        txt_content.text = data.content;
        LayoutElement rt = txt_content.gameObject.transform.parent.GetComponent<LayoutElement>();
        rt.preferredHeight = txt_content.preferredHeight;
       
        
        if (data.imgs.Length == 2)
        {
            GameTools.Instance.LoadImage(image1, data.imgs[0], 4, 4);
            GameTools.Instance.LoadImage(image2, data.imgs[1], 4, 4);
        }
        else if (data.imgs.Length == 1)
        {
            GameTools.Instance.LoadImage(image1, data.imgs[0], 4, 4);
            GameTools.Instance.LoadImage(image2, data.imgs[0], 4, 4);
        }
        
    }

    // Update is called once per frame
    void BackButton_ClickEvent()
    {
        UIMgr.Delete<Page_5_2_1>(this);
    }
}
