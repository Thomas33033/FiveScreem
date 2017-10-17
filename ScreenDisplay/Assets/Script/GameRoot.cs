using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;
using System.IO;
public class GameRoot : MonoBehaviour {
    public GameObject Canvas1;
    public GameObject Canvas2;
    public GameObject Canvas3;
    public GameObject Canvas4;
    public GameObject Canvas5;
    public static GameRoot Instance;

    ShouYe shouye;
    void Awake()
    {
        Instance = this;
        shouye = UIMgr.ShowUI<ShouYe>("ShouYe", this.Canvas1.transform.parent.parent.gameObject);
    }
	// Use this for initialization
	void Start () {

        //获取设置当前屏幕分辩率  
        Resolution[] resolutions = Screen.resolutions;
        //设置当前分辨率  
        Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, true);

        Screen.fullScreen = true;  //设置成全屏,  

        Application.logMessageReceived += HandleLog;
      
       
    }

    void HandleLog(string condition, string stackTrace, LogType type)
    {
        if (type == LogType.Error)
        {
            if (ShowLog)
            {
                DebugConsole.Log(condition);
            }
            
        }
    }

    private bool ShowLog = false;
    void Update()
    {
        //  按ESC退出全屏  
        if (Input.GetKey(KeyCode.Escape))
        {
            Screen.fullScreen = false;  //退出全屏           
        }
        else if (Input.GetKey(KeyCode.F1))
        {
            Screen.fullScreen = true;
        }
        else if (Input.GetKey(KeyCode.F4))
        {
            DebugConsole.instance.ClearMessages(); 
        }
        else if (Input.GetKey(KeyCode.F3))
        {
            ShowLog = !ShowLog;
        }
    }

    public void ShowUI()
    {
        UIMgr.Delete<ShouYe>(shouye);
        ScreenPage_1 go1 = UIMgr.ShowUI<ScreenPage_1>("Page_1", this.Canvas1);
        ScreenPage_2 go2 = UIMgr.ShowUI<ScreenPage_2>("Page_2", this.Canvas2);
        ScreenPage_3 go3 = UIMgr.ShowUI<ScreenPage_3>("Page_3", this.Canvas3);
        ScreenPage_4 go4 = UIMgr.ShowUI<ScreenPage_4>("Page_4", this.Canvas4);
        ScreenPage_5 go5 = UIMgr.ShowUI<ScreenPage_5>("Page_5", this.Canvas5);
        
    }
    
    public void DeleteUI()
    {
        shouye = UIMgr.ShowUI<ShouYe>("ShouYe", this.Canvas1.transform.parent.parent.gameObject);

        foreach (Transform trans in Canvas1.transform)
        {
            GameObject.Destroy(trans.gameObject);
        }
        foreach (Transform trans in Canvas2.transform)
        {
            GameObject.Destroy(trans.gameObject);
        }
        foreach (Transform trans in Canvas3.transform)
        {
            GameObject.Destroy(trans.gameObject);
        }
        foreach (Transform trans in Canvas4.transform)
        {
            GameObject.Destroy(trans.gameObject);
        }
        foreach (Transform trans in Canvas5.transform)
        {
            GameObject.Destroy(trans.gameObject);
        }
        UIMgr.pageDic.Clear();
    }
    public IEnumerator LoadData(int type, string url, Action<string> action)
    {
        //获取json
        string baseUrl = DataMgr.tokenUrl;

        WWW www = new WWW(baseUrl);
        yield return www;
        if (www.isDone)
        {
            Debug.LogError(www.text);
            JsonData jsonData = JsonMapper.ToObject(www.text);
            DataMgr.access_token = jsonData["data"]["access_token"].ToString();
            if (type == 1)
                url = DataMgr.GetURL(url);
            else
                url = DataMgr.GetURLById(url);
            
            WWW www1 = new WWW(url);
            yield return www1;
            if (www1.isDone)
            {
                if (action != null)
                {
                    action(www1.text);
                    action = null;
                }
            }
            else
            {
                Debug.LogError("Request failed!");
            }
        }
    }
}
