using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Page4_3_1 : MonoBehaviour {
    public Image image1;
    public Image image2;
    public Text title_1;
    public Text title_2;
    public Text txt_content;

    public Button button;
	// Use this for initialization
    public void InitData(Page_4_3_ItemData data)
    {
        GameTools.AddClickEvent(button.gameObject, this.BackButton_ClickEvent);
        txt_content.text = data.content;
        LayoutElement rt = txt_content.gameObject.transform.parent.GetComponent<LayoutElement>();
        rt.preferredHeight = txt_content.preferredHeight;

        title_1.text = data.title;
        title_2.text = data.title;
        if (data.imgs != null)
        {
            if (data.imgs.Length == 1)
            {
                GameTools.Instance.LoadImage(image1, data.imgs[0], 4, 4);
                GameTools.Instance.LoadImage(image2, data.imgs[0], 4, 4);
            }
            else if (data.imgs.Length == 2)
            {
                GameTools.Instance.LoadImage(image1, data.imgs[0], 4, 4);
                GameTools.Instance.LoadImage(image2, data.imgs[1], 4, 4);
            }
        }
	}

    public void ShowBar()
    {
        this.gameObject.transform.Find("img_bar/img_bar _1").gameObject.SetActive(true);
        this.gameObject.transform.Find("Button_back/img").gameObject.SetActive(true);

        this.gameObject.transform.Find("bg_1").gameObject.SetActive(true);
    }

	// Update is called once per frame
    void BackButton_ClickEvent()
    {
        GameObject.Destroy(this.gameObject);
	}
}
