using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public GameObject filaMelee;
    public GameObject filaRanged;
    public GameObject filaSiege;
    public List<GameObject> melee;
    public List<GameObject> ranged;
    public List<GameObject> siege;
    /*
    /*void RobarUnaCarta(Player player)//ingresar aleatoriamente las cartas a la mano de cada jugador (EN UNITY LO TENDRE QUE CAMBIAR)
    {
        if(player.Hand.Count < 10)
        {
            Random random = new Random();
            int indiceAleatorio = random.Next(0,player.Deck.Count);
            player.Hand.Add(player.Deck[indiceAleatorio]);
        }        
    }
void EntrarEfecto()
 {
    if()
    
 }
void ActualizarContador(Player player, int contador)
{ 
    int contador_melee = 0;
    int contador_siege= 0;
    int contador_ranged =  0;
    foreach(Card card in player.CardsInMeleeZone)
    {
        contador_melee += card.Damage;
    }
     foreach(Card card in player.CardsInRangedZone)
    {
        contador_melee += card.Damage;
    }
     foreach(Card card in player.CardsInSiegeZone)
    {
        contador_melee += card.Damage;
    }
    contador += contador_melee + contador_ranged + contador_siege;
}
//revisa los nombres que cambiaste las variables
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
void EliminarCartaConMenosPoderDelRival()
{
    filaMelee = GameObject.FindGameObjectWithTag("MeleeZone1");
    melee = filaMelee.GetComponent<Tablero>().CartasEnZona;
    filaRanged = GameObject.FindGameObjectWithTag("RangedZone1");
    ranged = filaRanged.GetComponent<Tablero>().CartasEnZona;
    filaSiege = GameObject.FindGameObjectWithTag("SiegeZone1");
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
    }
  }
  foreach(GameObject carta in ranged) //busca la carta con menos poder de la zona ranged
  {
    if(carta.GetComponent<cardDisplay>().card.Damage < contador_ranged)
    {
        contador_ranged = carta.GetComponent<cardDisplay>().card.Damage;
        index_ranged = ranged.IndexOf(carta);
    }
  } 
  foreach(GameObject carta in siege) //busca la zona con menos poder de la zona siege
  {
    if(carta.GetComponent<cardDisplay>().card.Damage < contador_siege)
    {
        contador_siege = carta.GetComponent<cardDisplay>().card.Damage;
        index_siege = siege.IndexOf(carta);
    }
  }
  //compara las cartas encontradas y elimina a de menor poder de su respectiva fila
  if(contador_melee <= contador_ranged && contador_melee < contador_siege)
  {
    //player.Cementery.Add(player.Melee[index_melee]);
    melee.RemoveAt(index_melee);
    GameObject.FindGameObjectWithTag("MeleeZone1").GetComponent<Tablero>().CartasEnZona = melee;

  }
  else if(contador_ranged < contador_melee && contador_ranged <= contador_siege)
  {
    //player.Cementery.Add(player.Ranged[index_ranged]);
    ranged.RemoveAt(index_ranged);
    GameObject.FindGameObjectWithTag("RangedZone1").GetComponent<Tablero>().CartasEnZona = ranged;
  }
  else
  {
    //player.Cementery.Add(player.Siege[index_siege]);
    siege.RemoveAt(index_siege);
    GameObject.FindGameObjectWithTag("SiegeZone1").GetComponent<Tablero>().CartasEnZona = siege;
  }
}
void EliminarCartaConMasPoderDelRival()//busca el metodo distroy
{
    filaMelee = GameObject.FindGameObjectWithTag("MeleeZone1");
    melee = filaMelee.GetComponent<Tablero>().CartasEnZona;
    filaRanged = GameObject.FindGameObjectWithTag("RangedZone1");
    ranged = filaRanged.GetComponent<Tablero>().CartasEnZona;
    filaSiege = GameObject.FindGameObjectWithTag("SiegeZone1");
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
    }
  }
  foreach(GameObject carta in ranged)//encuentra la carta con mas poderde la zona ranged
  {
    if(carta.GetComponent<cardDisplay>().card.Damage > contador_ranged)
    {
        contador_ranged = carta.GetComponent<cardDisplay>().card.Damage;
        index_ranged = ranged.IndexOf(carta);
    }
  } 
  foreach(GameObject carta in siege)//encuentra lacarta con mas poder de la zona siege
  {
    if(carta.GetComponent<cardDisplay>().card.Damage > contador_siege)
    {
        contador_siege = carta.GetComponent<cardDisplay>().card.Damage;
        index_siege = siege.IndexOf(carta);
    }
  }
  //comparar cual de las cartas tiene mas poder y eliminarla de la fila
  if(contador_melee >= contador_ranged && contador_melee > contador_siege)
  {
   // player.Cementery.Add(player.Melee[index_melee]);
    melee.RemoveAt(index_melee);
    GameObject.FindGameObjectWithTag("MeleeZone1").GetComponent<Tablero>().CartasEnZona = melee;
  }
  else if(contador_ranged > contador_melee && contador_ranged >= contador_siege)
  {
    //player.Cementery.Add(player.Ranged[index_ranged]);
    ranged.RemoveAt(index_ranged);
    GameObject.FindGameObjectWithTag("RangedZone1").GetComponent<Tablero>().CartasEnZona = ranged;
  }
  else
  {
    //player.Cementery.Add(player.Siege[index_siege]);
    siege.RemoveAt(index_siege);
    GameObject.FindGameObjectWithTag("SiegeZone1").GetComponent<Tablero>().CartasEnZona = siege;
  }
}


/*
void MultiplicarPor_n_ElAtaque(Player player, CartaDeUnidad card)//siendo n la cantidad de cartas igual a ella en el campo
{
    int contador = 0;
    if(card.tipoDeAtaque == CartaDeUnidad.TipoDeAtaque.Melee)
    {
        foreach(CartaDeUnidad carta in player.Melee)
        {
            if(card.Name == carta.Name)
            {
                contador++;
            }
        }
        card.Damage *= contador;
    }
     if(card.tipoDeAtaque == CartaDeUnidad.TipoDeAtaque.Siege)
    {
        foreach(CartaDeUnidad carta in player.Siege)
        {
            if(card.Name == carta.Name)
            {
                contador++;
            }
        }
        card.Damage *= contador;
    }
     if(card.tipoDeAtaque == CartaDeUnidad.TipoDeAtaque.Ranged)
    {
        foreach(CartaDeUnidad carta in player.Ranged)
        {
            if(card.Name == carta.Name)
            {
                contador++;
            }
        }
        card.Damage *= contador;
    }
}
void IgualarPoderDeCartasAlPromedioDeCartasDelCampoPropio(Player player)//(List<Card> melee, List<Card> siege, List<Card> ranged)
{ int contadormelee = 0;
  int contadorranged = 0;
  int contadorsiege = 0; 
    foreach(CartaDeUnidad card in player.Melee)
    {
        contadormelee += card.Damage;
    }
     foreach(CartaDeUnidad card in player.Ranged)
    {
        contadorranged += card.Damage;
    }
     foreach(CartaDeUnidad card in player.Siege)
    {
        contadorsiege += card.Damage;
    }
    int promedio = (contadormelee + contadorranged + contadorsiege)/3;
    foreach(CartaDeUnidad card in player.Melee)
    {
        if(card.tipoDeCarta == CartaDeUnidad.TipoDeCarta.silver)
        {
            card.Damage = promedio;
        }
    }
    foreach(CartaDeUnidad card in player.Siege)
    {
        if(card.tipoDeCarta == CartaDeUnidad.TipoDeCarta.silver)
        {
            card.Damage = promedio;
        }
    }
    foreach(CartaDeUnidad card in player.Ranged)
    {
        if(card.tipoDeCarta == CartaDeUnidad.TipoDeCarta.silver)
        {
            card.Damage = promedio;
        }
    }

}
void LimpiaLaFilaConMenosUnidades(Player player)//(List<Card> melee, List<Card> siege, List<Card> ranged, List<Card> Cementery)
{
    if(player.Melee.Count == 0 || player.Siege.Count == 0 || player.Ranged.Count ==0)
    {
        if((player.Melee.Count <= player.Ranged.Count) && (player.Melee.Count < player.Siege.Count))
        {
            foreach(CartaDeUnidad carta in player.Melee)
            {
                if(carta.tipoDeCarta == CartaDeUnidad.TipoDeCarta.silver)
                {
                    player.Melee.Remove(carta);
                    player.Cementery.Add(carta);
                }
            }
        }
        else if((player.Ranged.Count < player.Melee.Count) && (player.Ranged.Count <= player.Siege.Count))
        {
            foreach(CartaDeUnidad carta in player.Ranged)
            {
                if(carta.tipoDeCarta == CartaDeUnidad.TipoDeCarta.silver)
                {
                    player.Ranged.Remove(carta);
                    player.Cementery.Add(carta);
                }
            }
        }
        else if((player.Siege.Count <= player.Melee.Count) && (player.Siege.Count < player.Ranged.Count))
        {
            foreach(CartaDeUnidad carta in player.Siege)
            {
                if(carta.tipoDeCarta == CartaDeUnidad.TipoDeCarta.silver)
                {
                    player.Siege.Remove(carta);
                    player.Cementery.Add(carta);
                }
            }
        }
    }
}
*/
}