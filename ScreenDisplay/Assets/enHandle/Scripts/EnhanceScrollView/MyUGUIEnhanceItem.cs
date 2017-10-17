using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MyUGUIEnhanceItem : EnhanceItem,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Button uButton;
    private RawImage rawImage;

    public bool IsGray = false;

    private void OnClickUGUIButton()
    {
      //  OnClickEnhanceItem();
    }

    // Set the item "depth" 2d or 3d
    //protected override void SetItemDepth(float depthCurveValue, int depthFactor, float itemCount)
    //{
    //    int curDepth = (int)(depthCurveValue * itemCount);
    //   // this.transform.SetSiblingIndex(curDepth);
    //    this.GetComponent<RectTransform>().SetSiblingIndex(curDepth);
    //}

    public override void SetSelectColor(bool isCenter)
    {
        if (IsGray)
        {
            if (rawImage == null)
                rawImage = this.GetComponent<RawImage>();
            rawImage.color = isCenter ? Color.white : Color.gray;
        }
    }
    private float curX;
    public void OnBeginDrag(PointerEventData eventData)
    {
        curX = eventData.delta.x;
    }

    public void OnDrag(PointerEventData eventData)
    {
        parent.horizontalTargetValue += eventData.delta.x * 0.001f;
       // parent.GetMoveCurveFactorCount(eventData.delta.x);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //if (eventData.delta.x < curX)
        //{
        //    parent.OnBtnRightClick();
        //}
        //else
        //{
        //    parent.OnBtnLeftClick();
        //}
    }
}
