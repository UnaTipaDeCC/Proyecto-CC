using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject melee;
    private GameObject ranged;
    private GameObject siege;
    private List<GameObject> meleecards;
    private List<GameObject> rangedcards;
    private List<GameObject> siegecards;
    private List<GameObject> cardsInHand;
    private List<GameObject> cardsInDeck;
    private GameObject Cementery;
    
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
    private bool UsadoL = false;//ya se utilice en la ronada la carta lider para ganar   

    public bool playerTwoPassed
    {
        get { return PlayerTwoPassed; }
        set { PlayerTwoPassed = value; }
    }
    private List<GameObject> meleeClimaCards = new List<GameObject>();
    private List<GameObject> rangedClimaCards = new List<GameObject>();
    private List<GameObject> siegeClimaCards = new List<GameObject>();
    public List<GameObject> MeleeClimaCards
{
    get { return meleeClimaCards; }
    set { meleeClimaCards = value; }
}
public GameObject hand;
public GameObject deck;
public List<GameObject> RangedClimaCards
{
    get { return rangedClimaCards; }
    set { rangedClimaCards = value; }
}
public List<GameObject> SiegeClimaCards
{
    get { return siegeClimaCards; }
    set { siegeClimaCards = value; }
}
public GameObject contador1;//contador del jugador uno
public GameObject contador2;//contador del jugador dos
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
            
        }
        if(contador1.GetComponent<Contador>().puntos < contador2.GetComponent<Contador>().puntos)
        {
            Debug.Log("gana el jugador dos");
            isPlayerOneTurn = false;
            RondasGanadas2 ++;
            ComprobarCuantasCartasRobar("Deck(1)", "Hand (1)");
            RobarCarta("Deck(1)","Hand (1)");
            LimpiarFilas("MeleeZone","SiegeZone","RangedZone","Cementery");//limpia filas del jugador uno
            LimpiarFilas("MeleeZone (1)","SiegeZone (1)", "RangedZone (1)", "Cementery (1)"); //limpia la fila del jugador dos
        }
        if(contador1.GetComponent<Contador>().puntos == contador2.GetComponent<Contador>().puntos)
        {
            Debug.Log("empate");
            RondasGanadas1 ++;
            RondasGanadas2 ++;
            ComprobarCuantasCartasRobar("Deck", "Hand");
            RobarCarta("Deck","Hand");
            ComprobarCuantasCartasRobar("Deck(1)", "Hand (1)");
            RobarCarta("Deck(1)","Hand (1)");
            LimpiarFilas("MeleeZone","SiegeZone","RangedZone","Cementery");//limpia filas del jugador uno
            LimpiarFilas("MeleeZone (1)","SiegeZone (1)", "RangedZone (1)", "Cementery (1)"); //limpia la fila del jugador dos
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
    Debug.Log("COMPRUEBO CUANTAS VOY A JUGAR");
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
