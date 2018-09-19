using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

   
    public Transform parentToReturnTo = null;

    public static GameObject cardBeingPlayed;
    Vector3 startPosition;
    Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");

        cardBeingPlayed = this.gameObject;
        startPosition = transform.position;
        startParent = transform.parent;

        // Ensures card will either be played on hand or tabletop
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
	
    public void OnDrag(PointerEventData eventData)
    { 
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");

        // Card is either in hand or tabletop
        this.transform.SetParent(parentToReturnTo);


        // End drag 
        cardBeingPlayed = null;
        if (parentToReturnTo != startParent)
        {
            transform.position = startPosition;
        }
        
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        
    }
}
