using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject aumento1;
    private GameObject aumento2;
    private GameObject aumento3;
    private GameObject aumento4;
    private GameObject aumento5;
    private GameObject aumento6;
    private GameObject melee;
    private GameObject ranged;
    private GameObject siege;
    private List<GameObject> meleecards;
    private List<GameObject> rangedcards;
    private List<GameObject> siegecards;
    private List<GameObject> cardsInHand;
    private List<GameObject> cardsInDeck;
    private GameObject Cementery;
    private GameObject Cementery1;
    
   private bool isPlayerOneTurn = true;

    public bool IsPlayerOneTurn
    {
        get { return isPlayerOneTurn; }
        set { isPlayerOneTurn = value; }
    }
    private bool PlayerOnePassed = false;
    public int n;
    public bool playerOnePassed
    {
        get { return PlayerOnePassed; }
        set { PlayerOnePassed = value; }
    }
    private bool PlayerTwoPassed = false;
    private bool LeaderCardBActivated = false;//carta lider de la faccion hormigas bravas
    public bool leaderCardBActivated
    {
        get { return LeaderCardBActivated; }
        set { LeaderCardBActivated = value; }
    }
    private bool LeaderCardLActivated = false;//carta lider de la faccion hormigas locas
    public bool leaderCardLActivated
    {
        get { return LeaderCardLActivated; }
        set { LeaderCardLActivated = value; }
    } 
    private bool UsadoL = false;//ya utilice en la ronada la carta lider de la faccion hormigas locas para ganar   
    private bool UsadoB = false;//ya utilice en la ronada la carta lider de la faccion hormigas bravas para ganar   

    public bool playerTwoPassed
    {
        get { return PlayerTwoPassed; }
        set { PlayerTwoPassed = value; }
    }
    private bool meleeClima;
    public bool MeleeClima
    {
        get { return meleeClima;}
        set { meleeClima = value;}
    }
    private bool rangedClima;
    public bool RangedClima
    {
        get { return rangedClima;}
        set { rangedClima = value;}
    }
    private bool siegeClima;
    public bool SiegeClima
    {
        get { return siegeClima;}
        set { siegeClima = value;}
    }

private GameObject hand;
private GameObject deck;
private GameObject contador1;//contador del jugador uno
private GameObject contador2;//contador del jugador dos
private int RondasGanadas1;//rondas ganadas por el jugador uno
public int rondasGanadas1
{
    get { return  RondasGanadas1; }
    set {  RondasGanadas1 = value; }
}
private int RondasGanadas2;//rondas ganadas por el jugador dos
public int rondasGanadas2
{
    get { return  RondasGanadas2; }
    set {  RondasGanadas2 = value; }
}
public void EndRound()
{
    if(PlayerOnePassed == true && playerTwoPassed == true)
    {
        if(contador1.GetComponent<Contador>().puntos > contador2.GetComponent<Contador>().puntos)
        {
            if(leaderCardLActivated == true && UsadoL == false && ((contador1.GetComponent<Contador>().puntos - contador2.GetComponent<Contador>().puntos) <=2) )
            {
                Debug.Log("gana el jugador dos xq uso su carta lider");
                isPlayerOneTurn = false;
                RondasGanadas2 ++;
                UsadoL = true;
            }
            else
            {
                Debug.Log("gana el jugador uno");
                isPlayerOneTurn = true;
                RondasGanadas1 ++; 
            }
            ComprobarCuantasCartasRobar("Deck", "Hand");
            RobarCarta("Deck","Hand");
            LimpiarFilas("MeleeZone","SiegeZone","RangedZone","Cementery");//limpia filas del jugador uno
            LimpiarFilas("MeleeZone (1)","SiegeZone (1)", "RangedZone (1)", "Cementery (1)"); //limpia la fila del jugador dos
            Aumentos();//limpia los aumentos
            QuitarFilasEspeciales(); //quita las cartas de aumento y despeje
            
        }
        if(contador1.GetComponent<Contador>().puntos < contador2.GetComponent<Contador>().puntos)
        {
            Debug.Log("gana el jugador dos");
            isPlayerOneTurn = false;
            RondasGanadas2 ++;
            ComprobarCuantasCartasRobar("Deck(1)", "Hand (1)");
            RobarCarta("Deck(1)","Hand (1)");
            Aumentos();
            LimpiarFilas("MeleeZone","SiegeZone","RangedZone","Cementery");//limpia filas del jugador uno
            LimpiarFilas("MeleeZone (1)","SiegeZone (1)", "RangedZone (1)", "Cementery (1)"); //limpia la fila del jugador dos
            QuitarFilasEspeciales();
        }
        if(contador1.GetComponent<Contador>().puntos == contador2.GetComponent<Contador>().puntos)
        {
            if(leaderCardBActivated == true && UsadoB == false)
            {
                Debug.Log("gana el jugador uno xq uso su carta lider");
                isPlayerOneTurn = true;
                RondasGanadas1 ++;
                UsadoB = true;
            }
            else
            {
                Debug.Log("empate");
                RondasGanadas1 ++;
                RondasGanadas2 ++;
            }
            
            ComprobarCuantasCartasRobar("Deck", "Hand");
            RobarCarta("Deck","Hand");
            ComprobarCuantasCartasRobar("Deck(1)", "Hand (1)");
            RobarCarta("Deck(1)","Hand (1)");
            LimpiarFilas("MeleeZone","SiegeZone","RangedZone","Cementery");//limpia filas del jugador uno
            LimpiarFilas("MeleeZone (1)","SiegeZone (1)", "RangedZone (1)", "Cementery (1)"); //limpia la fila del jugador dos
            Aumentos();
            QuitarFilasEspeciales();
        }
        playerOnePassed = false;
        playerTwoPassed = false;
    }
}


public void RobarCarta(string tagDeck, string tagHand)
{
    Debug.Log("compruebo para robar carta");
        for(int i = 0; i < n; i++)
        {
            hand = GameObject.FindGameObjectWithTag(tagHand);
            deck = GameObject.FindGameObjectWithTag(tagDeck);
            cardsInHand = deck.GetComponent<Draw>().CardsInHand;
            cardsInDeck = deck.GetComponent<Draw>().CardsInDeck;
            int index = Random.Range(0, cardsInDeck.Count);
            GameObject drawCard = Instantiate(cardsInDeck[index], new Vector3(0,0,0), Quaternion.identity);
            cardsInDeck.RemoveAt(index);
            drawCard.transform.SetParent(hand.transform, false);
            cardsInHand.Add(drawCard);
        }            
}
public void ComprobarCuantasCartasRobar(string tagDeck, string tagHand)
{
    //Debug.Log("COMPRUEBO CUANTAS VOY A JUGAR");
    hand = GameObject.FindGameObjectWithTag(tagHand);
    deck = GameObject.FindGameObjectWithTag(tagDeck);
    cardsInHand = deck.GetComponent<Draw>().CardsInHand;
    cardsInDeck = deck.GetComponent<Draw>().CardsInDeck;
    if(cardsInHand.Count < 9)
    {
        n = 2;
    }
    else if(cardsInHand.Count == 9)
    {
        n = 1;
    }
    else if (cardsInHand.Count == 10)
    {
        n = 0;
    }
}
public void QuitarFilasEspeciales()
{
    aumento1 = GameObject.FindGameObjectWithTag("7");//zona meleeclima
    aumento2 = GameObject.FindGameObjectWithTag("8");//zona rangedclima
    aumento3 = GameObject.FindGameObjectWithTag("9");//zona siegeclima
    Cementery = GameObject.FindGameObjectWithTag("Cementery");
    Cementery1 = GameObject.FindGameObjectWithTag("Cementery (1)");

    foreach(GameObject carta in aumento1.GetComponent<SpecialZones>().CartasEnZona)
    {
        if(carta.GetComponent<SpecialCardsDisplay>().specialcard.faccion == SpecialCards.Faccion.Hormigas_Bravas)
        {
            carta.transform.SetParent(Cementery.transform, false);
            carta.transform.position = Cementery.transform.position; 
        }
        if(carta.GetComponent<SpecialCardsDisplay>().specialcard.faccion == SpecialCards.Faccion.Hormigas_Locas)
        {
            carta.transform.SetParent(Cementery1.transform, false);
            carta.transform.position = Cementery1.transform.position; 
        }    
    }
    foreach(GameObject carta in aumento2.GetComponent<SpecialZones>().CartasEnZona)
    {
        if(carta.GetComponent<SpecialCardsDisplay>().specialcard.faccion == SpecialCards.Faccion.Hormigas_Bravas)
        {
            carta.transform.SetParent(Cementery.transform, false);
            carta.transform.position = Cementery.transform.position; 
        }
        if(carta.GetComponent<SpecialCardsDisplay>().specialcard.faccion == SpecialCards.Faccion.Hormigas_Locas)
        {
            carta.transform.SetParent(Cementery1.transform, false);
            carta.transform.position = Cementery1.transform.position; 
        }    
    }
    foreach(GameObject carta in aumento3.GetComponent<SpecialZones>().CartasEnZona)
    {
       if(carta.GetComponent<SpecialCardsDisplay>().specialcard.faccion == SpecialCards.Faccion.Hormigas_Bravas)
        {
            carta.transform.SetParent(Cementery.transform, false);
            carta.transform.position = Cementery.transform.position; 
        }
        if(carta.GetComponent<SpecialCardsDisplay>().specialcard.faccion == SpecialCards.Faccion.Hormigas_Locas)
        {
            carta.transform.SetParent(Cementery1.transform, false);
            carta.transform.position = Cementery1.transform.position; 
        }    
    }
}

public void Aumentos()
{
    aumento1 = GameObject.FindGameObjectWithTag("1");
    aumento2 = GameObject.FindGameObjectWithTag("2");
    aumento3 = GameObject.FindGameObjectWithTag("3");
    aumento4 = GameObject.FindGameObjectWithTag("4");
    aumento5 = GameObject.FindGameObjectWithTag("5");
    aumento6 = GameObject.FindGameObjectWithTag("6");
    Cementery = GameObject.FindGameObjectWithTag("Cementery");
    Cementery1 = GameObject.FindGameObjectWithTag("Cementery (1)");

    foreach(GameObject carta in aumento1.GetComponent<SpecialZones>().CartasEnZona)
    {
        carta.transform.SetParent(Cementery.transform, false);
        carta.transform.position = Cementery.transform.position; 
    }
    foreach(GameObject carta in aumento5.GetComponent<SpecialZones>().CartasEnZona)
    {
        carta.transform.SetParent(Cementery.transform, false);
        carta.transform.position = Cementery.transform.position; 
    }
    foreach(GameObject carta in aumento3.GetComponent<SpecialZones>().CartasEnZona)
    {
        carta.transform.SetParent(Cementery.transform, false);
        carta.transform.position = Cementery.transform.position; 
    }
    foreach(GameObject carta in aumento2.GetComponent<SpecialZones>().CartasEnZona)
    {
        carta.transform.SetParent(Cementery1.transform, false);
        carta.transform.position = Cementery1.transform.position; 
    }
    foreach(GameObject carta in aumento4.GetComponent<SpecialZones>().CartasEnZona)
    {
        carta.transform.SetParent(Cementery1.transform, false);
        carta.transform.position = Cementery1.transform.position; 
    }
    foreach(GameObject carta in aumento6.GetComponent<SpecialZones>().CartasEnZona)
    {
        carta.transform.SetParent(Cementery1.transform, false);
        carta.transform.position = Cementery1.transform.position; 
    }
}
public void LimpiarFilas(string tagmelee, string tagsiege, string tagranged, string tagcementery)
{
    melee = GameObject.FindGameObjectWithTag(tagmelee);
    siege = GameObject.FindGameObjectWithTag(tagsiege);
    ranged = GameObject.FindGameObjectWithTag(tagranged);
    meleecards = melee.GetComponent<Tablero>().CartasEnZona;
    siegecards = siege.GetComponent<Tablero>().CartasEnZona;
    rangedcards = ranged.GetComponent<Tablero>().CartasEnZona;
    Cementery = GameObject.FindGameObjectWithTag(tagcementery);
    foreach(GameObject card in meleecards)
    {
        card.transform.SetParent(Cementery.transform, false);
        card.transform.position = Cementery.transform.position; 
    }
     foreach(GameObject card in rangedcards)
    {
        card.transform.SetParent(Cementery.transform, false);
        card.transform.position = Cementery.transform.position; 
    }
     foreach(GameObject card in siegecards)
    {
        card.transform.SetParent(Cementery.transform, false);
        card.transform.position = Cementery.transform.position; 
    }

}
public void EndGame()
{
    if((RondasGanadas1 >= 2 || RondasGanadas2 >= 2) && RondasGanadas1 != RondasGanadas2)
    {
        Debug.Log("Se acabo el juego");
        if(RondasGanadas1 ==2) Debug.Log("GANA EL JUGADOR UNO");
        if(RondasGanadas2 ==2) Debug.Log("GANA EL JUGADOR DOS");     
    } 

}

    // Start is called before the first frame update
    void Start()
    {
        contador1 = GameObject.FindGameObjectWithTag("Contador");
        contador2 = GameObject.FindGameObjectWithTag("Contador (1)");
    }

    // Update is called once per frame
    void Update()
    {
        //FinDelaRonda();   
    }
}
