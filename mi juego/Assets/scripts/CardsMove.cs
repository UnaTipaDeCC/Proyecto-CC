using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class CardsMove : MonoBehaviour
{
    public GameObject Zone;
     public GameObject Card;
     public Card CardInfo;
     public GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    public void OnClick()
    {
        //comprueba que la carta no haya sido movida ya y la zona a la que debe moverse
        if(CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Melee && CardInfo.faccion == global::Card.Faccion.Hormigas_Bravas)
        {
             if(gameManager.IsPlayerOneTurn )
             {
             Zone = GameObject.Find("MeleeZone");
             Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
             Card.transform.position = Zone.transform.position;
             gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
             Debug.Log("cambie el turno");
             }
             else 
             {   
               //Zone = GameObject.Find("Hand");
                Debug.Log("no es tu turno");
             }  
        }
       
       else if(CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Ranged && CardInfo.faccion == global::Card.Faccion.Hormigas_Bravas)
        {
            if(gameManager.IsPlayerOneTurn)
            {
            Zone = GameObject.Find("RangedZone");
            gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
            Debug.Log("cambie el turno");
            Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
            Card.transform.position = Zone.transform.position;
            }
            else
            {
               //Zone = GameObject.Find("Hand");
                Debug.Log("no es tu turno");
            }
        
        }
        else if(CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Siege && CardInfo.faccion == global::Card.Faccion.Hormigas_Bravas)
        {
            if(gameManager.IsPlayerOneTurn)
            {   
                Zone = GameObject.Find("SiegeZone");
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
                Debug.Log("cambie el turno");
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
            }
            else
            {
                Debug.Log("no es tu turno");
            }

        }
        else if(CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Melee && CardInfo.faccion == global::Card.Faccion.Hormigas_Locas)
        {
            if(!gameManager.IsPlayerOneTurn) 
            {
            Zone = GameObject.Find("MeleeZone (1)");
            gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
            Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
            Debug.Log("cambie el turno");  
            }
            else
            {
                Debug.Log("no es tu turno");
            }                 
        }
        else if( CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Ranged && CardInfo.faccion == global::Card.Faccion.Hormigas_Locas)
        {
            if(!gameManager.IsPlayerOneTurn)
            {
                Zone = GameObject.Find("RangedZone (1)");
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;       
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
                Debug.Log("cambie el turno");   
            }
            else
            {
                Debug.Log("no es tu turno");
            }   
            
        
        }
        else if(CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Siege && CardInfo.faccion == global::Card.Faccion.Hormigas_Locas)
        {
            if(!gameManager.IsPlayerOneTurn)
            {
                Zone = GameObject.Find("SiegeZone (1)");
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position; 
                Debug.Log("cambie el turno");
            }
            else
            {
                Debug.Log("no es tu turno");
            }    
        }

        //Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
        //Card.transform.position = Zone.transform.position;

    }
    
}
