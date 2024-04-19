using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cementery : MonoBehaviour
{
    public List<GameObject> CardsInCementery = new List<GameObject>();
    private GameObject CARD;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        CARD = collision.gameObject;
        CardsInCementery.Add(CARD);
        Debug.Log("carta nueva");
        CARD.GetComponent<cardDisplay>().card.Damage = CARD.GetComponent<cardDisplay>().card.OriginalDamage;
        Debug.Log("cambie el dano");
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
