using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouYe : MonoBehaviour {
    public GameObject img1;
    public GameObject img2;
    public GameObject img3;
    public GameObject img4;
    public GameObject img5;

	// Use this for initialization
	void Start () {


        GameTools.AddClickEvent(img1.gameObject, this.backButton_ClickEvent);
        GameTools.AddClickEvent(img2.gameObject, this.backButton_ClickEvent);
        GameTools.AddClickEvent(img3.gameObject, this.backButton_ClickEvent);
        GameTools.AddClickEvent(img4.gameObject, this.backButton_ClickEvent);
        GameTools.AddClickEvent(img5.gameObject, this.backButton_ClickEvent);
	}
	
	// Update is called once per frame
    void backButton_ClickEvent()
    {
        GameObject.Destroy(this.gameObject);
        GameRoot.Instance.ShowUI();
	}
}
