using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    //public GameObject Card;
    public GameObject Hand;
    public List<GameObject> CardsInHand; //= new List<GameObject>();
    public List<GameObject> CardsInDeck; //= new List<GameObject>();
    /*private List<GameObject> cardsInHand = new List<GameObject>();
    private List<GameObject> cardsInDeck = new List<GameObject>();

    public List<GameObject> GetCardsInHand()
    {
        return cardsInHand;
    }

    public List<GameObject> GetCardsInDeck()
    {
        return cardsInDeck;
    }*/
    void Start()
    {
       //CardsInHand = new();
    }

    public void OnClick()
    {
        if(CardsInHand.Count < 10)
        {
            int index = Random.Range(0, CardsInDeck.Count);
            GameObject drawCard = Instantiate(CardsInDeck[index], new Vector3(0,0,0), Quaternion.identity);
            CardsInDeck.RemoveAt(index);
            drawCard.transform.SetParent(Hand.transform, false);
            CardsInHand.Add(drawCard);
            //CardsInDeck.Remove(drawCard);

        }
       
    }
}