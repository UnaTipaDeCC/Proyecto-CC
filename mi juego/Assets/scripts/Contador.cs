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
    public int puntos = 0;

    // Update is called once per frame
    void Update()
    {
        int adicionar = 0;
        adicionar = melee.GetComponent<Tablero>().suma + siege.GetComponent<Tablero>().suma + ranged.GetComponent<Tablero>().suma;
        puntos = adicionar;
        contador.text = puntos.ToString();   
    }
}
