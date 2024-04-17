using System;
using System.Collections;
using System.Collections.Generic;
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

    public void RobarUnaCarta()
    {
        /*hand = GameObject.FindGameObjectWithTag("Hand (1)");
        deck = GameObject.FindGameObjectWithTag("Deck (1)");
        // Get a reference to the Draw component on the deck GameObject
        Draw deckDrawComponent = deck.GetComponent<Draw>();
        // Access the CardsInHand and CardsInDeck lists from the Draw component
        cardsinhand = deckDrawComponent.CardsInHand;
        cardsindeck = deckDrawComponent.CardsInDeck;
        int index = UnityEngine.Random.Range(0, cardsindeck.Count);
        GameObject drawCard = Instantiate(cardsindeck[index], new Vector3(0, 0, 0), Quaternion.identity);
        cardsindeck.RemoveAt(index);
        drawCard.transform.SetParent(hand.transform, false);
        cardsinhand.Add(drawCard);*/
        
        hand = GameObject.FindGameObjectWithTag("Hand (1)");
        deck = GameObject.FindGameObjectWithTag("Deck(1)");
        cardsinhand = deck.GetComponent<Draw>().CardsInHand;
        cardsindeck = deck.GetComponent<Draw>().CardsInDeck;
        int index = UnityEngine.Random.Range(0, cardsindeck.Count);
        GameObject drawCard = Instantiate(cardsindeck[index], new Vector3(0,0,0), Quaternion.identity);
        cardsindeck.RemoveAt(index);
        drawCard.transform.SetParent(hand.transform, false);
        cardsinhand.Add(drawCard);

    }
    

//revisa los nombres que cambiaste las variables
/*
void EliminarFilaConMasPoderDelRival(Player player)//(List<Card> melee,List<Card> ranged,List<Card> siege, List<Card> Cementery)//poder del leader
 { 
    int contador_melee = 0;
    int contador_ranged = 0;
    int contador_siege = 0;
    foreach (Card carta in player.CardsInMeleeZone)//melee)
    {
        contador_melee += carta.Damage;
    }
     foreach(Card carta in player.CardsInRangedZone)//ranged)
    {
        contador_ranged += carta.Damage;
    }
     foreach(Card carta in player.CardsInSiegeZone)//siege)
    {
        contador_siege += carta.Damage;
    }
    if(contador_melee >= contador_ranged && contador_melee > contador_siege)
    {
        foreach(Card carta in player.CardsInMeleeZone)//melee)
        {
            if(carta.tipoDeCarta == Card.TipoDeCarta.silver)
            {
                player.CardsInMeleeZone.Remove(carta);
                player.CardsInCementery.Add(carta);
            }
        }
    }
    if((contador_ranged > contador_melee) && (contador_ranged >= contador_siege))
    {
        foreach(Card carta in player.CardsInRangedZone)
        {
            if(carta.tipoDeCarta == Card.TipoDeCarta.silver)
            {
                player.CardsInRangedZone.Remove(carta);
                player.CardsInCementery.Add(carta);
            }
        }
    }
    if(contador_siege >= contador_melee && contador_siege > contador_ranged)
    {
        foreach(Card carta in player.CardsInSiegeZone)
        {
            if(carta.tipoDeCarta == Card.TipoDeCarta.silver)
            {
                player.CardsInSiegeZone.Remove(carta);
                player.CardsInCementery.Add(carta);
            }
        }
    }

}*/
/*public void Aumentar_Damage()
{
    melee = ZonaDeAumento.GetComponent<Tablero>().CartasEnZona;
    ZonaDeAumento.GetComponent<Tablero>().suma = 0;
    foreach(GameObject carta in melee)
    {
        if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == Card.TipoDeCarta.silver)
        {
            carta.GetComponent<cardDisplay>().card.Damage += 2; 
        }
        ZonaDeAumento.GetComponent<Tablero>().suma += carta.GetComponent<cardDisplay>().card.Damage;
    }
}*/
public void EliminarCartaConMenosPoderDelRival()//como hago para quitar la carta de la escena y eliminarlo del contador
{
    filaMelee = GameObject.FindGameObjectWithTag("MeleeZone (1)");
    melee = filaMelee.GetComponent<Tablero>().CartasEnZona;
    filaRanged = GameObject.FindGameObjectWithTag("RangedZone (1)");
    ranged = filaRanged.GetComponent<Tablero>().CartasEnZona;
    filaSiege = GameObject.FindGameObjectWithTag("SiegeZone (1)");
    siege = filaSiege.GetComponent<Tablero>().CartasEnZona;
    
    
    int contador_melee = int.MaxValue;
    int index_melee = 0;
    int contador_ranged = int.MaxValue;
    int index_ranged = 0;
    int contador_siege = int.MaxValue;
    int index_siege = 0;
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
    if(contador_melee <= contador_ranged && contador_melee < contador_siege)
    {
        //player.Cementery.Add(player.Melee[index_melee]);
        //melee.RemoveAt(index_melee);
        Destroy(cartam);
        //GameObject.FindGameObjectWithTag("MeleeZone (1)").GetComponent<Tablero>().CartasEnZona = melee;
        Debug.Log("quite una carta de melee");

    }
    else if(contador_ranged < contador_melee && contador_ranged <= contador_siege)
    {
        //player.Cementery.Add(player.Ranged[index_ranged]);
        //ranged.RemoveAt(index_ranged);
        Destroy(cartar);
        //GameObject.FindGameObjectWithTag("RangedZone (1)").GetComponent<Tablero>().CartasEnZona = ranged;
        Debug.Log("quite una carta de ranged");
    }
    else
    {
        //player.Cementery.Add(player.Siege[index_siege]);
        //siege.RemoveAt(index_siege);
        Destroy(cartas);
        //GameObject.FindGameObjectWithTag("SiegeZone (1)").GetComponent<Tablero>().CartasEnZona = siege;
        Debug.Log("quite una carta de siege");
    }
}
public void EliminarCartaConMasPoderDelRival()//busca el metodo distroy
{
    filaMelee = GameObject.FindGameObjectWithTag("MeleeZone (1)");
    melee = filaMelee.GetComponent<Tablero>().CartasEnZona;
    filaRanged = GameObject.FindGameObjectWithTag("RangedZone (1)");
    ranged = filaRanged.GetComponent<Tablero>().CartasEnZona;
    filaSiege = GameObject.FindGameObjectWithTag("SiegeZone (1)");
    siege = filaSiege.GetComponent<Tablero>().CartasEnZona;
    int contador_melee = int.MinValue;
    int index_melee = 0;
    int contador_ranged = int.MinValue;
    int index_ranged = 0;
    int contador_siege = int.MinValue;
    int index_siege = 0;
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
   // player.Cementery.Add(player.Melee[index_melee]);
    //melee.RemoveAt(index_melee);
    Debug.Log("quite una carta de melee");
    Destroy(cartam);
    //GameObject.FindGameObjectWithTag("MeleeZone (1)").GetComponent<Tablero>().CartasEnZona = melee;
  }
  else if(contador_ranged > contador_melee && contador_ranged >= contador_siege)
  {
    Destroy(cartar);
    //player.Cementery.Add(player.Ranged[index_ranged]);
    //ranged.RemoveAt(index_ranged);
    //GameObject.FindGameObjectWithTag("RangedZone (1)").GetComponent<Tablero>().CartasEnZona = ranged;
    Debug.Log("quite una carta de ranged");
  }
  else
  {
    //player.Cementery.Add(player.Siege[index_siege]);
   // siege.RemoveAt(index_siege);
    //GameObject.FindGameObjectWithTag("SiegeZone (1)").GetComponent<Tablero>().CartasEnZona = siege;
    Destroy(cartas);
    Debug.Log("quite una carta de siege");
  }
}
public void MultiplicarPor_n_ElAtaque()//siendo n la cantidad de cartas igual a ella en el campo
{
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
}
public void IgualarPoderDeCartasAlPromedioDeCartasDelCampoPropio()
{  
    filaMelee = GameObject.FindGameObjectWithTag("MeleeZone (1)");
    melee = filaMelee.GetComponent<Tablero>().CartasEnZona;
    filaRanged = GameObject.FindGameObjectWithTag("RangedZone (1)");
    ranged = filaRanged.GetComponent<Tablero>().CartasEnZona;
    filaSiege = GameObject.FindGameObjectWithTag("SiegeZone (1)");
    siege = filaSiege.GetComponent<Tablero>().CartasEnZona;
    /*int contadormelee = 0;
    int contadorranged = 0;
    int contadorsiege = 0; 
    foreach(GameObject card in melee)
    {
        contadormelee += card.Damage;
    }
     foreach(Cart card in player.Ranged)
    {
        contadorranged += card.Damage;
    }
     foreach(CartaDeUnidad card in player.Siege)
    {
        contadorsiege += card.Damage;
    }*/
    //int promedio = (contadormelee + contadorranged + contadorsiege)/3;

    int promedio = (GameObject.FindGameObjectWithTag("SiegeZone (1)").GetComponent<Tablero>().suma + GameObject.FindGameObjectWithTag("MeleeZone (1)").GetComponent<Tablero>().suma + GameObject.FindGameObjectWithTag("RangedZone (1)").GetComponent<Tablero>().suma)/(melee.Count + siege.Count + ranged.Count);
    Debug.Log("EL PROMEDIO ES" + promedio);
    GameObject.FindGameObjectWithTag("SiegeZone (1)").GetComponent<Tablero>().suma = 0;
    GameObject.FindGameObjectWithTag("MeleeZone (1)").GetComponent<Tablero>().suma = 0;
    GameObject.FindGameObjectWithTag("RangedZone (1)").GetComponent<Tablero>().suma = 0;
    foreach(GameObject carta in melee)
    {
        if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == Card.TipoDeCarta.silver)
        {
            carta.GetComponent<cardDisplay>().card.Damage = promedio;
            //Debug.Log(carta.GetComponent<cardDisplay>().card.Damage);
        }
        GameObject.FindGameObjectWithTag("MeleeZone (1)").GetComponent<Tablero>().suma += carta.GetComponent<cardDisplay>().card.Damage;
    }
    foreach(GameObject carta in siege)
    {
        if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == Card.TipoDeCarta.silver)
        {
           carta.GetComponent<cardDisplay>().card.Damage = promedio;
           //Debug.Log(carta.GetComponent<cardDisplay>().card.Damage);
        }
        GameObject.FindGameObjectWithTag("SiegeZone (1)").GetComponent<Tablero>().suma += carta.GetComponent<cardDisplay>().card.Damage;
    }
    foreach(GameObject carta in ranged)
    {
        if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == Card.TipoDeCarta.silver)
        {
            carta.GetComponent<cardDisplay>().card.Damage = promedio;
            Debug.Log(carta.GetComponent<cardDisplay>().card.Damage);
            //GameObject.FindGameObjectWithTag("RangedZone (1)").GetComponent<Tablero>().suma += carta.GetComponent<cardDisplay>().card.Damage;
        }
        GameObject.FindGameObjectWithTag("RangedZone (1)").GetComponent<Tablero>().suma += carta.GetComponent<cardDisplay>().card.Damage;
    }

}
public void LimpiaLaFilaConMenosUnidades()
{
    filaMelee = GameObject.FindGameObjectWithTag("MeleeZone");
    melee = filaMelee.GetComponent<Tablero>().CartasEnZona;
    filaRanged = GameObject.FindGameObjectWithTag("RangedZone");
    ranged = filaRanged.GetComponent<Tablero>().CartasEnZona;
    filaSiege = GameObject.FindGameObjectWithTag("SiegeZone");
    siege = filaSiege.GetComponent<Tablero>().CartasEnZona;
    if(melee.Count != 0 || siege.Count != 0 || ranged.Count !=0)
    {
        Debug.Log("hay alguna fila no vacia");
        //comprueba cual es la fila que menos cartas tiene
        if(melee.Count != 0 && (melee.Count <= ranged.Count) && (melee.Count < siege.Count) )
        {
            Debug.Log("melee es la que menos tiene");
            List<GameObject> cartasAEliminar = new List<GameObject>();
            foreach(GameObject carta in melee)
            {
                if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == Card.TipoDeCarta.silver)
                {
                    cartasAEliminar.Add(carta);
                    //melee.Remove(carta);
                    //player.Cementery.Add(carta);
                }
            }
            foreach(GameObject carta in cartasAEliminar)
            {
                Destroy(carta);
            }
            // GameObject.FindGameObjectWithTag("MeleeZone").GetComponent<Tablero>().CartasEnZona = melee;
        }
        else if(ranged.Count != 0 && ( ranged.Count < melee.Count) && (ranged.Count <= siege.Count))
        {
            Debug.Log("ranged es la que menos tiene");
            List<GameObject> cartasAEliminar = new List<GameObject>();
            foreach(GameObject carta in ranged)
            {
                if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == Card.TipoDeCarta.silver)
                {
                    cartasAEliminar.Add(carta);
                    //ranged.Remove(carta);
                    //player.Cementery.Add(carta);
                }
            }
             foreach(GameObject carta in cartasAEliminar)
            {
                Destroy(carta);
            }
            // GameObject.FindGameObjectWithTag("RangedZone").GetComponent<Tablero>().CartasEnZona = ranged;
        }
        else if(siege.Count != 0 && (siege.Count <= melee.Count) && (siege.Count < ranged.Count))
        {
            Debug.Log("SIEGE es la que menos tiene");
            List<GameObject> cartasAEliminar = new List<GameObject>();
            foreach(GameObject carta in siege)
            {
                if(carta.GetComponent<cardDisplay>().card.tipoDeCarta == Card.TipoDeCarta.silver)
                {
                    cartasAEliminar.Add(carta);
                    //siege.Remove(carta);
                    //player.Cementery.Add(carta);
                }
            }
             foreach(GameObject carta in cartasAEliminar)
            {
                Destroy(carta);
            }
             //GameObject.FindGameObjectWithTag("SiegeZone").GetComponent<Tablero>().CartasEnZona = siege;
        }
    }
}

}