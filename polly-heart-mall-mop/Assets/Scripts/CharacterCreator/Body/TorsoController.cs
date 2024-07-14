using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TorsoController : BodyPartSlot, IDropHandler
{
    public override void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag.CompareTag("Shirt"))
        {
            base.OnDrop(eventData);
            Debug.Log("OnDrop on Torso");
        }

        else
        {
            Debug.Log("Not a shirt");
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            return;
        }
    }
}
