using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeZone : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public event Action<Vector2> Dragged;
    public event Action<Vector2> Touched;

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 TouchPosition = eventData.position;
        Touched?.Invoke(TouchPosition);
        
    }
    public void OnDrag(PointerEventData eventData)
    {

        Vector2 dragDelta = eventData.delta;
        Dragged?.Invoke(dragDelta);
    }


    
}
