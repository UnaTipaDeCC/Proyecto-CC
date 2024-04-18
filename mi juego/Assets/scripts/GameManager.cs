using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   private bool isPlayerOneTurn = true;

    public bool IsPlayerOneTurn
    {
        get { return isPlayerOneTurn; }
        set { isPlayerOneTurn = value; }
    }
    private bool PlayerOnePassed = false;

    public bool playerOnePassed
    {
        get { return PlayerOnePassed; }
        set { PlayerOnePassed = value; }
    }
    private bool PlayerTwoPassed = false;

    public bool playerTwoPassed
    {
        get { return PlayerTwoPassed; }
        set { PlayerTwoPassed = value; }
    }
    private List<GameObject> meleeClimaCards = new List<GameObject>();
    private List<GameObject> rangedClimaCards = new List<GameObject>();
    private List<GameObject> siegeClimaCards = new List<GameObject>();
    public List<GameObject> MeleeClimaCards
{
    get { return meleeClimaCards; }
    set { meleeClimaCards = value; }
}

public List<GameObject> RangedClimaCards
{
    get { return rangedClimaCards; }
    set { rangedClimaCards = value; }
}

public List<GameObject> SiegeClimaCards
{
    get { return siegeClimaCards; }
    set { siegeClimaCards = value; }
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
