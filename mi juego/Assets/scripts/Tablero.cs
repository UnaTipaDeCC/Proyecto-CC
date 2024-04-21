using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    public GameObject CARD;
    public List<GameObject> CartasEnZona = new List<GameObject>();
    public int suma = 0;
    private GameManager gameManager;
    void Start()
    {
       gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    /*public int SumarPuntos()
    { 
        foreach (GameObject item in CartasEnZona)
        {
                int puntos = item.GetComponent<cardDisplay>().card.Damage;
                suma+=puntos;
        }
        return suma ;
    }*/


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //agrega a la lista la carta cuando colisiona y agrega al contador el poder de la misma
        CARD = collision.gameObject;
        CartasEnZona.Add(CARD);
        if(CARD.GetComponent<cardDisplay>().card.tipoDeCarta == Card.TipoDeCarta.silver && gameManager.meleeClimaOn == true && CARD.GetComponent<cardDisplay>().card.tipoDeAtaque == Card.TipoDeAtaque.Melee)
        {
            CARD.GetComponent<cardDisplay>().card.Damage -= 1; 
            CARD.GetComponent<cardDisplay>().card.AfectadaPorUnClima = true;
        }
        if(CARD.GetComponent<cardDisplay>().card.tipoDeCarta == Card.TipoDeCarta.silver && gameManager.siegeClimaOn == true && CARD.GetComponent<cardDisplay>().card.tipoDeAtaque == Card.TipoDeAtaque.Siege)
        {
            CARD.GetComponent<cardDisplay>().card.Damage -= 1; 
            CARD.GetComponent<cardDisplay>().card.AfectadaPorUnClima = true;
        }
        if(CARD.GetComponent<cardDisplay>().card.tipoDeCarta == Card.TipoDeCarta.silver && gameManager.rangedClimaOn == true && CARD.GetComponent<cardDisplay>().card.tipoDeAtaque == Card.TipoDeAtaque.Ranged)
        {
            CARD.GetComponent<cardDisplay>().card.Damage -= 1; 
            CARD.GetComponent<cardDisplay>().card.AfectadaPorUnClima = true;
        } 
        suma += CARD.GetComponent<cardDisplay>().card.Damage;
    }
    private void OnCollisionExit2D(Collision2D collision)
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