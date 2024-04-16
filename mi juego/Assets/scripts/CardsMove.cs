using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class CardsMove : MonoBehaviour
{
    public GameObject Zone;
     public GameObject Card;
     public Card CardInfo;
    void Start()
    {
        
    }
    public void OnClick()
    {
        if(CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Melee && CardInfo.faccion == global::Card.Faccion.Hormigas_Bravas)
        {
             Zone = GameObject.Find("MeleeZone");
             GameObject tableroObj = GameObject.Find("Melee");
             
        }
       
        else if(CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Ranged && CardInfo.faccion == global::Card.Faccion.Hormigas_Bravas)
        {
            Zone = GameObject.Find("RangedZone");
        
        }
        else if(CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Siege && CardInfo.faccion == global::Card.Faccion.Hormigas_Bravas)
        {
            Zone = GameObject.Find("SiegeZone");
        }
        if(CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Melee && CardInfo.faccion == global::Card.Faccion.Hormigas_Locas)
        {
            Zone = GameObject.Find("MeleeZone (1)");
        }
        else if(CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Ranged && CardInfo.faccion == global::Card.Faccion.Hormigas_Locas)
        {
            Zone = GameObject.Find("RangedZone (1)");
            Debug.Log(CardInfo.Damage);
        }
        else if(CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Siege && CardInfo.faccion == global::Card.Faccion.Hormigas_Locas)
        {
            Zone = GameObject.Find("SiegeZone (1)");
        }

        Card.transform.SetParent(Zone.transform, false); // mover la carta a la zona deseada 
        Card.transform.position = Zone.transform.position;

    }
    
}
/*using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class CardsMove : MonoBehaviour
{
    public GameObject Zone;
    public static List<GameObject> CardsInZone = new List<GameObject>();
    public GameObject Card;
    public Card CardInfo;
    private Tablero tableroScript;

    void Start()
    {
        // Buscar el objeto Tablero en la escena
        GameObject tableroObj = GameObject.FindObjectOfType<Tablero>().gameObject;

        // Si se encuentra el objeto Tablero, obtener su componente Tablero
        if (tableroObj != null)
        {
            tableroScript = tableroObj.GetComponent<Tablero>();
        }
        else
        {
            // Si no se encuentra el objeto Tablero, crear una nueva instancia de Tablero
            GameObject nuevoTableroObj = new GameObject("Tablero");
            tableroScript = nuevoTableroObj.AddComponent<Tablero>();
        }
    }

    public void OnClick()
    {
        if (CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Melee && CardInfo.faccion == global::Card.Faccion.Hormigas_Bravas)
        {
            Zone = GameObject.Find("MeleeZone");
            tableroScript.Melee.Add(Card);
        }
        else if (CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Ranged && CardInfo.faccion == global::Card.Faccion.Hormigas_Bravas)
        {
            Zone = GameObject.Find("RangedZone");
            tableroScript.Ranged.Add(Card);
        }
        else if (CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Siege && CardInfo.faccion == global::Card.Faccion.Hormigas_Bravas)
        {
            Zone = GameObject.Find("SiegeZone");
            tableroScript.Siege.Add(Card);
        }
        if (CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Melee && CardInfo.faccion == global::Card.Faccion.Hormigas_Locas)
        {
            Zone = GameObject.Find("MeleeZone (1)");
            tableroScript.Melee1.Add(Card);
        }
        else if (CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Ranged && CardInfo.faccion == global::Card.Faccion.Hormigas_Locas)
        {
            Zone = GameObject.Find("RangedZone (1)");
            tableroScript.Ranged1.Add(Card);
        }
        else if (CardInfo.tipoDeAtaque == global::Card.TipoDeAtaque.Siege && CardInfo.faccion == global::Card.Faccion.Hormigas_Locas)
        {
            Zone = GameObject.Find("SiegeZone (1)");
            tableroScript.Siege1.Add(Card);
        }

        Card.transform.SetParent(Zone.transform, false);
        Card.transform.position = Zone.transform.position;
        CardsInZone.Add(Card);
    }
}*/