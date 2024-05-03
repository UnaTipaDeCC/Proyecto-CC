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
     private GameObject cartam;
     private GameObject cartas;
     private GameObject cartar;
     private GameObject filaMelee;
     private GameObject filaRanged;
    private GameObject filaSiege;
    private List<GameObject> melee;
    private List<GameObject> ranged;
    private List<GameObject> siege;
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
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.senuelo && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
          {
            Debug.Log("estoy");
            if (gameManager.IsPlayerOneTurn && CardInfo.jugada == false)
            {
              Senuelo("MeleeZone","SiegeZone","RangedZone", cardsinhand,"Hand");
              CardInfo.jugada = true;
              if(gameManager.playerTwoPassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }  
            }
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
          else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.senuelo && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
          {
            if (!gameManager.playerTwoPassed && CardInfo.jugada == false)
            {
              Senuelo("MeleeZone (1)","SiegeZone (1)","RangedZone (1)", cardsinhand1,"Hand (1)");
              CardInfo.jugada = true;
              if(gameManager.playerOnePassed == false)
              {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
              }  
            }
          }
        }
  void Senuelo(string meleeTag, string siegeTag, string rangedTag, List<GameObject> cardsInHand, string ZoneTag)
  {
    Zone = GameObject.FindGameObjectWithTag(ZoneTag);//la mano a la que tiene que regresar la carta    
    filaMelee = GameObject.FindGameObjectWithTag(meleeTag);
    melee = filaMelee.GetComponent<Tablero>().CartasEnZona;
    filaRanged = GameObject.FindGameObjectWithTag(rangedTag);
    ranged = filaRanged.GetComponent<Tablero>().CartasEnZona;
    filaSiege = GameObject.FindGameObjectWithTag(siegeTag);
    siege = filaSiege.GetComponent<Tablero>().CartasEnZona;
    int contador_melee = int.MinValue;
    int index_melee = 0;
    int contador_ranged = int.MinValue;
    int index_ranged = 0;
    int contador_siege = int.MinValue;
    int index_siege = 0;
    if(melee.Count != 0 || siege.Count != 0 || ranged.Count != 0)
    {
      foreach(GameObject carta in melee)//encuentra la carta mas poder de la zona melee
      {
        if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == global::Card.TipoDeCarta.silver)
        {
        if(carta.GetComponent<cardDisplay>().card.Damage > contador_melee) 
        {
          contador_melee = carta.GetComponent<cardDisplay>().card.Damage;
          index_melee = melee.IndexOf(carta);
          cartam = carta;
        }
        }
      }
      foreach(GameObject carta in ranged)//encuentra la carta con mas poderde la zona ranged
      {
        if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == global::Card.TipoDeCarta.silver)
        {
        if(carta.GetComponent<cardDisplay>().card.Damage > contador_ranged)
        {
          contador_ranged = carta.GetComponent<cardDisplay>().card.Damage;
          index_ranged = ranged.IndexOf(carta);
          cartar = carta;
        }
        }
      } 
      foreach(GameObject carta in siege)//encuentra la carta con mas poder de la zona siege
      {
        if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == global::Card.TipoDeCarta.silver)
        {
        if(carta.GetComponent<cardDisplay>().card.Damage > contador_siege)
        {
          contador_siege = carta.GetComponent<cardDisplay>().card.Damage;
          index_siege = siege.IndexOf(carta);
          cartas = carta;
        }
        }
      }
      //comparar cual de las cartas tiene mas poder
      if(contador_melee >= contador_ranged && contador_melee > contador_siege)
      {
        Debug.Log("en melee esta la que menos tiene");
        cartam.transform.SetParent(Zone.transform, false); // mover la carta con mas  poder a la mano
        cartam.transform.position = Zone.transform.position;
        cardsInHand.Add(cartam); //agregarla a la lista de  la mano
        cartam.GetComponent<cardDisplay>().card.jugada = false;
        Card.transform.SetParent(filaMelee.transform, false); // mover la carta senuelo a la fila melee 
        Card.transform.position = filaMelee.transform.position;
        cardsInHand.Remove(Card);//remover la senuelo de la mano
      }
      else if(contador_ranged > contador_melee && contador_ranged >= contador_siege)
      {
        cartar.transform.SetParent(Zone.transform, false); // mover la carta con mas  poder a la mano 
        cartar.transform.position = Zone.transform.position;
        cardsInHand.Add(cartar);
        cartar.GetComponent<cardDisplay>().card.jugada = false;
        Card.transform.SetParent(filaRanged.transform, false); // mover la carta senuelo a la fila melee 
        Card.transform.position = filaRanged.transform.position;
        cardsInHand.Remove(Card);
        Debug.Log("en ranged esta la que menos tiene");
        }
        else if(contador_siege > contador_melee && contador_siege > contador_ranged)
        {
          cartas.transform.SetParent(Zone.transform, false); // mover la carta con mas  poder a la mano 
          cartas.transform.position = Zone.transform.position;
          cardsInHand.Add(cartas);
          cartas.GetComponent<cardDisplay>().card.jugada = false;
          Card.transform.SetParent(filaSiege.transform, false); // mover la carta senuelo a la fila siege
          Card.transform.position = filaSiege.transform.position;
          cardsInHand.Remove(Card);
          Debug.Log("en siege esta la que menos tiene");
        }
        else if(cartam == null && cartar == null && cartas == null)
        {
        Debug.Log("todas son de oro");
        Card.transform.SetParent(filaSiege.transform, false); // mover la carta senuelo a la fila siege
        Card.transform.position = filaSiege.transform.position;
        cardsInHand.Remove(Card);
        }
        }
        else 
        {
          Card.transform.SetParent(filaSiege.transform, false); // mover la carta senuelo a la fila siege
          Card.transform.position = filaSiege.transform.position;
          cardsInHand.Remove(Card);
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
      if(carta.CompareTag("Card"))
      {
      if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == global::Card.TipoDeCarta.silver)
      {
        carta.GetComponent<cardDisplay>().card.Damage -= 1;
        carta.GetComponent<cardDisplay>().card.AfectadaPorUnClima = true;
      }
      zone.GetComponent<Tablero>().suma += carta.GetComponent<cardDisplay>().card.Damage;
      } 
    }
    foreach(GameObject carta in zone1.GetComponent<Tablero>().CartasEnZona)
    {
      if(carta.CompareTag("Card"))
      {
      if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == global::Card.TipoDeCarta.silver)
      {
        carta.GetComponent<cardDisplay>().card.Damage -= 1;
        carta.GetComponent<cardDisplay>().card.AfectadaPorUnClima = true;
      }
      zone1.GetComponent<Tablero>().suma += carta.GetComponent<cardDisplay>().card.Damage;
      }
    }
    
 }
 void Aumentos(string tag)
 {
    Debug.Log("voy a aumentar");
    zone = GameObject.FindGameObjectWithTag(tag);
    zone.GetComponent<Tablero>().suma = 0;
    foreach(GameObject carta in zone.GetComponent<Tablero>().CartasEnZona)
    {
       if(carta.CompareTag("Card"))
       {     
      if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == global::Card.TipoDeCarta.silver)
      {
        carta.GetComponent<cardDisplay>().card.Damage += 2;
        carta.GetComponent<cardDisplay>().card.Aumentada = true;
      } 
      zone.GetComponent<Tablero>().suma += carta.GetComponent<cardDisplay>().card.Damage;  
       }
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
       if(carta.CompareTag("Card"))
       {
      if(carta.GetComponent<cardDisplay>().card.AfectadaPorUnClima == true)
      {
        carta.GetComponent<cardDisplay>().card.Damage += 1;
        carta.GetComponent<cardDisplay>().card.AfectadaPorUnClima = false;
      }
      zone.GetComponent<Tablero>().suma += carta.GetComponent<cardDisplay>().card.Damage;
       }
    }
     foreach(GameObject carta in zone1.GetComponent<Tablero>().CartasEnZona)
    {
       if(carta.CompareTag("Card"))
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
}
 