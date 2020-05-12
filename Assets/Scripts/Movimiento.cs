using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public static float rotacion=0;
    Vector3 mouse;
    Vector3 mouse2;
    float rot=0;
    float angulo;
    public static bool validar;
    float auxiliar;
    float torque = 0;

    Vector3 cam;


    // Start is called before the first frame update
    void Start()
    {

        mouse = new Vector3 (0, 0, 0);//INICIALIZO EL VECTOR DE POSICION DEL CLICK
        mouse2 = new Vector3(0, 0, 0);//INICIALIZO EL VECTOR DE POSICION DONDE SE SUELTA EL CLICK
       // rot = new Vector3(0, 0, 0);

        rotacion = 0;// VELOCIDAD DE GIRO DE LA LLAVE
        angulo = 0;// ANGULO HASTA DONDE SE QUIERE GIRAR LA LLAVE
        rot = 0;// ANGULO EN EL QUE VA GIRANDO LA LLAVE

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        mouse = Prueba_Raycast.mouse;//LEE EL VECTOR DEL CLICK QUE MANDA EL RAYCAST DE LA CAMARA
        mouse2 = Prueba_Raycast.mouse2;//LEE EL VECTOR CUANDO SE SUELTA CLICK QUE MANDA EL RAYCAST DE LA CAMARA
        torque = (mouse.z / 100) * mouse2.y * -10;// SE HAYA EL TORQUE MULTIPLICANDO LA POSICION EN Z ( EN M) DONDE SE DA CLICK Y SE MULTIPLICA POR 10VECES LA DISTANCIA DE DONDE SE SUELTA EL CLICK, PARA REPRESENTAR LA MAGNITUD DE LA FUERZA
        angulo = Mathf.Atan(torque / Mathf.Abs(mouse2.z));// SE OBTIENE EN ÁNGULO EN RADIANES ENTRE DONDE SE DA EL CLICK Y DONDE SE SUELTA
        angulo = angulo * 57.2957f;// SE PASA EL ANGULO A GRADOS
        rotacion = -1.5f;// LA VELOCIDAD DE ROTACION SE OBTIENE BASADOS EN 45°/s

        auxiliar = transform.eulerAngles.x;//SE OBTIENE LA ROTACION EN X QUE LLEVA LA LLAVE

        if (Prueba_Raycast.validar)// SE PRUEBA SI YA FUE DADO EL CLICK
        {
            rot = 360 - auxiliar;// SE RESTA EL VALOR DEL ANGULO A 360, PARA OBTENER EL ANGULO COMO SI SE TOMARA DE DERECHA A IZQUIERDA
            if (Mathf.Abs(rot) <= Mathf.Abs(angulo) || rot==360)// SE COMPRUEBA SI EL ANGULO ACTUAL DE ROTACION AÚN NO A ALCANZADO EL ANGULO OBJETIVO
            {
                transform.Rotate(rotacion, 0, 0, Space.Self);//SE ROTA LA LLAVE
            }
            else
            {

                Prueba_Raycast.validar = false;// SI YA SE ALCANZO EL ANGULO OBJETIVO, LA VALIDACION LA HACE FALSA
            }

           

        }



    }
}
