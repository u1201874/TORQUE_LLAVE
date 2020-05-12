using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Prueba_Raycast : MonoBehaviour
{
    public static Vector3 mouse;
    public static Vector3 mouse2;
    public static bool validar;
    public UnityEngine.UI.Image barraRoja;
    bool barra=false;


    // Start is called before the first frame update
    void Start()
    {
        barraRoja.fillAmount = 0;// VALOR DE APARICIÓN DE LA BARRA ROJA, NO HA EMPEZADO A APARECER

    }

    // Update is called once per frame
    void Update()
    {


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);// SE DEFINE QUE EL RAYO SE MANDE A LA POSICIÓN DEL MOUSE
            RaycastHit hit;


            if (Input.GetMouseButtonDown(0))// EVALUA SI SE DIO CLICK
            {

                if (Physics.Raycast(ray, out hit))//SE EVALUA SI HUBO COLISION CON LA LLAVE
                {
                    mouse = ray.origin;// LAS COORDENADAS DE ORIGEN SE ASOCIAN A DONDE SE DIO EL CLICK YA QUE LA CÁMARA ESTÁ ORTOGONAL, EL VALOR DE ORIGEN Y DIRECCION ES EL MISMO

                }

                barra = true;// SI ES DIO CLICK SE EMPIEZA A LLENAR LA BARRA

            }
            if (barra)// SE EVALUA SI YA SE DIO CLICK PARA QUE LA BARRA SOLO SE EMPIECE A LLENAR SI HUBO CLICK, YA SE LLEVA SIMULTANEAMENTE
            {
                barraRoja.fillAmount = ray.origin.y / -35;//SE VA LLENANDO LA BARRA DEPENDIENDO DE QUE TAN ABAJO SE SUELTE EL CLICK
            }


            if (Input.GetMouseButtonUp(0))// SE COMPRUEBA SI SE SOLTÓ EL CLICK
            {
                mouse2 = ray.origin;// SE LE ASIGNA A OTRO VECTOR LA POSICION DE DONDE SE SUELTA EL CLICK
                validar = true;// MANDA LA SEÑAL QUE YA SE PUEDE EMPEZAR LA SIMULACION PORQUE SE TIENEN AMBOS PUNTOS
                barra = false;// MANDA LA SEÑAL PARA QUE NO SE SIGA GRAFICANDO LA BARRA

            }

    }


}
