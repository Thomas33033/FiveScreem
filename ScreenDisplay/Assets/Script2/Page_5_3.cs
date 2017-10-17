using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page_5_3 : MonoBehaviour {
    public Button backBtn;
    public Image image_tianqi;
    public Text txt_tianqi;
    public Text txt_wendu;
    public Text txt_time;
    public Text txt_Month;
    public Text txt_week;

    public Text txt_shidu;
    public Text txt_pm;
    public Text txt_fengsu;
    public Text txt_pm10;

    public Text txt_UV;

    public List<Page_5_3_Item> itemList;

    public List<Line> list = new List<Line>();

    void Awake()
    {
        txt_tianqi.text = "";
        txt_wendu.text = "";
        txt_time.text = "";
        txt_Month.text = "";
        txt_week.text = "";
        txt_shidu.text = "";
        txt_pm.text = "";
        txt_fengsu.text = "";
        txt_pm10.text = "";
        txt_UV.text = "";
    }

	// Use this for initialization
	void Start () {
        foreach (var v in list)
        {
            v.gameObject.SetActive(false);
        }
        GameTools.AddClickEvent(backBtn.gameObject, this.backButton_ClickEvent);
       
	}
	
	// Update is called once per frame
    void backButton_ClickEvent()
    {
        UIMgr.ShowUI<ScreenPage_5>("Page_5", this.transform.parent.gameObject);
        UIMgr.Delete<Page_5_3>(this);
    }

    private bool Init = false;
    void Update()
    {
        if (!Init && weatherpather.Instance != null && weatherpather.Instance.IsDownOver())
        {
            txt_tianqi.text = weatherpather.Instance.weatherData.weather;
            txt_wendu.text = weatherpather.Instance.weatherData.tgd;
            txt_time.text = weatherpather.Instance.weatherData.time;
            txt_week.text = weatherpather.Instance.weatherData.weak;
            if (txt_week.text.Split('日').Length == 2)
            {
                txt_week.text = txt_week.text.Split('日')[1];
            }
            string[] array = txt_time.text.Split('-');
            if (array.Length == 3)
            {
                txt_time.text = array[0] + "年" + array[1] + "月" + array[2];
            }
            txt_Month.text = "";
            image_tianqi.sprite = WeatherIcon.Instance.GetSprite(txt_tianqi.text);

            txt_shidu.text = weatherpather.Instance.weatherData.shiDu;
            txt_pm.text = weatherpather.Instance.weatherData.pm25;
            txt_fengsu.text = weatherpather.Instance.weatherData.fengSu + " " + weatherpather.Instance.weatherData.fengli;
            txt_pm10.text = weatherpather.Instance.weatherData.pm10;
            txt_UV.text = weatherpather.Instance.weatherData.uv;

            for (int i = 0; i < itemList.Count; i++)
            {

                switch (i)
                {
                    case 0:
                        itemList[0].InitData(weatherpather.Instance.weatherData);
                        break;
                    case 1:
                        itemList[1].InitData(weatherpather.Instance.weatherData2);
                        break;
                    case 2:
                        itemList[2].InitData(weatherpather.Instance.weatherData3);
                        break;
                    case 3:
                        itemList[3].InitData(weatherpather.Instance.weatherData4);
                        break;
                    case 4:
                        itemList[4].InitData(weatherpather.Instance.weatherData5);
                        break;
                }
            }
            StartCoroutine("delayDo");
            Init = true;
        }
    }

    IEnumerator delayDo()
    {
        yield return new WaitForSeconds(3);
        foreach (var v in list)
        {
            v.gameObject.SetActive(true);
            yield return null;
            v.Refresh();
        }
    }
}
