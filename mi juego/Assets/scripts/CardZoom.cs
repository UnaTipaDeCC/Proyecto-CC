using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject zoomCard;
    public void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }
    public void OnHoverEnter()
    {
        zoomCard = Instantiate(gameObject, new Vector2(Input.mousePosition.x, Input.mousePosition.y + 250),Quaternion.identity);
        zoomCard.transform.SetParent(Canvas.transform, false);
        zoomCard.layer = LayerMask.NameToLayer("Zoom");
        RectTransform rect = zoomCard.GetComponent<RectTransform>();
        rect.transform.localScale = new Vector2(2,2);
        rect.sizeDelta = new Vector2(200,200);
    }
    public void OnHoverExit()
    {
        Destroy(zoomCard);

    }
}
