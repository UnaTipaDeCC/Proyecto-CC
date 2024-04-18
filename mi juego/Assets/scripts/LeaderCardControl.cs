using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderCardControl : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject card;
    public SpecialCards cardInfo;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void OnClick()
    {
        if(gameManager.playerOnePassed == false && gameManager.IsPlayerOneTurn && cardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
        {
            Debug.Log("todo bien hasta aqui");
            if(gameManager.leaderCardBActivated == false)
            {
            Debug.Log("active esta historia");
            if(gameManager.playerTwoPassed == false)
            {
                gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
            }
            gameManager.leaderCardBActivated = true;
            }
            else Debug.Log("ya la activaste");

        }
        else if(gameManager.playerTwoPassed == false  && cardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
        {
            if(gameManager.IsPlayerOneTurn == false)
            {
            Debug.Log("soy de esta faccion");
            if(gameManager.leaderCardLActivated == false)
            {
                Debug.Log("active esta historia");
                if(gameManager.playerOnePassed == false)
                {
                    gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
                }
                gameManager.leaderCardLActivated = true;
            }
            else Debug.Log("ya la activaste");    
            }
            else Debug.Log("NO ES MI TURNO");
        
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
