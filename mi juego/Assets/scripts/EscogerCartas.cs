using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EscogerCartas : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject clickedCard;
    private GameObject deck;
    private GameObject contador;
    private GameObject hand;
    private List<GameObject> cardsInHand;
    private List<GameObject> cardsInDeck;

    // Start is called before the first frame update
    void Start()
    {
       gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    public void Cambiardoscartas()
    {  
        if((clickedCard.CompareTag("Card") && clickedCard.GetComponent<cardDisplay>().card.faccion == Card.Faccion.Hormigas_Bravas) || (clickedCard.CompareTag("SpecialCard") && clickedCard.GetComponent<SpecialCardsDisplay>().specialcard.faccion == SpecialCards.Faccion.Hormigas_Bravas))
        {
            deck = GameObject.Find("Deck");
            contador = GameObject.Find("Contador");
            hand = GameObject.Find("Hand");
        if(gameManager.Cambieb  < 2 && Input.GetMouseButtonUp(1) && contador.GetComponent<Contador>().puntos == 0 && deck.GetComponent<Draw>().CardsInHand.Count == 10)
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
            gameManager.Cambieb ++;
             Debug.Log(gameManager.Cambieb);

        }
        else Debug.Log("Ya cambiaste las dos cartas o ya jugaste y no  puedes cambiar");
        }
        else if((gameManager.CambieL < 2 && clickedCard.CompareTag("Card") && clickedCard.GetComponent<cardDisplay>().card.faccion == Card.Faccion.Hormigas_Locas) || (clickedCard.CompareTag("SpecialCard") && clickedCard.GetComponent<SpecialCardsDisplay>().specialcard.faccion == SpecialCards.Faccion.Hormigas_Locas))
        {
            deck = GameObject.Find("Deck (1)");
            contador = GameObject.Find("Contador (1)");
            hand = GameObject.Find("Hand1");
            if( Input.GetMouseButtonUp(1) && contador.GetComponent<Contador>().puntos == 0 && deck.GetComponent<Draw>().CardsInHand.Count == 10)
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
            gameManager.CambieL++;
            Debug.Log(gameManager.CambieL);
        }
        else Debug.Log("Ya cambiaste las dos cartas o ya jugaste y no  puedes cambiar");
        }
       
    }
}
  
