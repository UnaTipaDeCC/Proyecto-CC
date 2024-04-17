using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCardsControl : MonoBehaviour
{
    public GameObject Zone;
    //public static List<GameObject> CardsInZone = new List<GameObject>();
     public GameObject Card;
     public SpecialCards CardInfo;
     public GameManager gameManager;
     // Lista de zonas afectadas por cartas de clima
    //private List<SpecialCards.ZonaQueAfecta> affectedZones = new List<SpecialCards.ZonaQueAfecta>();
     //List<GameObject> list;
    // Start is called before the first frame update
    void Start()
    {
      gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    public void OnClick()
    {
     //asigna la zona que le corresponde a cada carta segun el tipo de carta y la zona a la que afecta y controla que sea el turno del jugador en caso contrario no le asigna una zona y por ende no se mueve
        //no controlas esto
        if(gameManager.IsPlayerOneTurn && (CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima || CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje) && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Melee)
        {
            Zone = GameObject.Find("MeleeClima");
            gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
        }
        if(gameManager.IsPlayerOneTurn && (CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima || CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje) && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Ranged )
        {
             Zone = GameObject.Find("RangedClima");
             gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
        }
        else if(gameManager.IsPlayerOneTurn && (CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima || CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje) && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Siege)
        {
             Zone = GameObject.Find("SiegeClima");
             gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
        }
        else if(gameManager.IsPlayerOneTurn && CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Melee && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
        {
          Zone = GameObject.Find("AumentoMelee");
          gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
        }
        else if(gameManager.IsPlayerOneTurn && CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Melee && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
        {
          Zone = GameObject.Find("AumentoMelee (1)");
          gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
        }
        else if(gameManager.IsPlayerOneTurn && CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Ranged && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
        {
          Zone = GameObject.Find("AumentoRanged");
          gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
        }
        else if(gameManager.IsPlayerOneTurn && CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Ranged && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
        {
          Zone = GameObject.Find("AumentoRanged (1)");
          gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
        }
        else if(gameManager.IsPlayerOneTurn && CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Siege && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
        {
          Zone = GameObject.Find("AumentoSiege ");
          gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
        }
        else if(gameManager.IsPlayerOneTurn && CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.aumento && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Siege && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
        {
          Zone = GameObject.Find("AumentoSiege  (1)");
          gameManager.IsPlayerOneTurn = !gameManager.IsPlayerOneTurn;
        }
        Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
        Card.transform.position = Zone.transform.position;
    }
    
}
