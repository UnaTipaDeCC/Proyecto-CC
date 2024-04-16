using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<GameObject> CardsInHand;
    public List<GameObject> CardsInDeck;
    public List<GameObject> CardsInCementery;
    public List<GameObject> CardsInMeleeZone;
    public List<GameObject> CardsInRangedZone;
    public List<GameObject> CardsInSiegeZone;
    public int Contador; 

    List<GameObject> CardsInHand1 = new List<GameObject>();
    List<GameObject> CardsInDeck1 = new List<GameObject>();
    List<GameObject> CardsInCementery1 = new List<GameObject>();
    List<GameObject> CardsInMeleeZone1 = new List<GameObject>();
    List<GameObject> CardsInRangedZone1 = new List<GameObject>();
    List<GameObject> CardsInSiegeZone1 = new List<GameObject>();
    int Contador1;

    public Player(int Contador,List<GameObject> CardsInHand,List<GameObject> CardsInDeck, List<GameObject> CardsInCementery, List<GameObject> CardsInMeleeZone, List<GameObject> CardsInRangedZone, List<GameObject> CardsInSiegeZone)
    {
        this.Contador = Contador;
        this.CardsInHand = CardsInHand;
        this.CardsInDeck = CardsInDeck;
        this.CardsInCementery = CardsInCementery;
        this.CardsInMeleeZone = CardsInMeleeZone;
        this.CardsInRangedZone = CardsInRangedZone;
        this.CardsInSiegeZone = CardsInSiegeZone;
    }
    //Player player1 = new Player(int Contador1,CardsInDeck1,CardsInCementery1,CardsInMeleeZone1, CardsInRangedZone, CardsInSiegeZone1);
    }
