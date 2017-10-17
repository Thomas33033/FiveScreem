using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Page_5_4_Item : MonoBehaviour {
    public Image image;
    public Text text;
    public Image playImage;
    public Image fullImage;
    private videoData mVideoData;
    public Page_5_4 page_5_4;
    private bool isPlay = false;
    private float startTime;
    private float endTime;
	// Use this for initialization
	void Start () {
        GameTools.AddClickEvent(playImage.gameObject, this.PlayVideo_ClickEvent);
	}
	
	public void InitData(videoData data,int index)
    {
        text.text = data.videName;
        mVideoData = data;
        endTime = Time.time + index * 0.2f;
        isPlay = true;
        if (data.full == "1")
        {
            fullImage.gameObject.SetActive(true);
        }
        else
        {
            fullImage.gameObject.SetActive(false);
        }
    }

    void Update()
    { 
        if(isPlay)
        {
            if (Time.time > endTime)
            {
                delayDo();
                isPlay = false;
            }

        }
    }

    void delayDo()
    {
        GameTools.Instance.LoadImage(image, mVideoData.imagePath, 4, 4);
    }

    public void PlayVideo_ClickEvent()
    {
        string path = DataMgr.FilePath + mVideoData.videoPath;
        page_5_4.PlayVideo(path, mVideoData.full);
    }
}
