using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataMgr  {
    
    public static string mURL = "";
    public static string URL
    { 
        get{

            if (mURL == "")
            {
                 string filePath = Application.streamingAssetsPath + "/config.txt";
                 System.IO.StreamReader read = File.OpenText(filePath); 
                 mURL = read.ReadLine();
                 DataMgr.FilePath = read.ReadLine();
                 Debug.LogError(DataMgr.URL);
                 Debug.LogError(DataMgr.FilePath);
            }
            return mURL;
        }
    
    }
    public static string FilePath = "";

    public static string tokenUrl
    {
         get
         { 
             return  URL + "/api/59a8bbd47169c.html?app_id=13280719&signature=f0441397c8fac8ed347fcb8bdfecd681&version=v2.0";
         }
    }
	public static string access_token;
    //首页
    public static string shouYeUrl{ get{ return URL + "/api/59b8959a2fd4a.html?"; }}

    //获取图文列表接口
    public static string GetURLById(string id)
    {
        string url = URL + "/api/59b8a5ca854a6.html?cat_id=" + id;
        return GetURL(url);
    }
    //获取视频接口
    public static string spjk { get { return URL + "/api/59b8a72ac1629.html?"; } } 
    //大事记
    public static string daShiJi { get { return URL + "/api/59b8c3f21d2c4.html?"; } } 
    //获取行规教育接口
    public static string xgjy { get { return URL + "/api/59b8c9f7964ed.html?"; } } 
    //获取每周工作接口
    public static string mzgz { get { return URL + "/api/59b8cb57d8431.html?"; } } 
    //教师外出安排接口
    public static string wcap { get { return URL + "/api/59b8cfdab84b0.html?"; } } 
    
   
    public static string GetURL(string url)
    {
        return url
       //     + "app_id=13280719&signature=f0441397c8fac8ed347fcb8bdfecd681"
            + "&access-token="
            + DataMgr.access_token + "&version=v2.0";
    }


}
