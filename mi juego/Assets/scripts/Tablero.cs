/*using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    public List<GameObject> Melee = new List<GameObject>();
    public List<GameObject> Melee1 = new List<GameObject>();
    public List<GameObject> Ranged = new List<GameObject>();
    public List<GameObject> Ranged1 = new List<GameObject>();
    public List<GameObject> Siege = new List<GameObject>();
    public List<GameObject> Siege1 = new List<GameObject>();
    public GameObject = CARD;

    void OnCollisionEnter(Collision collision)
{
    CARD = collision.gameObject;

    if (collidedObject.CompareTag("Card"))//comprueba que lo que colisiona es una carta
    {
        //Comprueba con que zona esta  colisionando la carta
        if (gameObject.CompareTag("MeleeZone"))
        {
            Melee.Add(collidedObject);
            
        }
        else if (gameObject.CompareTag("RangedZone"))
        {
            Ranged.Add(collidedObject);
            
        }
        else if (gameObject.CompareTag("SiegeZone"))
        {
            Siege.Add(collidedObject);
            
        }
        else if (gameObject.CompareTag("RangedZone (1)"))
        {
            Ranged1.Add(collidedObject);
            
        }
        else if (gameObject.CompareTag("SiegeZone (1)"))
        {
            Siege1.Add(collidedObject);
            
        }
        else if (gameObject.CompareTag("MeleeZone (1)"))
        {
            Melee1.Add(collidedObject);
            
        }

    }
}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    public GameObject CARD;
    public List<GameObject> CartasEnZona = new List<GameObject>();
    public int suma = 0;
    public int turno = 0;
    void Start()
    {

    }
    public int SumarPuntos()
    { 
        foreach (GameObject item in CartasEnZona)
        {
                int puntos = item.GetComponent<cardDisplay>().card.Damage;
                suma+=puntos;
        }
        return suma ;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        CARD = collision.gameObject;
        CartasEnZona.Add(CARD);
        suma += CARD.GetComponent<cardDisplay>().card.Damage;
       /* foreach (GameObject item in CartasEnZona)
        {
            if(sumada == false)
            {
                int puntos = item.GetComponent<cardDisplay>().card.Damage;
                suma +=puntos;
                sumada = true;
            }

        }*/
    }
         void OnCollisionExit2D(Collision2D collision)
    {
        // Quita la carta si ya no esta colisionando 
        if (CartasEnZona.Contains(collision.gameObject))
        {
            CARD = collision.gameObject;
            CartasEnZona.Remove(CARD);
            suma -= CARD.GetComponent<cardDisplay>().card.Damage;

        }
    }

    /*public List<GameObject> Melee = new List<GameObject>();
    public List<GameObject> Melee1 = new List<GameObject>();
    public List<GameObject> Ranged = new List<GameObject>();
    public List<GameObject> Ranged1 = new List<GameObject>();
    public List<GameObject> Siege = new List<GameObject>();
    public List<GameObject> Siege1 = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;

       /* if (collidedObject.CompareTag("Card"))//comprueba que lo que colisiona es una carta
        {
            //Comprueba con que zona esta  colisionando la carta
            if (gameObject.CompareTag("MeleeZone"))
            {
                Debug.Log(other);
                Melee.Add(collidedObject);
            }
            else if (gameObject.CompareTag("RangedZone"))
            {
                Ranged.Add(collidedObject);
            }
            else if (gameObject.CompareTag("SiegeZone"))
            {
                Siege.Add(collidedObject);
            }
            else if (gameObject.CompareTag("RangedZone (1)"))
            {
                Ranged1.Add(collidedObject);
            }
            else if (gameObject.CompareTag("SiegeZone (1)"))
            {
                Siege1.Add(collidedObject);
            }
            else if (gameObject.CompareTag("MeleeZone (1)"))
            {
                Melee1.Add(collidedObject);
            }
        //}
    }

    void OnTriggerExit(Collider other)
    {
        GameObject collidedObject = other.gameObject;

       // if (collidedObject.CompareTag("Card"))//comprueba que lo que colisiona es una carta
        //{
            //Comprueba con que zona esta  colisionando la carta
            if (gameObject.CompareTag("MeleeZone"))
            {
                Melee.Remove(collidedObject);
            }
            else if (gameObject.CompareTag("RangedZone"))
            {
                Ranged.Remove(collidedObject);
            }
            else if (gameObject.CompareTag("SiegeZone"))
            {
                Siege.Remove(collidedObject);
            }
            else if (gameObject.CompareTag("RangedZone (1)"))
            {
                Ranged1.Remove(collidedObject);
            }
            else if (gameObject.CompareTag("SiegeZone (1)"))
            {
                Siege1.Remove(collidedObject);
            }
            else if (gameObject.CompareTag("MeleeZone (1)"))
            {
                Melee1.Remove(collidedObject);
            }
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    */
}