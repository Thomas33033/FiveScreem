using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using System.IO;
public class GameTools : MonoBehaviour
{
    private static GameTools mInstance;
    public static GameTools Instance
    {
        get
        {
            if (mInstance == null)
            {
                GameObject go = new GameObject();
               GameTools gt = go.AddComponent<GameTools>();
               mInstance = gt;
            }
            return mInstance;
        }
    }
    public static Dictionary<string, Texture2D> fileDic = new Dictionary<string, Texture2D>();

    void Awake()
    {
    }

    public static void AddClickEvent(GameObject go, Action action)
    {
        Button btn = go.gameObject.GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(delegate()
            {
                if (action != null)
                {
                    action();
                }
            });
        }
        else
        {
            EventTriggerListener etl = EventTriggerListener.Get(go);
            etl.onClick = (gameObject) =>
            {
                action();
            };
        }
    }

    public void LoadImage(Image image, string name,int width,int height)
    {
        StartCoroutine(LoadImage(name, image));
    }

    public void LoadRawImage(RawImage image, string name, int width, int height)
    {
        StartCoroutine(LoadRawImage(name, image));
    }

    IEnumerator LoadRawImage(string fileName, RawImage image)
    {
        string path = DataMgr.FilePath + fileName;
        path = path.Replace("\\", "");
        if (!File.Exists(path))
        {
            Debug.LogError("文件不存在:"+path);
            yield break;
        }
        path = "file://" + path;
        byte[] bytes = null;
        Texture2D texture;
        if (fileDic.TryGetValue(path, out texture))
        {
            image.texture = texture;
        }
        else
        {
           
            WWW www = new WWW(path);
            yield return www;
            if (www.isDone)
            {
                bytes = www.bytes;
                texture = new Texture2D(4, 4, TextureFormat.ARGB32, false);
                texture.LoadImage(bytes);
                image.texture = texture;
                if (!fileDic.ContainsKey(path))
                {
                    fileDic.Add(path, texture);
                }
                
            }
        }
        yield return null;
    }

    IEnumerator LoadImage(string fileName, Image image)
    {
        fileName = fileName.Replace("\"", "");
        string path = DataMgr.FilePath + fileName;
        path = path.Replace("\\","");
        if (!File.Exists(path))
        {
            Debug.LogError("文件不存在:" + path);
            yield break;
        }
        path = "file://" + path;
        Debug.LogError(path);
        byte[] bytes = null;
        Texture2D texture;
        if (fileDic.TryGetValue(path, out texture))
        {
            image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));
        }
        else
        {
            WWW www = new WWW(path);
            yield return www;
            if (www.isDone)
            {
                bytes = www.bytes;
                texture = new Texture2D(4, 4, TextureFormat.ARGB32, false);
                texture.LoadImage(bytes);
                image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                    new Vector2(0.5f, 0.5f));
                if (!fileDic.ContainsKey(path))
                {
                    fileDic.Add(path, texture);
                }
            }
        }
        yield return null;
    }
}

public class EventTriggerListener : UnityEngine.EventSystems.EventTrigger
{
    public delegate void VoidDelegate(GameObject go);
    public VoidDelegate onClick;
    public VoidDelegate onDown;
    public VoidDelegate onEnter;
    public VoidDelegate onExit;
    public VoidDelegate onUp;
    public VoidDelegate onSelect;
    public VoidDelegate onUpdateSelect;

    static public EventTriggerListener Get(GameObject go)
    {
        EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
        if (listener == null) listener = go.AddComponent<EventTriggerListener>();
        return listener;
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onClick != null) onClick(gameObject);
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (onDown != null) onDown(gameObject);
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (onEnter != null) onEnter(gameObject);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (onExit != null) onExit(gameObject);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (onUp != null) onUp(gameObject);
    }
    public override void OnSelect(BaseEventData eventData)
    {
        if (onSelect != null) onSelect(gameObject);
    }
    public override void OnUpdateSelected(BaseEventData eventData)
    {
        if (onUpdateSelect != null) onUpdateSelect(gameObject);
    }
}