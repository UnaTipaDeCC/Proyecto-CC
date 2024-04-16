using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{ 
   public GameObject Canvas;
   public bool IsDragging = false;
   public bool IsOverDropZone = false;
   public GameObject Zone;// MeleeZone;
   private GameObject startParent;//esto es nuevo
   public Vector2 startPosition;

    private void Awake()//para que se me vea super arriba en la pantalla y no por debajo de las zonas y eso sin importar la jerarquia
    {
        Canvas = GameObject.Find("Main Canvas");
    } 
    void Update()
    {
        if(IsDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);// para q se me actualice lo de arriba 
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsOverDropZone = true;
        //MeleeZone = collision.gameObject;
        Zone = collision.gameObject;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        IsOverDropZone = false;
        Zone = null;
        //MeleeZone = null;
    }
    public void StartDrag()
    {
        startParent = transform.parent.gameObject;//new
        startPosition = transform.position;
        IsDragging = true;
    }
    public void EndDrag()
    {
        IsDragging = false;
        if(IsOverDropZone)
        {
            transform.SetParent(Zone.transform, false);
            //transform.SetParent(MeleeZone.transform, false);
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);//new
        }
    }
}
