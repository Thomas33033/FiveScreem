using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Page_5_3_Item : MonoBehaviour {
    public Text text_week;
    public Text text_time;
    public Image Image_weather;
    public Text txt_temperature_max;
    public Text txt_temperature_min;
    public GameObject group;
    public RectTransform img_dot1;
    public RectTransform img_dot2;

    public void InitData(WeatherData data)
    {
        text_week.text = data.weak;
        if (text_week.text.Split('日').Length == 2)
        {
            text_week.text = text_week.text.Split('日')[1];
        }
        string weather1 = "";
        float tgd1 = GetCurTmp(data.tgd1, ref weather1);

        string weather2 = "";
        float tgd2 = GetCurTmp(data.tgd2, ref weather2);

        txt_temperature_max.text = tgd1+"";
        txt_temperature_min.text = tgd2+"";
        text_time.text = data.weather;

        Image_weather.sprite = WeatherIcon.Instance.GetSprite(data.weather);

        string weather3 = "";
        float t_tgd1 = GetCurTmp(weatherpather.Instance.weatherData.tgd1, ref weather1);

        string weather4 = "";
        float t_tgd2 = GetCurTmp(weatherpather.Instance.weatherData.tgd2, ref weather2);

        Debug.LogError((t_tgd1 - tgd1) + " " + (t_tgd2 - tgd2));

        float rate = 1;
        if (Mathf.Abs(t_tgd1 - tgd1) > 40)
        {
            rate = 1;
        }
        else if (Mathf.Abs(t_tgd1 - tgd1) < 2)
        {
            rate = 10;
        }
        else if (Mathf.Abs(t_tgd1 - tgd1) < 3)
        {
            rate = 6;
        }
        else if (Mathf.Abs(t_tgd1 - tgd1) < 4)
        {
            rate = 5;
        }
        else if (Mathf.Abs(t_tgd1 - tgd1) < 5)
        {
            rate = 8;
        }
        else if (Mathf.Abs(t_tgd1 - tgd1) < 10)
        {
            rate = 2;
        }
        float dis = (t_tgd1 - tgd1)*5;
        img_dot1.anchoredPosition -= new Vector2(0, dis);
        img_dot2.anchoredPosition -= new Vector2(0, dis);


    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private float GetCurTmp(string str,ref string weather)
    {
        string[] array = str.Split(' ');
        weather = array[0];
        string[] array11 = array[1].Split('℃');
        float tgd1 = float.Parse(array11[0]);
        return tgd1;
    }
}
