using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EscogerCartas : MonoBehaviour
{
    private GameManager gameManager;
    //public GameObject CARD;
    public GameObject clickedCard;
    private GameObject deck;
    private GameObject contador;
    private GameObject hand;
    private List<GameObject> cardsInHand;
    private List<GameObject> cardsInDeck;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }
    public void Cambiardoscartas()
    {  
       if(clickedCard.GetComponent<cardDisplay>().card.faccion == Card.Faccion.Hormigas_Bravas)
        {
            deck = GameObject.Find("Deck");
            contador = GameObject.Find("Contador");
            hand = GameObject.Find("Hand");
        }
        else if(clickedCard.GetComponent<cardDisplay>().card.faccion == Card.Faccion.Hormigas_Locas)
        {
            deck = GameObject.Find("Deck (1)");
            contador = GameObject.Find("Contador (1)");
            hand = GameObject.Find("Hand1");
        }
        if(contador.GetComponent<Contador>().puntos == 0 && deck.GetComponent<Draw>().CardsInHand.Count == 10)
        {
            cardsInHand = deck.GetComponent<Draw>().CardsInHand;
            cardsInDeck = deck.GetComponent<Draw>().CardsInDeck;
            cardsInHand.Remove(clickedCard);
            cardsInDeck.Add(clickedCard);
            Destroy(clickedCard);
            int index = UnityEngine.Random.Range(0, cardsInDeck.Count);
            GameObject drawCard = Instantiate(cardsInDeck[index], new Vector3(0,0,0), Quaternion.identity);
            cardsInDeck.RemoveAt(index);
            drawCard.transform.SetParent(hand.transform, false);
            cardsInHand.Add(drawCard);
            Debug.Log("cambie una carta");
        }
    }
    // Update is called once per frame
    /*void Update()
    {
         /*if (Input.GetMouseButtonDown(0))
    {
        Debug.Log("Tocaste el botón izquierdo");
    }
    if (Input.GetMouseButtonDown(1))
    {
        Cambiardoscartas();
    }
    }*/
    void Update()
{
    if (Input.GetMouseButtonDown(1))
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            clickedCard = hit.collider.gameObject;
            Cambiardoscartas();
        }
    }
}
}
