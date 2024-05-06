using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    private GameObject Canvas;
    private GameObject zoomCard;
    private GameObject padre;//gameObjecte en la escena 
    /*public GameObject ZoomCard
    {
        get { return zoomCard; }
        set { zoomCard = value; }
    }
     public GameObject zoomCard;
    public GameObject ZoomCard
    {
        get { return zoomCard; }
        set { zoomCard = value; }
    }*/

    private Vector2 zoomScale = new Vector2(2, 3);

    public void Awake()
    {
        //Canvas = GameObject.Find("Main Canvas");
        padre = GameObject.Find("ZoomCard");
    }
    public void OnHoverEnter()
    {
        zoomCard = Instantiate(gameObject, new Vector2(100,500),Quaternion.identity);
        zoomCard.transform.SetParent(padre.transform);
        zoomCard.transform.localScale = zoomScale;
        //zoomCard.SetParent()
    }
    public void OnHoverExit()
    {
        Destroy(zoomCard);

    }
}
