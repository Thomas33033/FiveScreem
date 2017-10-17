using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_1_2_1 : MonoBehaviour {
    public Button backButton;
    public Text txt_title1;
    public Text txt_title2;
    public Text txt_Content;
    public Image image;

    void Awake()
    {
        GameTools.AddClickEvent(backButton.gameObject, this.backButton_ClickEvent);
    }

	// Use this for initialization
	public void InitData (string title, string content, string imgs) {
        
        txt_title1.text = title;
        txt_title2.text = title;
        txt_Content.text = content;
        LayoutElement rt = txt_Content.gameObject.transform.parent.GetComponent<LayoutElement>();
        rt.preferredHeight = txt_Content.preferredHeight;

        GameTools.Instance.LoadImage(image, imgs, 4, 4);
	}
	
	// Update is called once per frame
    void backButton_ClickEvent()
    {
        UIMgr.Delete<Page_1_2_1>(this);
	}
}
