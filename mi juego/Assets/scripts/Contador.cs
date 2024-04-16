using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Contador : MonoBehaviour
{
    public TextMeshProUGUI contador;
    public GameObject  melee;
    public GameObject ranged;
    public GameObject siege; 
    private int puntos = 0;


    // Start is called before the first frame update
  /*  void Start()
    {
        int sumatotal = 0;

        contador.text = sumatotal.ToString();

        obj1 = GameObject.FindGameObjectWithTag("MeleeZone");
        melee = obj1.GetComponent<Tablero>().suma; 
        obj2 = GameObject.FindGameObjectWithTag("RangedZone");
        ranged = obj2.GetComponent<Tablero>().suma;
        obj3 = GameObject.FindGameObjectWithTag("SiegeZone");
        siege = obj3.GetComponent<Tablero>().suma;
    }
    private void ActualizarContador()
    {
        int adicionar = 0;
        adicionar = melee.GetComponent<Tablero>().suma + siege.GetComponent<Tablero>().suma + ranged.GetComponent<Tablero>().suma;

       sumatotal = melee + ranged + siege; 
    }*/



    // Update is called once per frame
    void Update()
    {
        int adicionar = 0;
        adicionar = melee.GetComponent<Tablero>().suma + siege.GetComponent<Tablero>().suma + ranged.GetComponent<Tablero>().suma;
        puntos = adicionar;
        contador.text = puntos.ToString();   
    }
}
