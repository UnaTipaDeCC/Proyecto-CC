using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite artwork;
    public bool jugada = false;
    public int Damage;
    //public string TipoDeAtaque;
    public enum TipoDeAtaque{
        Melee,
        Siege,
        Ranged,
    }
    public Faccion faccion;
    public TipoDeCarta tipoDeCarta;
    public TipoDeAtaque tipoDeAtaque;
    public Power power;
    public enum TipoDeCarta{
        gold,
        silver,
    }
    public enum Faccion//esto lo tienen las cartas todas, no solo las de unidad
    {
        Hormigas_Bravas,
        Hormigas_Locas,
        Neutral,
    }
     public enum Power{
        Ninguno,
        PonerUnAumento,
        PonerUnClima,
        LimpiarFilaConMenosUnidades,
        MultiplicarPor_n_ElAtaque,
        IgualarPoderDeCartasAlPromedioDeCartasDelCampoPropio,
        RobarUnaCarta,
        EliminarCartaConMenosPoderDelRival,
        EliminarCartaConMasPoderDelRival,

    }

    
}
