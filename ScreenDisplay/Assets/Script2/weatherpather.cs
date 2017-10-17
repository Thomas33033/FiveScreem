using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class WeatherData
{
    public string weather;
    public string tgd;    //温度
    public string tgd1;   //最高温度
    public string tgd2;   //最低温度
    public string time;
    public string uv;     //紫外线
    public string fengSu;
    public string fengli;
    public string shiDu;
    public string pm25;
    public string pm10;
    public string weak;
}

public class weatherpather : MonoBehaviour {

    public static weatherpather Instance;

    public WeatherData weatherData = new WeatherData();
    public WeatherData weatherData2 = new WeatherData();
    public WeatherData weatherData3 = new WeatherData();
    public WeatherData weatherData4 = new WeatherData();
    public WeatherData weatherData5 = new WeatherData();

    private bool IsDown1 = false;
    private bool IsDown2 = false;
    public bool IsDownOver()
    {
        if (IsDown1 && IsDown2)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
		StartCoroutine (LoadXml());
        StartCoroutine (LoadXml_1());
	}





    IEnumerator LoadXml_1()
    {
        string url = "http://www.sojson.com/open/api/weather/xml.shtml?city=%E4%B8%8A%E6%B5%B7";
        WWW www = new WWW(url);
        yield return www;
        if (www.isDone)
        {
            IsDown1 = true;
            //创建xml文档
            XmlDocument xml = new XmlDocument();
            XmlReaderSettings set = new XmlReaderSettings();
            set.IgnoreComments = true;//这个设置是忽略xml注释文档的影响。有时候注释会影响到xml的读取

            StringReader stream = new StringReader(www.text);
            xml.Load(stream);
            //得到objects节点下的所有子节点
            XmlNodeList xmlNodeList = xml.SelectSingleNode("resp").ChildNodes;
            foreach (XmlElement xe in xmlNodeList)
            {
                if (xe.Name == "environment")
                {
                    foreach (XmlElement xe2 in xe.ChildNodes)
                    {
                        Debug.Log(xe2.Name);
                        if (xe2.Name == "pm25") //pm25
                        {
                            weatherData.pm25 = xe2.InnerText;
                        }
                        if (xe2.Name == "pm10")  //pm10
                        {
                            weatherData.pm10 = xe2.InnerText;
                        }
                    }
                }
                if (xe.Name == "fengli") //风力
                {
                    weatherData.fengli = xe.InnerText;
                }
                if (xe.Name == "wendu") //温度
                {
                    weatherData.tgd = xe.InnerText;
                }
                

                if (xe.Name == "fengxiang") //风向
                {
                    weatherData.fengSu = xe.InnerText;
                   // Debug.LogError("fengxiang :" + xe.InnerText);
                }
                if (xe.Name == "shidu")  //湿度
                {
                    weatherData.shiDu = xe.InnerText;
                   // Debug.LogError("shidu:" + xe.InnerText);
                }

                if (xe.Name == "forecast")
                {
                    int i = 1;
                    foreach (XmlElement xe2 in xe.ChildNodes)
                    {
                        string date = "";
                        string high = "";
                        string low = "";
                        string type = "";
                        if (xe2.Name == "weather")
                        {

                            foreach (XmlElement xe3 in xe2.ChildNodes)
                            {
                               if (xe3.Name == "date")
                               {
                                   date = xe3.InnerText;
                                   Debug.LogError(date);
                              //     Debug.LogError("date" + xe3.InnerText);
                               }

                               if (xe3.Name == "high")
                               {
                                   high = xe3.InnerText;
                              //     Debug.LogError("high" + xe3.InnerText);
                               }

                               if (xe3.Name == "low")
                               {
                                   low = xe3.InnerText;
                              //     Debug.LogError("low" + xe3.InnerText);
                               }
                               if (xe3.Name == "day")
                               {
                                   foreach (XmlElement xe4 in xe3.ChildNodes)
                                   {
                                       if (xe4.Name == "type")
                                       {
                                           type = xe4.InnerText;
                                           Debug.LogError("type" + xe4.InnerText);
                                       }
                                   }
                               }
                              
                            }

                        }
                        
                        if (i == 1)
                        {
                            weatherData.tgd1 = high;
                            weatherData.tgd2 = low;
                            weatherData.weak = date;
                            weatherData.weather = type;
                        }
                        else if (i == 2)
                        {
                            weatherData2.tgd1 = high;
                            weatherData2.tgd2 = low;
                            weatherData2.weak = date;
                            weatherData2.weather = type;
                        }
                        else if (i == 3)
                        {
                            weatherData3.tgd1 = high;
                            weatherData3.tgd2 = low;
                            weatherData3.weak = date;
                            weatherData3.weather = type;
                        }
                        else if (i == 4)
                        {
                            weatherData4.tgd1 = high;
                            weatherData4.tgd2 = low;
                            weatherData4.weak = date;
                            weatherData4.weather = type;
                        }
                        else if (i == 5)
                        {
                            weatherData5.tgd1 = high;
                            weatherData5.tgd2 = low;
                            weatherData5.weak = date;
                            weatherData5.weather = type;
                        }
                        Debug.LogError("i :" + i);
                        i++;
                    }
                }
            }
        }
    }

	IEnumerator LoadXml()
	{                                                     
		string url = "http://php.weather.sina.com.cn/xml.php?city=%C4%CF%B2%FD&password=DJOYnieT8234jlsK&day=1";
		WWW www = new WWW (url);
		yield return www;
		if (www.isDone) {
            IsDown2 = true;
			//创建xml文档
			XmlDocument xml = new XmlDocument ();
			XmlReaderSettings set = new XmlReaderSettings ();
			set.IgnoreComments = true;//这个设置是忽略xml注释文档的影响。有时候注释会影响到xml的读取

			StringReader stream = new StringReader(www.text);
			xml.Load (stream);
			//得到objects节点下的所有子节点
			XmlNodeList xmlNodeList = xml.SelectSingleNode ("Profiles").ChildNodes;
			foreach (XmlElement  xe in xmlNodeList) {

                foreach (XmlElement xe2 in xe.ChildNodes)
                {
                    if (xe2.Name == "savedate_weather")  //日期
                    {
                        weatherData.time = xe2.InnerText;
                    }

                    if (xe2.Name == "pollution")  //紫外线指数
                    {
                        weatherData.uv = xe2.InnerText;
                     //   Debug.LogError(xe2.InnerText);
                    }


                }
			}
		}

	
	
	}
}
