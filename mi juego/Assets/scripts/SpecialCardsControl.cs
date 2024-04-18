using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpecialCardsControl : MonoBehaviour
{
    public GameObject Zone;
    //public static List<GameObject> CardsInZone = new List<GameObject>();
     public GameObject Card;
     public SpecialCards CardInfo;
     public GameManager gameManager;
     // Lista de zonas afectadas por cartas de clima
    //private List<SpecialCards.ZonaQueAfecta> affectedZones = new List<SpecialCards.ZonaQueAfecta>();
     //List<GameObject> list;
    // Start is called before the first frame update
    void Start()
    {
      gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    public void OnClick()
    {
     //asigna la zona que le corresponde a cada carta segun el tipo de carta y la zona a la que afecta y controla que sea el turno del jugador en caso contrario no le asigna una zona y por ende no se mueve
        //no hace lo de las listas
        if(gameManager.playerOnePassed == false)
        {
          if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Melee && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
            if(gameManager.IsPlayerOneTurn && (gameManager.MeleeClimaCards.Count == 0))
            {
              Zone = GameObject.Find("MeleeClima");
              if(gameManager.playerTwoPassed == false)//comprueba que el otro jagador no se haya pasado para cambiar el turno
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
            } 
            else Debug.Log("No es tu turno o ya hay una carta clima que afecta esta zona");       
          }
        
          if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Melee && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
            if(gameManager.IsPlayerOneTurn)
            {
              Zone = GameObject.Find("MeleeClima");
              if(gameManager.playerTwoPassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
              if(gameManager.MeleeClimaCards.Count > 0)
              {
                Debug.Log("destrui la carta melee");
                GameObject carta = gameManager.MeleeClimaCards[0];
                gameManager.MeleeClimaCards.RemoveAt(0); 
                Destroy(carta);//ya vermos              
              }
            } 
            else Debug.Log("No es tu turno");       
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Ranged && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
            if(gameManager.IsPlayerOneTurn)
            {
              Zone = GameObject.Find("RangedClima");
              if(gameManager.playerTwoPassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
            }
            else Debug.Log("No es tu turno");   
          
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Ranged && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
            if(gameManager.IsPlayerOneTurn)
            {
              Zone = GameObject.Find("RangedClima");
              if(gameManager.playerTwoPassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
            }
            else Debug.Log("No es tu turno");           
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Siege && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
              if(gameManager.IsPlayerOneTurn)
              {
                Zone = GameObject.Find("SiegeClima");
                if(gameManager.playerTwoPassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
              }
              else Debug.Log("No es tu turno");
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Siege && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
              if(gameManager.IsPlayerOneTurn)
              {
                Zone = GameObject.Find("SiegeClima");
                if(gameManager.playerTwoPassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
              }
              else Debug.Log("No es tu turno");
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Melee && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
            if(gameManager.IsPlayerOneTurn)
            {
              Zone = GameObject.Find("AumentoMelee");
              if(gameManager.playerTwoPassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
            }  
            else Debug.Log("No es tu turno");
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Ranged && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
            if(gameManager.IsPlayerOneTurn)
            {
              Zone = GameObject.Find("AumentoRanged");
             if(gameManager.playerTwoPassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
            }
            else Debug.Log("No es tu turno");
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Siege && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
            if(gameManager.IsPlayerOneTurn)
            {
              Zone = GameObject.Find("AumentoSiege ");
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
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
            if(!gameManager.IsPlayerOneTurn  && (gameManager.MeleeClimaCards.Count == 0))
            {
              Zone = GameObject.Find("MeleeClima");
              if(gameManager.playerOnePassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
            } 
            else Debug.Log("No es tu turno o ya hay una carta clima que afecta esta zona");       
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Melee && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
            if(!gameManager.IsPlayerOneTurn)
            {
              Zone = GameObject.Find("MeleeClima");
              if(gameManager.playerOnePassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
              if(gameManager.MeleeClimaCards.Count > 0)
              {
                Debug.Log("destrui la carta melee");
                GameObject carta = gameManager.MeleeClimaCards[0];
                gameManager.MeleeClimaCards.RemoveAt(0); 
                Destroy(carta);//ya vermos              
              }
            } 
            else Debug.Log("No es tu turno");       
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Ranged && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
            if(!gameManager.IsPlayerOneTurn)
            {
              Zone = GameObject.Find("RangedClima");
             if(gameManager.playerOnePassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
            }
            else Debug.Log("No es tu turno");           
          }
        
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Ranged && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
            if(!gameManager.IsPlayerOneTurn)
            {
              Zone = GameObject.Find("RangedClima");
              if(gameManager.playerOnePassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
            }
            else Debug.Log("No es tu turno");           
          }
          
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Siege && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
              if(!gameManager.IsPlayerOneTurn)
              {
                Zone = GameObject.Find("SiegeClima");
               if(gameManager.playerOnePassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
              }
          else Debug.Log("No es tu turno");
          }

          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Siege && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
              if(!gameManager.IsPlayerOneTurn)
              {
                Zone = GameObject.Find("SiegeClima");
               if(gameManager.playerOnePassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
              }
          else Debug.Log("No es tu turno");
          }
          
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Melee && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
            if(!gameManager.IsPlayerOneTurn)
            {
              Zone = GameObject.Find("AumentoMelee (1)");
              if(gameManager.playerOnePassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
            }  
          else Debug.Log("No es tu turno");
          }
          
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Ranged && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
            if(!gameManager.IsPlayerOneTurn)
            { 
              Zone = GameObject.Find("AumentoRanged (1)");
              if(gameManager.playerOnePassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
            }
          else Debug.Log("No es tu turno");
          }
          
          else if( CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Siege && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
              if(!gameManager.IsPlayerOneTurn)
              {
                Zone = GameObject.Find("AumentoSiege  (1)");
                if(gameManager.playerOnePassed == false)
                {
                  gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
                }
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
              }           
              else Debug.Log("No es tu turno");
          }
        }
    }    
}
