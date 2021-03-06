using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// attach this to a UI element to make it a droppable, additionally tag the object "Seat" to let draggable item to find it;
/// overriding the functions, or implement a new IDroppable class from scratch if you want other dropping behaviors.
/// </summary>
public class DroppablePhysics : MonoBehaviour, IDroppable {

    private GameObject currentItem = null;
    private RectTransform myTransform;

    [SerializeField] private string myLayer;

    
    public virtual GameObject GetCurrentItem() {
        return currentItem;
    }


    public virtual bool IsOccupied() {
        return currentItem != null;
    }


    public virtual void Start() {
        myTransform = gameObject.GetComponent<RectTransform>();
    }


    public virtual void ItemCame(GameObject item) {
        currentItem = item;

        // group under my hierarchy
        item.transform.SetParent(transform);
        item.transform.localScale = new Vector3(1, 1, 1);

        // move to my center / if you read this be notified there are mutliple ways of handling "where to put it"
        RectTransform itemTransform = item.GetComponent<RectTransform>();

        // don't use stretch anchor for this one
        itemTransform.anchoredPosition = new Vector2(
            (0.5f - itemTransform.anchorMax.x) * myTransform.sizeDelta.x,
            (0.5f - itemTransform.anchorMax.y) * myTransform.sizeDelta.y
        );
    }


    public virtual void ItemLeft(GameObject item) {
        // release the item from this object's hierarchy
        item.transform.SetParent(JohnnyUITools.GetMyCanvas(gameObject).transform);

        currentItem = null;
    }


    public virtual string GetLayer() {
        return myLayer;
    }
}
