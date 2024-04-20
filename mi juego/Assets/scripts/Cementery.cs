using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cementery : MonoBehaviour
{
    public List<GameObject> CardsInZone = new List<GameObject>();
    private GameObject CARD;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        CARD = collision.gameObject;
        CardsInZone.Add(CARD);
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
