using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DrawCard : MonoBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Hand1;
    public GameObject Hand2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnClick()
    {

        for(var i = 0; i < 5; i++)
        {
            GameObject playerCard = Instantiate(Card1, new Vector3(0, 0 ,0), quaternion.identity);
            playerCard.transform.SetParent(Hand1.transform,false);
        }
    }

    
}
