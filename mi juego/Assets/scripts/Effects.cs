using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class Effects : MonoBehaviour
{
    private GameObject filaMelee;
    private GameObject hand;
    private GameObject deck;
    private List<GameObject> cardsinhand;
    private List<GameObject> cardsindeck;
    private GameObject filaRanged;
    private GameObject filaSiege;
    private List<GameObject> melee;
    private List<GameObject> ranged;
    private List<GameObject> siege;
    private GameObject cartam;
    private GameObject cartar;
    private GameObject cartas;
    public GameObject ZonaDeAumento;
    private GameManager gameManager;
    private GameObject Cementery;
    private bool ActivoElEfecto = false;
    private bool condicion;
    public GameObject  carta;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    public void RobarUnaCarta()
    {
        hand = GameObject.FindGameObjectWithTag("Hand (1)");
        deck = GameObject.FindGameObjectWithTag("Deck(1)");
        cardsinhand = deck.GetComponent<Draw>().CardsInHand;
        cardsindeck = deck.GetComponent<Draw>().CardsInDeck;
        if(ActivoElEfecto == false)
{
            if(gameManager.playerOnePassed == true)
            {
                condicion = !gameManager.IsPlayerOneTurn;
            }
            else condicion = gameManager.IsPlayerOneTurn; 
            if(gameManager.playerTwoPassed == false && condicion)//(!gameManager.IsPlayerOneTurn)
            {
            
            int index = UnityEngine.Random.Range(0, cardsindeck.Count);
            GameObject drawCard = Instantiate(cardsindeck[index], new Vector3(0,0,0), Quaternion.identity);
            cardsindeck.RemoveAt(index);
            drawCard.transform.SetParent(hand.transform, false);
            cardsinhand.Add(drawCard);
            ActivoElEfecto = true;
            Debug.Log("active el efecto");
            }
    }
    }
    public void EliminarCartaConMenosPoderDelRival()
    {
        bool condicion;//al activar el on click compila primero el cardsmove y se cambia el turno 
        if(gameManager.playerTwoPassed == true)
        {
            condicion = gameManager.IsPlayerOneTurn;
        }
        else condicion = !gameManager.IsPlayerOneTurn;
        if(gameManager.playerOnePassed == false && condicion)
       // if(gameManager.IsPlayerOneTurn)
        {
            if(ActivoElEfecto == false)
            {
            Debug.Log("activo esto xq es mi turno");
            filaMelee = GameObject.FindGameObjectWithTag("MeleeZone (1)");
            melee = filaMelee.GetComponent<Tablero>().CartasEnZona;
            filaRanged = GameObject.FindGameObjectWithTag("RangedZone (1)");
            ranged = filaRanged.GetComponent<Tablero>().CartasEnZona;
            filaSiege = GameObject.FindGameObjectWithTag("SiegeZone (1)");
            siege = filaSiege.GetComponent<Tablero>().CartasEnZona;
            Cementery = GameObject.FindGameObjectWithTag("Cementery (1)");
            
            
            int contador_melee = int.MaxValue;
            int index_melee = 0;
            int contador_ranged = int.MaxValue;
            int index_ranged = 0;
            int contador_siege = int.MaxValue;
            int index_siege = 0;
            if(melee.Count!= 0 || ranged.Count!= 0 || siege.Count!= 0)
            {
                foreach(GameObject carta in melee)//busca la carta con menos poder de la zona melee
                {
                    if(carta.GetComponent<cardDisplay>().card.Damage < contador_melee)
                    {
                        contador_melee = carta.GetComponent<cardDisplay>().card.Damage;
                        index_melee = melee.IndexOf(carta);
                        cartam = carta;
                    }
                }
                foreach(GameObject carta in ranged) //busca la carta con menos poder de la zona ranged
                {
                    if(carta.GetComponent<cardDisplay>().card.Damage < contador_ranged)
                    {
                        contador_ranged = carta.GetComponent<cardDisplay>().card.Damage;
                        index_ranged = ranged.IndexOf(carta);
                        cartar = carta;
                    }
                } 
                foreach(GameObject carta in siege) //busca la zona con menos poder de la zona siege
                {
                    if(carta.GetComponent<cardDisplay>().card.Damage < contador_siege)
                    {
                        contador_siege = carta.GetComponent<cardDisplay>().card.Damage;
                        index_siege = siege.IndexOf(carta);
                        cartas = carta;
                    }
                }
                //compara las cartas encontradas y elimina la de menor poder de su respectiva fila
                if(melee.Count != 0 && contador_melee <= contador_ranged && contador_melee < contador_siege)
                {
                    cartam.transform.SetParent(Cementery.transform, false); // mover la carta a la zona deseada 
                    cartam.transform.position = Cementery.transform.position;
                    Debug.Log("AGREGUE A LA LISTA CEMENTERY");
                    Debug.Log("quite una carta de melee");

                }
                else if(ranged.Count != 0 && contador_ranged < contador_melee && contador_ranged <= contador_siege)
                {
                    cartar.transform.SetParent(Cementery.transform, false); // mover la carta a la zona deseada 
                    cartar.transform.position = Cementery.transform.position;
                    Debug.Log("AGREGUE A LA LISTA CEMENTERY");
                    Debug.Log("quite una carta de ranged");
                }
                else
                {
                    cartas.transform.SetParent(Cementery.transform, false); // mover la carta a la zona deseada 
                    cartas.transform.position = Cementery.transform.position;
                    Debug.Log("quite una carta de siege");
                }
            }
            }    
        }
    }
    public void EliminarCartaConMasPoderDelRival()
    {
        bool condicion;
        if(gameManager.playerTwoPassed == true)
        {
            condicion = gameManager.IsPlayerOneTurn;
        }
        else condicion = !gameManager.IsPlayerOneTurn;
        if(gameManager.playerOnePassed == false && condicion)
        //if(gameManager.IsPlayerOneTurn)
        {
            if(ActivoElEfecto == false)
            {
             Debug.Log("activo esto xq es mi turno");
            filaMelee = GameObject.FindGameObjectWithTag("MeleeZone (1)");
            melee = filaMelee.GetComponent<Tablero>().CartasEnZona;
            filaRanged = GameObject.FindGameObjectWithTag("RangedZone (1)");
            ranged = filaRanged.GetComponent<Tablero>().CartasEnZona;
            filaSiege = GameObject.FindGameObjectWithTag("SiegeZone (1)");
            siege = filaSiege.GetComponent<Tablero>().CartasEnZona;
            Cementery = GameObject.FindGameObjectWithTag("Cementery (1)");
            int contador_melee = int.MinValue;
            int index_melee = 0;
            int contador_ranged = int.MinValue;
            int index_ranged = 0;
            int contador_siege = int.MinValue;
            int index_siege = 0;
            if(melee.Count != 0 || siege.Count != 0 || ranged.Count != 0)
            {
            foreach(GameObject carta in melee)//encuentra la carta mas poder de la zona melee
            {
                if(carta.GetComponent<cardDisplay>().card.Damage > contador_melee) 
                {
                    contador_melee = carta.GetComponent<cardDisplay>().card.Damage;
                    index_melee = melee.IndexOf(carta);
                    cartam = carta;
                }
            }
            foreach(GameObject carta in ranged)//encuentra la carta con mas poderde la zona ranged
            {
                if(carta.GetComponent<cardDisplay>().card.Damage > contador_ranged)
                {
                    contador_ranged = carta.GetComponent<cardDisplay>().card.Damage;
                    index_ranged = ranged.IndexOf(carta);
                    cartar = carta;
                }
            } 
            foreach(GameObject carta in siege)//encuentra la carta con mas poder de la zona siege
            {
                if(carta.GetComponent<cardDisplay>().card.Damage > contador_siege)
                {
                    contador_siege = carta.GetComponent<cardDisplay>().card.Damage;
                    index_siege = siege.IndexOf(carta);
                    cartas = carta;
                }
            }
            //comparar cual de las cartas tiene mas poder y eliminarla de la fila
            if(contador_melee >= contador_ranged && contador_melee > contador_siege)
            {
                Debug.Log("quite una carta de melee");
                cartam.transform.SetParent(Cementery.transform, false); // mover la carta al cementerio
                cartam.transform.position = Cementery.transform.position;
            }
            else if(contador_ranged > contador_melee && contador_ranged >= contador_siege)
            {
                cartar.transform.SetParent(Cementery.transform, false); // mover la carta al cementerio
                cartar.transform.position = Cementery.transform.position;
                Debug.Log("quite una carta de ranged");
            }
            else
            {
                cartas.transform.SetParent(Cementery.transform, false); // mover la carta al cementerio
                cartas.transform.position = Cementery.transform.position;
                Debug.Log("quite una carta de siege");
            }
            }
            ActivoElEfecto = true;
            }
        }
    }
    public void MultiplicarPor_n_ElAtaque()//siendo n la cantidad de cartas igual a ella en el campo
    {
        /*bool condicion;
        if(gameManager.playerTwoPassed == true)
        {
            condicion = gameManager.IsPlayerOneTurn;
        }
        else condicion = !gameManager.IsPlayerOneTurn;
        if(gameManager.playerOnePassed == false && condicion)*/
        if(gameManager.IsPlayerOneTurn)
        {
            if(ActivoElEfecto == false)
            {
             Debug.Log("activo esto xq es mi turno");
            filaRanged = GameObject.FindGameObjectWithTag("RangedZone");
            ranged = filaRanged.GetComponent<Tablero>().CartasEnZona;
            int contador = 1;
        
                foreach(GameObject carta in ranged)
                {
                    if(carta.GetComponent<cardDisplay>().card.name == "Hormigatrixx")
                    {
                        contador++;
                    }
                }
                GetComponent<cardDisplay>().card.Damage *= contador;
            ActivoElEfecto = true;
            }    
        }
        else Debug.Log("no afecto xq no es mi turno");
    }
    public void IgualarPoderDeCartasAlPromedioDeCartasDelCampoPropio()
    {
        bool condicion;
        if(gameManager.playerOnePassed == true)
        {
            condicion = !gameManager.IsPlayerOneTurn;
        }
        else condicion = gameManager.IsPlayerOneTurn;    
        if(gameManager.playerTwoPassed == false && condicion)
       // if(!gameManager.IsPlayerOneTurn)
        {
            if(ActivoElEfecto == false)
        
        {
            Debug.Log("activo esto xq es mi turno");
            filaMelee = GameObject.FindGameObjectWithTag("MeleeZone (1)");
            melee = filaMelee.GetComponent<Tablero>().CartasEnZona;
            filaRanged = GameObject.FindGameObjectWithTag("RangedZone (1)");
            ranged = filaRanged.GetComponent<Tablero>().CartasEnZona;
            filaSiege = GameObject.FindGameObjectWithTag("SiegeZone (1)");
            siege = filaSiege.GetComponent<Tablero>().CartasEnZona;
            if(melee.Count != 0 || ranged.Count != 0 || siege.Count != 0)
            {
                int promedio = (GameObject.FindGameObjectWithTag("SiegeZone (1)").GetComponent<Tablero>().suma + GameObject.FindGameObjectWithTag("MeleeZone (1)").GetComponent<Tablero>().suma + GameObject.FindGameObjectWithTag("RangedZone (1)").GetComponent<Tablero>().suma)/(melee.Count + siege.Count + ranged.Count);
                Debug.Log("EL PROMEDIO ES" + promedio);
                GameObject.FindGameObjectWithTag("SiegeZone (1)").GetComponent<Tablero>().suma = 0;
                GameObject.FindGameObjectWithTag("MeleeZone (1)").GetComponent<Tablero>().suma = 0;
                GameObject.FindGameObjectWithTag("RangedZone (1)").GetComponent<Tablero>().suma = 0;
                foreach(GameObject carta in melee)
                {
                    carta.GetComponent<cardDisplay>().card.Damage = promedio;
                    GameObject.FindGameObjectWithTag("MeleeZone (1)").GetComponent<Tablero>().suma += carta.GetComponent<cardDisplay>().card.Damage;
                }
                foreach(GameObject carta in siege)
                {
                    carta.GetComponent<cardDisplay>().card.Damage = promedio;
                    GameObject.FindGameObjectWithTag("SiegeZone (1)").GetComponent<Tablero>().suma += carta.GetComponent<cardDisplay>().card.Damage;
                }
                foreach(GameObject carta in ranged)
                {
                        carta.GetComponent<cardDisplay>().card.Damage = promedio;
                        Debug.Log(carta.GetComponent<cardDisplay>().card.Damage);
                    GameObject.FindGameObjectWithTag("RangedZone (1)").GetComponent<Tablero>().suma += carta.GetComponent<cardDisplay>().card.Damage;
                }
            }
        }
        ActivoElEfecto = true;
        }
        else Debug.Log("no afecto xq no es mi turno");
    }
    public void LimpiaLaFilaConMenosUnidades()
    {
        bool condicion;
        if(gameManager.playerOnePassed == true)
        {
            condicion = !gameManager.IsPlayerOneTurn;
        }
        else condicion = gameManager.IsPlayerOneTurn; 
        if(condicion)
        //if(!gameManager.IsPlayerOneTurn)
        {
            if(ActivoElEfecto == false)
            {
             Debug.Log("activo esto xq es mi turno");
            filaMelee = GameObject.FindGameObjectWithTag("MeleeZone");
            melee = filaMelee.GetComponent<Tablero>().CartasEnZona;
            filaRanged = GameObject.FindGameObjectWithTag("RangedZone");
            ranged = filaRanged.GetComponent<Tablero>().CartasEnZona;
            filaSiege = GameObject.FindGameObjectWithTag("SiegeZone");
            siege = filaSiege.GetComponent<Tablero>().CartasEnZona;
            Cementery = GameObject.FindGameObjectWithTag("Cementery");
            if(melee.Count > 0 || siege.Count > 0 || ranged.Count > 0)
            {
                Debug.Log("hay alguna fila no vacia");
                //comprueba cual es la fila que menos cartas tiene
                if((melee.Count <= ranged.Count) && (melee.Count < siege.Count) )
                {
                    Debug.Log("melee es la que menos tiene");
                    foreach(GameObject carta in melee)
                    {
                            carta.transform.SetParent(Cementery.transform, false);
                            carta.transform.position = Cementery.transform.position; 
                            //Debug.Log("HAY UNA CArtA DE PLATA Y LA VOY A METER EN LA LISTA");
        
                    }
                }
                else if(ranged.Count < melee.Count && (ranged.Count <= siege.Count))
                {
                    Debug.Log("ranged es la que menos tiene");
                    foreach(GameObject carta in ranged)
                    {
                            carta.transform.SetParent(Cementery.transform, false);
                            carta.transform.position = Cementery.transform.position;
                    }
                }
                else if((siege.Count <= melee.Count) && (siege.Count < ranged.Count))
                {
                    Debug.Log("SIEGE es la que menos tiene");
                    foreach(GameObject carta in siege)
                    {
                            carta.transform.SetParent(Cementery.transform, false);
                            carta.transform.position = Cementery.transform.position;
                    }
                }
            }
            ActivoElEfecto = true;
            }
        }
        //else Debug.Log("no afecto xq no es mi turno");
    }

}