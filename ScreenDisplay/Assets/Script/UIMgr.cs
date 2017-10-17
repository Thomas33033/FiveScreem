using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr  {

    public static Dictionary<System.Type, GameObject> pageDic = new Dictionary<System.Type, GameObject>();


    public static T ShowUI<T>(string name, GameObject parent) where T : MonoBehaviour
    {
        GameObject go = GameObject.Instantiate(Resources.Load(name),parent.transform) as GameObject;
        T t = go.GetComponent<T>();
        pageDic.Remove(t.GetType());
        pageDic.Add(t.GetType(), go);
        return t;
    }

    public static void Delete<T>(T t) where T : MonoBehaviour
    { 
        GameObject go ;
        if (pageDic.TryGetValue(t.GetType(),out go))
        {
            if (go != null)
            {
                GameObject.Destroy(go.gameObject);
            }
            pageDic.Remove(t.GetType());
        }
    }

}
