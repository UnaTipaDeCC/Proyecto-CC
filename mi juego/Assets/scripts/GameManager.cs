using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   private bool isPlayerOneTurn = true;

    public bool IsPlayerOneTurn
    {
        get { return isPlayerOneTurn; }
        set { isPlayerOneTurn = value; }
    }
    private bool PlayerOnePassed = false;

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
            Debug.Log("gana el jugador uno");
            isPlayerOneTurn = true;
            RondasGanadas1 ++;
        }
        if(contador1.GetComponent<Contador>().puntos < contador2.GetComponent<Contador>().puntos)
        {
            Debug.Log("gana el jugador dos");
            isPlayerOneTurn = false;
            RondasGanadas2 ++;
        }
        if(contador1.GetComponent<Contador>().puntos == contador2.GetComponent<Contador>().puntos)
        {
            Debug.Log("empate");
            RondasGanadas1 ++;
            RondasGanadas2 ++;
        }
        playerOnePassed = false;
        playerTwoPassed = false;

    }
}
public void EndGame()
{
    if((RondasGanadas1 == 2 || RondasGanadas2 == 2) && RondasGanadas1 != RondasGanadas2)
    {
        Debug.Log("Se acabo el juego");
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
