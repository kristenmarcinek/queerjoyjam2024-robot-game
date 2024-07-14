using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeadController : BodyPartSlot, IDropHandler
{
    public override void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag.CompareTag("Hat"))
        {
            base.OnDrop(eventData);
            Debug.Log("OnDrop on Head");
        }

        else
        {
            Debug.Log("Not a hat or hair");
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            return;
        }
    }
}
