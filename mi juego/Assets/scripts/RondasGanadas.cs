using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RondasGanadas : MonoBehaviour
{
    public TextMeshProUGUI rondasGanadas;
    public GameManager gameManager;
    public int cuantas;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        cuantas = 0;
    }
    

    // Update is called once per frame
    void Update()
    {
        if(rondasGanadas.CompareTag("Rondas Ganadas"))
        {
            cuantas = gameManager.rondasGanadas1;
        }
        else if(rondasGanadas.CompareTag("Rondas Ganadas (1)"))
        {
            cuantas = gameManager.rondasGanadas2;
        }
        rondasGanadas.text = cuantas.ToString();
    }
}
