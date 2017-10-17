using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_1_6 : MonoBehaviour {

    public Button backButton;
	// Use this for initialization
	void Start () {
        GameTools.AddClickEvent(backButton.gameObject, this.backButton_ClickEvent);
	}
	
	// Update is called once per frame
    void backButton_ClickEvent()
    {
        UIMgr.ShowUI<ScreenPage_1>("Page_1", this.transform.parent.gameObject);
        UIMgr.Delete<Page_1_6>(this);
	}
}
