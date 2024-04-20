using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambiardoscartas : MonoBehaviour
{
    public GameObject deck;
    public GameObject contador;
    public GameObject hand;
    private List<GameObject> cardsInHand;
    private List<GameObject> cardsInDeck;
    private GameObject card;
    public void OnClick()
    {
        if(contador.GetComponent<Contador>().puntos == 0 && deck.GetComponent<Draw>().CardsInHand.Count == 10)
        {
            cardsInHand = deck.GetComponent<Draw>().CardsInHand;
            cardsInDeck = deck.GetComponent<Draw>().CardsInDeck;
            for(int i = 0; i < 2 ; i++)
            {
                int index = UnityEngine.Random.Range(0, cardsInDeck.Count);
                GameObject drawCard = Instantiate(cardsInDeck[index], new Vector3(0,0,0), Quaternion.identity);
                cardsInDeck.RemoveAt(index);
                drawCard.transform.SetParent(hand.transform, false);
                cardsInHand.Add(drawCard);
                int index1 = UnityEngine.Random.Range(0, cardsInHand.Count);
                card = cardsInHand[index1];
                cardsInDeck.Add(card);
                Destroy(card);
                Debug.Log("movi una");
            }

        }
        else Debug.Log("YA CAMBIASTE O YA EMPEZO EL JUEGO");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
