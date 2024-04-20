using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    public GameObject CARD;
    public List<GameObject> CartasEnZona = new List<GameObject>();
    public int suma = 0;
    void Start()
    {

    }
    public int SumarPuntos()
    { 
        foreach (GameObject item in CartasEnZona)
        {
                int puntos = item.GetComponent<cardDisplay>().card.Damage;
                suma+=puntos;
        }
        return suma ;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        CARD = collision.gameObject;
        CartasEnZona.Add(CARD);
        suma += CARD.GetComponent<cardDisplay>().card.Damage;
    }
         void OnCollisionExit2D(Collision2D collision)
    {
        // Quita la carta si ya no esta colisionando 
        if (CartasEnZona.Contains(collision.gameObject))
        {
            CARD = collision.gameObject;
            CartasEnZona.Remove(CARD);
           suma -= CARD.GetComponent<cardDisplay>().card.Damage;
        }
    }

    
}