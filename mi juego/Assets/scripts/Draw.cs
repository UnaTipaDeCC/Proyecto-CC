using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    //public GameObject Card;
    public GameObject Hand;
    private List<GameObject> CardsInHand { get; set; }
    public List<GameObject> CardsInDeck;

    void Start()
    {
        CardsInHand = new();
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