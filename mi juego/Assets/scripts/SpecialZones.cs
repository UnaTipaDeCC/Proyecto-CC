using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialZones : MonoBehaviour
{
    private GameObject CARD;
    public List<GameObject> CartasEnZona;
     private void OnCollisionEnter2D(Collision2D collision)
    {
        
        CARD = collision.gameObject;
        CartasEnZona.Add(CARD);
    }
         void OnCollisionExit2D(Collision2D collision)
    {
        // Quita la carta si ya no esta colisionando 
        if (CartasEnZona.Contains(collision.gameObject))
        {
            CARD = collision.gameObject;
            CartasEnZona.Remove(CARD);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
