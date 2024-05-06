using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    private GameObject Canvas;
    /*private GameObject zoomCard;
    public GameObject ZoomCard
    {
        get { return zoomCard; }
        set { zoomCard = value; }
    }*/
     public GameObject zoomCard;
    public GameObject ZoomCard
    {
        get { return zoomCard; }
        set { zoomCard = value; }
    }

    private Vector2 zoomScale = new Vector2(2, 3);

    public void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }
    public void OnHoverEnter()
    {
        zoomCard = Instantiate(gameObject, new Vector2(100,500),Quaternion.identity);
        zoomCard.transform.SetParent(Canvas.transform, false);
        zoomCard.transform.localScale = zoomScale;
    }
    public void OnHoverExit()
    {
        Destroy(zoomCard);

    }
}
