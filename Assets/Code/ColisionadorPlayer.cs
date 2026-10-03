using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionadorPlayer : MonoBehaviour
{
    public static bool enPiso = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enPiso = true;
        Debug.Log("Colision con Suelo");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enPiso = false;
        Debug.Log("Salida del Suelo");
    }
}
