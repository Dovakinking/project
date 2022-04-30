using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCamera : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

	void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
	{
		WorldMap.MapBeginDrag(eventData.position);
	}

	void IDragHandler.OnDrag(PointerEventData eventData)
	{
		WorldMap.MapDrag(eventData.position, eventData.delta);
	}

	void IEndDragHandler.OnEndDrag(PointerEventData eventData)
	{
		WorldMap.MapEndDrag();
	}
}