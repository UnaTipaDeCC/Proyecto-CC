using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimasyDespejes : MonoBehaviour
{
    public GameObject melee;
    public GameObject melee1;
    public GameObject ranged;
    public GameObject ranged1;
    public GameObject siege;
    public GameObject siege1;
    private GameManager gameManager;

    public void ClimaMelee()
    { 
        
       
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
