using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class SpecialCardsControl : MonoBehaviour
{
    public GameObject Zone;
     public GameObject Card;
     public SpecialCards CardInfo;
     public GameManager gameManager;
     private GameObject zone;
     private GameObject zone1;
      private GameObject deck;
     private GameObject deck1;
     private List<GameObject> cardsinhand;
     private List<GameObject> cardsinhand1;
     private GameObject Cementery;
     private GameObject Cementery1;
    // Start is called before the first frame update
    void Start()
    {
      gameManager = GameObject.FindObjectOfType<GameManager>();
      deck = GameObject.FindGameObjectWithTag("Deck");
      deck1 = GameObject.FindGameObjectWithTag("Deck(1)");
      cardsinhand = deck.GetComponent<Draw>().CardsInHand;
      cardsinhand1 = deck1.GetComponent<Draw>().CardsInHand;
      Cementery = GameObject.Find("Cementery");
      Cementery1 = GameObject.Find("Cementery (1)");
    }
    public void OnClick()
    {
     //asigna la zona que le corresponde a cada carta segun el tipo de carta y la zona a la que afecta y controla que sea el turno del jugador en caso contrario no le asigna una zona y por ende no se mueve
        if(gameManager.playerOnePassed == false)
        {
          if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Melee && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
            if(gameManager.IsPlayerOneTurn && CardInfo.jugada == false)//comprueba que la carta no se haya jugado y que sea el turno del jugador
            {
              if(gameManager.MeleeClima == false)//comprueba que no haya una carta melee afectando a esa zona
              {
              Zone = GameObject.Find("MeleeClima");
              Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
              Card.transform.position = Zone.transform.position;
              cardsinhand.Remove(Card);
              CardInfo.jugada = true;
              Clima("MeleeZone","MeleeZone (1)");//afecta a las cartas de plata
              gameManager.meleeClimaOn = true;

              if(gameManager.playerTwoPassed == false)//comprueba que el otro jagador no se haya pasado para cambiar el turno
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
              gameManager.MeleeClima = true;
              }
              else Debug.Log("ya hay una carta clima que afecta esta zona");
              
            } 
            else Debug.Log("No es tu turno");       
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
              if(gameManager.MeleeClima == true)
              {
                 foreach(GameObject carta in Zone.GetComponent<SpecialZones>().CartasEnZona)
                 {
                    if(carta.GetComponent<SpecialCardsDisplay>().specialcard.tipoDeCarta == SpecialCards.TipoDeCarta.clima)
                    {
                      carta.transform.SetParent(Cementery.transform, false); // mover la carta clima al cementerio al cementerio
                      carta.transform.position = Cementery.transform.position;
                    }
                 }
                 Despeje("MeleeZone","MeleeZone (1)");
                 gameManager.MeleeClima = false;
                 gameManager.meleeClimaOn = false;

              }
              else Debug.Log("no hay cartas climas"); 
              if(gameManager.playerTwoPassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }
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
              Clima("RangedZone", "RangedZone (1)");
              gameManager.rangedClimaOn = true;
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
              if(gameManager.RangedClima == true)
              {
                 foreach(GameObject carta in Zone.GetComponent<SpecialZones>().CartasEnZona)
                 {
                    if(carta.GetComponent<SpecialCardsDisplay>().specialcard.tipoDeCarta == SpecialCards.TipoDeCarta.clima)
                    {
                      carta.transform.SetParent(Cementery.transform, false); // mover la carta al cementerio
                      carta.transform.position = Cementery.transform.position;
                    }
                 }
                 Despeje("RangedZone", "RangedZone (1)");
                 gameManager.RangedClima = false;
                 gameManager.rangedClimaOn = false;
              }
              else Debug.Log("no hay cartas climas");   

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
                Clima("SiegeZone", "SiegeZone (1)");
                gameManager.siegeClimaOn = true;
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
                if(gameManager.MeleeClima == true)
              {
                 foreach(GameObject carta in Zone.GetComponent<SpecialZones>().CartasEnZona)
                 {
                    if(carta.GetComponent<SpecialCardsDisplay>().specialcard.tipoDeCarta == SpecialCards.TipoDeCarta.clima)
                    {
                      carta.transform.SetParent(Cementery.transform, false); // mover la carta al cementerio
                      carta.transform.position = Cementery.transform.position;
                    }
                 }
                 Despeje("SiegeZone", "SiegeZone (1)");
                 gameManager.SiegeClima = false;
                 gameManager.siegeClimaOn = false;
              }   

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
              Aumentos("MeleeZone");
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
              Aumentos("RangedZone");
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
              Aumentos("SiegeZone");
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
            if(!gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
            {
              if(gameManager.MeleeClima == false)
              {
                gameManager.MeleeClima = true;
                Zone = GameObject.Find("MeleeClima");
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
                cardsinhand1.Remove(Card);
                CardInfo.jugada = true;
                Clima("MeleeZone","MeleeZone (1)");
                gameManager.meleeClimaOn = true;
                if(gameManager.playerOnePassed == false)
                {
                  gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
                }
                gameManager.MeleeClima = true;
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
              if(gameManager.MeleeClima == true)
              {
                 foreach(GameObject carta in Zone.GetComponent<SpecialZones>().CartasEnZona)
                 {
                    if(carta.GetComponent<SpecialCardsDisplay>().specialcard.tipoDeCarta == SpecialCards.TipoDeCarta.clima)
                    {
                      carta.transform.SetParent(Cementery1.transform, false); // mover la carta al cementerio
                      carta.transform.position = Cementery1.transform.position;
                    }
                 }
                 Despeje("MeleeZone","MeleeZone (1)");
                 gameManager.MeleeClima = false;
                 gameManager.meleeClimaOn = false;
              }  

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
              if(gameManager.RangedClima == false)
              {
                 Zone = GameObject.Find("RangedClima");
                Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                Card.transform.position = Zone.transform.position;
                cardsinhand1.Remove(Card);
                CardInfo.jugada = true;
                Clima("RangedZone", "RangedZone (1)");
                gameManager.rangedClimaOn = true;
                if(gameManager.playerOnePassed == false)
                {
                  gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
                }
                gameManager.RangedClima = true;
              }
              else Debug.Log("ya hay una carta clima que afecta esta zona");
             
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
              if(gameManager.RangedClima == true)
              {
                 foreach(GameObject carta in Zone.GetComponent<SpecialZones>().CartasEnZona)
                 {
                    if(carta.GetComponent<SpecialCardsDisplay>().specialcard.tipoDeCarta == SpecialCards.TipoDeCarta.clima)
                    {
                      carta.transform.SetParent(Cementery1.transform, false); // mover la carta al cementerio
                      carta.transform.position = Cementery1.transform.position;
                    }
                 }
                 Despeje("RangedZone", "RangedZone (1)");
                 gameManager.RangedClima = false;
                 gameManager.rangedClimaOn = false;
              }   
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
                if(gameManager.SiegeClima == false)
                {
                  Zone = GameObject.Find("SiegeClima");
                  Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
                  Card.transform.position = Zone.transform.position;
                  cardsinhand1.Remove(Card);
                  CardInfo.jugada = true;
                  Clima("SiegeZone", "SiegeZone (1)");
                  gameManager.siegeClimaOn = true;
                  if(gameManager.playerOnePassed == false)
                  {
                    gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
                  }
                  gameManager.SiegeClima = true;
                }
                else Debug.Log("ya hay una carta que afecta esta zona");  
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
                if(gameManager.SiegeClima == true)
                {
                  foreach(GameObject carta in Zone.GetComponent<SpecialZones>().CartasEnZona)
                  {
                      if(carta.GetComponent<SpecialCardsDisplay>().specialcard.tipoDeCarta == SpecialCards.TipoDeCarta.clima)
                      {
                        carta.transform.SetParent(Cementery1.transform, false); // mover la carta al cementerio
                        carta.transform.position = Cementery1.transform.position;
                      }
                  }
                  Despeje("SiegeZone", "SiegeZone (1)");
                  gameManager.SiegeClima = false;
                  gameManager.siegeClimaOn = false;
                }   
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
              Aumentos("MeleeZone (1)");
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
              Aumentos("RangedZone (1)");
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
                Aumentos("SiegeZone (1)");
                if(gameManager.playerOnePassed == false)
                {
                  gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
                }
              Debug.Log(CardInfo.jugada);
              }           
              else Debug.Log("No es tu turno");
          }
        }
 void Clima(string tag1, string tag2)
 {
    zone = GameObject.FindGameObjectWithTag(tag1);
    zone1 = GameObject.FindGameObjectWithTag(tag2);
    zone.GetComponent<Tablero>().suma = 0;
    zone1.GetComponent<Tablero>().suma = 0;

    Debug.Log("estoy aqui");
    foreach(GameObject carta in zone.GetComponent<Tablero>().CartasEnZona)
    {
      
      if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == global::Card.TipoDeCarta.silver)
      {
        carta.GetComponent<cardDisplay>().card.Damage -= 1;
        carta.GetComponent<cardDisplay>().card.AfectadaPorUnClima = true;
      }
      zone.GetComponent<Tablero>().suma += carta.GetComponent<cardDisplay>().card.Damage;
       
    }
    foreach(GameObject carta in zone1.GetComponent<Tablero>().CartasEnZona)
    {
      if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == global::Card.TipoDeCarta.silver)
      {
        carta.GetComponent<cardDisplay>().card.Damage -= 1;
        carta.GetComponent<cardDisplay>().card.AfectadaPorUnClima = true;
      }
      zone1.GetComponent<Tablero>().suma += carta.GetComponent<cardDisplay>().card.Damage;
    }
    
 }
 void Aumentos(string tag)
 {
    Debug.Log("voy a aumentar");
    zone = GameObject.FindGameObjectWithTag(tag);
    zone.GetComponent<Tablero>().suma = 0;
    foreach(GameObject carta in zone.GetComponent<Tablero>().CartasEnZona)
    {     
      if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == global::Card.TipoDeCarta.silver)
      {
        carta.GetComponent<cardDisplay>().card.Damage += 2;
        carta.GetComponent<cardDisplay>().card.Aumentada = true;
      } 
      zone.GetComponent<Tablero>().suma += carta.GetComponent<cardDisplay>().card.Damage;  
    }
 }
 void Despeje(string tag, string tag1)
 {
    zone = GameObject.FindGameObjectWithTag(tag);
    zone.GetComponent<Tablero>().suma = 0;
    zone1 = GameObject.FindGameObjectWithTag(tag1);
    zone1.GetComponent<Tablero>().suma = 0;
    foreach(GameObject carta in zone.GetComponent<Tablero>().CartasEnZona)
    {
      if(carta.GetComponent<cardDisplay>().card.AfectadaPorUnClima == true)
      {
        carta.GetComponent<cardDisplay>().card.Damage += 1;
        carta.GetComponent<cardDisplay>().card.AfectadaPorUnClima = false;
      }
      zone.GetComponent<Tablero>().suma += carta.GetComponent<cardDisplay>().card.Damage;
    }
     foreach(GameObject carta in zone1.GetComponent<Tablero>().CartasEnZona)
    {
      if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == global::Card.TipoDeCarta.silver)
      {
        carta.GetComponent<cardDisplay>().card.Damage += 1;
        carta.GetComponent<cardDisplay>().card.AfectadaPorUnClima = false;
      }
      zone1.GetComponent<Tablero>().suma += carta.GetComponent<cardDisplay>().card.Damage;
    }

 }
}
   
}
 