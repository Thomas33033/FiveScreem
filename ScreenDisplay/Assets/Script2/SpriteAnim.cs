using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpriteAnim : MonoBehaviour {
    public List<Sprite> sprites;
    public Image image;
    public float delayTime = 1;
    private float endTime;
    private int index = 0;
     
	// Use this for initialization
    void Awake()
    {
        endTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time - endTime > delayTime)
        {
            endTime = Time.time;
            index++;
            image.sprite = sprites[index % sprites.Count];
        }
	}
}
