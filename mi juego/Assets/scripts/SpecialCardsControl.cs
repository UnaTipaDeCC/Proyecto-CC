using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class SpecialCardsControl : MonoBehaviour
{
    public GameObject Zone;
    //public static List<GameObject> CardsInZone = new List<GameObject>();
     public GameObject Card;
     public SpecialCards CardInfo;
     public GameManager gameManager;
     private GameObject melee;
     private GameObject melee1;
      private GameObject deck;
     private GameObject deck1;
     private List<GameObject> cardsinhand;
     private List<GameObject> cardsinhand1;
     private int contador = 0;
     private int contador1 = 0;
     // Lista de zonas afectadas por cartas de clima
    //private List<SpecialCards.ZonaQueAfecta> affectedZones = new List<SpecialCards.ZonaQueAfecta>();
     //List<GameObject> list;
    // Start is called before the first frame update
    void Start()
    {
      gameManager = GameObject.FindObjectOfType<GameManager>();
      deck = GameObject.FindGameObjectWithTag("Deck");
      deck1 = GameObject.FindGameObjectWithTag("Deck(1)");
      cardsinhand = deck.GetComponent<Draw>().CardsInHand;
      cardsinhand1 = deck1.GetComponent<Draw>().CardsInHand;
      melee = GameObject.FindGameObjectWithTag("MeleeZone");
      melee1 = GameObject.FindGameObjectWithTag("MeleeZone (1)");
    }
    public void OnClick()
    {
     //asigna la zona que le corresponde a cada carta segun el tipo de carta y la zona a la que afecta y controla que sea el turno del jugador en caso contrario no le asigna una zona y por ende no se mueve
        //no hace lo de las listas
        if(gameManager.playerOnePassed == false)
        {
          if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Melee && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
            if(gameManager.IsPlayerOneTurn && CardInfo.jugada == false) //&& (gameManager.MeleeClima == false))
            {
              if(gameManager.MeleeClima == false)
              {
              Zone = GameObject.Find("MeleeClima");
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
              cardsinhand.Remove(Card);
              CardInfo.jugada = true;
              //Debug.Log(CardInfo.jugada);
              Clima();
              if(gameManager.playerTwoPassed == false)//comprueba que el otro jagador no se haya pasado para cambiar el turno
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              gameManager.MeleeClima = true;
              }
              else Debug.Log("ya hay una carta clima que afecta esta zona");
              
            } 
            else Debug.Log("No es tu turno o ya hay una carta clima que afecta esta zona");       
          }
        
          if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Melee && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
            if(gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
            {
              Zone = GameObject.Find("MeleeClima");
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
              cardsinhand.Remove(Card);
              CardInfo.jugada = true;
              Debug.Log(CardInfo.jugada);
              if(gameManager.playerTwoPassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              /*if(gameManager.MeleeClimaCards.Count > 0)
              {
                Debug.Log("destrui la carta melee");
                GameObject carta = gameManager.MeleeClimaCards[0];
                gameManager.MeleeClimaCards.RemoveAt(0); 
                Destroy(carta);//ya vermos              
              }*/
            } 
            else Debug.Log("No es tu turno");       
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Ranged && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
            if(gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
            {
              if(gameManager.RangedClima == false)
              {
              Zone = GameObject.Find("RangedClima");
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
              cardsinhand.Remove(Card);
              CardInfo.jugada = true;
              Debug.Log(CardInfo.jugada);
              if(gameManager.playerTwoPassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              gameManager.RangedClima = true;
              }
              else Debug.Log("YA HAY UNA CARTA CLIMA QUE AFECTA ESTA ZONA");
            }
            else Debug.Log("No es tu turno");   
          
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Ranged && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
            if(gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
            {
              Zone = GameObject.Find("RangedClima");
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
              cardsinhand.Remove(Card);
              CardInfo.jugada = true;
              Debug.Log(CardInfo.jugada);
              if(gameManager.playerTwoPassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
            }
            else Debug.Log("No es tu turno");           
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Siege && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
              if(gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
              {
                if(gameManager.SiegeClima == false)
                {
                  gameManager.SiegeClima = true;
                Zone = GameObject.Find("SiegeClima");
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
                cardsinhand.Remove(Card);
                CardInfo.jugada = true;
                Debug.Log(CardInfo.jugada);
                if(gameManager.playerTwoPassed == false)
                {
                  gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
                }
                }
                else Debug.Log("ya hay una carta clima que afecta esta zona");
              }
              else Debug.Log("No es tu turno");
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Siege && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
              if(gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
              {
                Zone = GameObject.Find("SiegeClima");
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
                cardsinhand.Remove(Card);
                CardInfo.jugada = true;
                Debug.Log(CardInfo.jugada);
                if(gameManager.playerTwoPassed == false)
                {
                  gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
                }
              }
              else Debug.Log("No es tu turno");
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Melee && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
            if(gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
            {
              Zone = GameObject.Find("AumentoMelee");
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
              cardsinhand.Remove(Card);
              CardInfo.jugada = true;
              Debug.Log(CardInfo.jugada);
              if(gameManager.playerTwoPassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
            }  
            else Debug.Log("No es tu turno");
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Ranged && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
            if(gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
            {
              Zone = GameObject.Find("AumentoRanged");
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
              cardsinhand.Remove(Card);
              CardInfo.jugada = true;
              Debug.Log(CardInfo.jugada);
              if(gameManager.playerTwoPassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
            }
            else Debug.Log("No es tu turno");
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Siege && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
            if(gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
            {
              Zone = GameObject.Find("AumentoSiege ");
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
              cardsinhand.Remove(Card);
              CardInfo.jugada = true;
              Debug.Log(CardInfo.jugada);
              if(gameManager.playerTwoPassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
            }           
          else Debug.Log("No es tu turno");
          }
        }
        
       
        if(gameManager.playerTwoPassed == false)
        {
          if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Melee && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
            if(!gameManager.IsPlayerOneTurn && CardInfo.jugada == false) // && (gameManager.MeleeClimaCards.Count == 0))
            {
              if(gameManager.MeleeClima == false)
              {
                gameManager.MeleeClima = true;
              Zone = GameObject.Find("MeleeClima");
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
              cardsinhand1.Remove(Card);
              CardInfo.jugada = true;
              Debug.Log(CardInfo.jugada);
              if(gameManager.playerOnePassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              }
              else Debug.Log("ya hay una carta clima que afecta esta zona");
            } 
            else Debug.Log("No es tu turno");       
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Melee && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
            if(!gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
            {
              Zone = GameObject.Find("MeleeClima");
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
              cardsinhand1.Remove(Card);
              CardInfo.jugada = true;
              Debug.Log(CardInfo.jugada);
              if(gameManager.playerOnePassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
            } 
            else Debug.Log("No es tu turno");       
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Ranged && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
            if(!gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
            {
              Zone = GameObject.Find("RangedClima");
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
              cardsinhand1.Remove(Card);
              CardInfo.jugada = true;
              Debug.Log(CardInfo.jugada);
              if(gameManager.playerOnePassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
            }
            else Debug.Log("No es tu turno");           
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Ranged && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
            if(!gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
            {
              Zone = GameObject.Find("RangedClima");
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
              cardsinhand1.Remove(Card);
              CardInfo.jugada = true;
              Debug.Log(CardInfo.jugada);
              if(gameManager.playerOnePassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
            }
            else Debug.Log("No es tu turno");           
          }
          
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Siege && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
              if(!gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
              {
                Zone = GameObject.Find("SiegeClima");
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
                cardsinhand1.Remove(Card);
                CardInfo.jugada = true;
                Debug.Log(CardInfo.jugada);
                if(gameManager.playerOnePassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              }
          else Debug.Log("No es tu turno");
          }

          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Siege && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
              if(!gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
              {
                Zone = GameObject.Find("SiegeClima");
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
                cardsinhand1.Remove(Card);
                CardInfo.jugada = true;
                Debug.Log(CardInfo.jugada);
                if(gameManager.playerOnePassed == false)
                {
                  gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
                }
              }
          else Debug.Log("No es tu turno");
          }
          
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Melee && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
            if(!gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
            {
              Zone = GameObject.Find("AumentoMelee (1)");
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
              cardsinhand1.Remove(Card);
              CardInfo.jugada = true;
              Debug.Log(CardInfo.jugada);
              if(gameManager.playerOnePassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
            }  
          else Debug.Log("No es tu turno");
          }
          
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Ranged && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
            if(!gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
            { 
              Zone = GameObject.Find("AumentoRanged (1)");
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
              cardsinhand1.Remove(Card);
              CardInfo.jugada = true;
              Debug.Log(CardInfo.jugada);
              if(gameManager.playerOnePassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
            }
          else Debug.Log("No es tu turno");
          }
          
          else if( CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Siege && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
              if(!gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
              {
                Zone = GameObject.Find("AumentoSiege  (1)");
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
                cardsinhand1.Remove(Card);
                CardInfo.jugada = true;
                if(gameManager.playerOnePassed == false)
                {
                  gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
                }
              Debug.Log(CardInfo.jugada);
              }           
              else Debug.Log("No es tu turno");
          }
        }
  void Clima()
 {
    Debug.Log("estoy aqui");
    foreach(GameObject carta in melee.GetComponent<Tablero>().CartasEnZona)
    {
      if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == global::Card.TipoDeCarta.silver)
      {
        contador++;
      }
    }
    foreach(GameObject carta in melee1.GetComponent<Tablero>().CartasEnZona)
    {
      if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == global::Card.TipoDeCarta.silver)
      {
        contador++;
      }
    }
    melee.GetComponent<Tablero>().suma -= contador;
    melee1.GetComponent<Tablero>().suma -= contador1;
 }
    }
   
}
 