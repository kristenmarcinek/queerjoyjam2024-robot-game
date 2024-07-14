using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BodyPartSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        
        if (eventData.pointerDrag != null)
        { 
            Debug.Log("OnDrop");
            // Set the parent of the dragged item to the slot object
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.transform.SetAsLastSibling();
        }
        else
        {
            Debug.Log("eventData.pointerDrag is null");
            return;
        }   
    }
}
