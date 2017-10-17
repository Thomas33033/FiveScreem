using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Line : MonoBehaviour {

    public RectTransform obj1;
    public RectTransform obj2;
    public Image Image;
	// Use this for initialization
	void FixedUpdate () {
        Refresh();
        
	}
    float lastRotation = -1;
    public void Refresh()
    {
        if (lastRotation == Image.transform.localEulerAngles.z)
            return;
        Image.transform.position = obj1.position;
        Vector2 sp1 = RectTransformUtility.WorldToScreenPoint(Camera.main, obj1.position);
        Vector2 sp2 = RectTransformUtility.WorldToScreenPoint(Camera.main, obj2.position);
        float distance = Vector2.Distance(sp1, sp2)/0.85f;
        Vector2 dir = (sp1 - sp2).normalized;

        float angle = Vector3.Angle(dir, new Vector2(-1, 0));
 
        if (dir.y > 0)
        {
            angle = 360 - angle;
        }
        Image.transform.localEulerAngles = new Vector3(0, 0, angle);
        Image.GetComponent<RectTransform>().sizeDelta = new Vector2(distance, 2);
        
    }
	
	
}
