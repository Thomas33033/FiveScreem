using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherIcon : MonoBehaviour {
    public List<Sprite> spriteList;
    public List<string> strList;

    public static WeatherIcon Instance;
    void Awake()
    {
        Instance = this;
    }

    public Sprite GetSprite(string name)
    {
        for (int i = 0; i < strList.Count; i++)
        {
            if (strList[i] == name)
            {
                return spriteList[i];
            }
        }
        return spriteList[0];
    }
}
