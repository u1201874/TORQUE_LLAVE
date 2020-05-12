using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotación_Cuerpo : MonoBehaviour
{

    float rotacion2=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Prueba_Raycast.validar)// RECONOCE SI EL CLICK YA ESTÁ SUELTO PARA EMPEZAR A ROTAR
        {
            rotacion2 = Movimiento.rotacion; //RECIBE EL VALOR DE VELOCIDAD DE ROTACION DE LA LLAVA PARA GIRAR AL MISMO RITMO
            transform.Rotate(rotacion2, 0, 0, Space.Self);// ROTA EN X LA TUERCA


        }

    }
}
