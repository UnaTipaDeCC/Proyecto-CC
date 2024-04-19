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
     private GameObject deck;
     private GameObject deck1;
     private List<GameObject> cardsinhand;
     private List<GameObject> cardsinhand1;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        deck = GameObject.FindGameObjectWithTag("Deck");//todas las cartas que estan en este deck pertenecen a la faccion hormigas bravas 
        deck1 = GameObject.FindGameObjectWithTag("Deck(1)");//todas las cartas que estan en este deck pertenecen a la faccion hormigas locas
        cardsinhand = deck.GetComponent<Draw>().CardsInHand;
        cardsinhand1 = deck1.GetComponent<Draw>().CardsInHand;
    }
    public void OnClick()
    {
        
        if(gameManager.playerOnePassed == false)//comprueba que el jugador uno no se haya pasado
        {
        //la zona a la que debe moverse
        if(CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Melee && CardInfo.faccion == global::Card.Faccion.Hormigas_Bravas)
        {
             if(gameManager.IsPlayerOneTurn && CardInfo.jugada == false)//comprueba que sea el turno del jugador uno y que la carta no haya sido jugada
             {
                Zone = GameObject.Find("MeleeZone");
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
                cardsinhand.Remove(Card);//remueve la carta de la mano 
                Debug.Log("quite de la lista");
                CardInfo.jugada = true;//actualizar que ya se jugo
                Debug.Log(CardInfo.jugada);
                if(gameManager.playerTwoPassed == false) //comprueba que el otro jugador no se haya pasado y en ese caso cambia el turno
                {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
                Debug.Log("cambie el turno");
                }
             }
             else 
             {   
                Debug.Log("no es tu turno o ya estas en la mesa");
             }  
        }
       
       else if(CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Ranged && CardInfo.faccion == global::Card.Faccion.Hormigas_Bravas)
        {
            if(gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
            {
            Zone = GameObject.Find("RangedZone");
            Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
            Card.transform.position = Zone.transform.position;
            cardsinhand.Remove(Card);
            CardInfo.jugada = true;
            Debug.Log(CardInfo.jugada);
            if(gameManager.playerTwoPassed == false) //comprueba que el otro jugador no se haya pasado y en ese caso cambia el turno
            {
            gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
            Debug.Log("cambie el turno");
            }
            }
            else
            {
                Debug.Log("no es tu turno o ya esta en la mesa");
            }
        
        }
        else if(CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Siege && CardInfo.faccion == global::Card.Faccion.Hormigas_Bravas)
        {
            if(gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
            {   
                Zone = GameObject.Find("SiegeZone");
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
                cardsinhand.Remove(Card);
                CardInfo.jugada = true;
                Debug.Log(CardInfo.jugada);
                if(gameManager.playerTwoPassed == false) //comprueba que el otro jugador no se haya pasado y en ese caso cambia el turno
                {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
                Debug.Log("cambie el turno");
                }
            }
            else
            {
                Debug.Log("no es tu turno o ya esta en la mesa");
            }

        }
        }

        if(gameManager.playerTwoPassed == false)//comprueba que el jugador no se haya pasado
        {
             if(CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Melee && CardInfo.faccion == global::Card.Faccion.Hormigas_Locas)
            {
                if(!gameManager.IsPlayerOneTurn && CardInfo.jugada == false)//comprueba que sea el turno del jugador 2
                {
                    Zone = GameObject.Find("MeleeZone (1)");
                    Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                    Card.transform.position = Zone.transform.position;
                    cardsinhand1.Remove(Card);
                    CardInfo.jugada = true;
                    Debug.Log(CardInfo.jugada);
                    if(gameManager.playerOnePassed == false) //comprueba que el otro jugador no se haya pasado y en ese caso cambia el turno
                    {
                    gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
                    Debug.Log("cambie el turno"); 
                    }
                
                }
                else
                {
                    Debug.Log("no es tu turno o ya esta en la mesa");
                }                 
            }
        else if( CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Ranged && CardInfo.faccion == global::Card.Faccion.Hormigas_Locas)
        {
            if(!gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
            {
                Zone = GameObject.Find("RangedZone (1)");  
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
                cardsinhand1.Remove(Card);
                CardInfo.jugada = true;
                Debug.Log(CardInfo.jugada);
                if(gameManager.playerOnePassed == false) //comprueba que el otro jugador no se haya pasado y en ese caso cambia el turno
                {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
                Debug.Log("cambie el turno");   
                }     
            }
            else
            {
                Debug.Log("no es tu turno o ya esta en la mesa");
            }   
            
        
        }
        else if(CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Siege && CardInfo.faccion == global::Card.Faccion.Hormigas_Locas)
        {
            if(!gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
            {
                Zone = GameObject.Find("SiegeZone (1)");
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position; 
                cardsinhand1.Remove(Card);
                CardInfo.jugada = true;
                Debug.Log(CardInfo.jugada);
                if(gameManager.playerOnePassed == false) //comprueba que el otro jugador no se haya pasado y en ese caso cambia el turno
                {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
                Debug.Log("cambie el turno");
                }
            }
            else
            {
                Debug.Log("no es tu turno o ya esta en la mesa");
            }    
        }
        }
    }
    
}
