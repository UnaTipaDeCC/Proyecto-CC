using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCardsControl : MonoBehaviour
{
    public GameObject Zone;
    //public static List<GameObject> CardsInZone = new List<GameObject>();
     public GameObject Card;
     public SpecialCards CardInfo;
     //List<GameObject> list;
    // Start is called before the first frame update
    void Start()
    {
        //Card = this.gameObject;
        //CardInfo = this.gameObject.GetComponent<Card>();
       //Card.GetComponent<Il2CppCodeGeneration>().
    }
    public void OnClick()
    {
        if((CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima || CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje) && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Melee)// && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
        {
             Zone = GameObject.Find("MeleeClima");
        }
        if((CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima || CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje) && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Ranged )//&& CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
        {
             Zone = GameObject.Find("RangedClima");
        }
        else if((CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima || CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.despeje) && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Siege)// && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Bravas)
        {
             Zone = GameObject.Find("SiegeClima");
        }
        /*else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Melee && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
        {
             Zone = GameObject.Find("MeleeClima (1)");
        }
        else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Ranged && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
        {
             Zone = GameObject.Find("RangedClima (1)");
        }
        else if(CardInfo.tipoDeCarta == SpecialCards.TipoDeCarta.clima && CardInfo.zonaQueAfecta == SpecialCards.ZonaQueAfecta.Siege && CardInfo.faccion == SpecialCards.Faccion.Hormigas_Locas)
        {
             Zone = GameObject.Find("SiegeClima (1)");
        }*/
        Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
        Card.transform.position = Zone.transform.position;
//        list.Add(Card);
        //CardsInZone.Add(Card); // agregar carta a la lista de la zona

    }
    
}
