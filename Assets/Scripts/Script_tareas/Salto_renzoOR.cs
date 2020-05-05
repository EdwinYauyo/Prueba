using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto_renzoOR : MonoBehaviour
{
    Rigidbody rbd;

    Vector3 Vel_Min = new Vector3(0, 0, 0);
    Vector3 Vel_actual = new Vector3(0, 0, 0);

    /* Separé los vectores por ejes*/

    /*                        Eje X                                */
    Vector3 Impulso_X = new Vector3(0.8f, 0, 0);
    Vector3 Vel_Max_X = new Vector3(8.0f, 0, 0);
    /*                        Eje Z                                */
    Vector3 Impulso_Z = new Vector3(0, 0, 0.8f);
    Vector3 Vel_Max_Z = new Vector3(0, 0, 8.0f);


    void Start()
    {

        rbd = gameObject.GetComponent<Rigidbody>();

    }

    void Update()
    {
        /* Desplazamiento en X */

        /*Cuando pulso la tecla designada empieza a aclerar hasta una velocidad máxima*/
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vel_actual += Impulso_X;
            /*Se comprueba (comparando magnitudes) que la velocidad actual de nuestro personaje no supere la velocidad máxima y si la supera hacemos que la velocidad actual se iguale a la velocidad máxima*/
            if (Vel_actual.magnitude > Vel_Max_X.magnitude)
            {
                Vel_actual = Vel_Max_X;
            }
            /*Se actualiza la velocidad*/
            rbd.velocity = Vel_actual;
        }
        /*En cuanto la tecla regresa a la posición normal empieza a desacelerar hasta llegar a la velocidad mínima */
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Vel_actual -= Impulso_X;
            /*Si la velocidad actual es menor a la mínima la igualamos a la mínima para que el cuerpo no se mueva más*/
            if (Vel_actual.magnitude < Vel_Min.magnitude)
            {
                Vel_actual = Vel_Min;
            }
            rbd.velocity = Vel_actual;

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vel_actual -= Impulso_X;
            if ((-1 * Vel_actual.magnitude) < (-1 * Vel_Max_X.magnitude))
            {
                Vel_actual = -1 * Vel_Max_X;
            }
            rbd.velocity = Vel_actual;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Vel_actual += Impulso_X;

            if ((-1 * Vel_actual.magnitude) > Vel_Min.magnitude)
            {
                Vel_actual = Vel_Min;
            }
            rbd.velocity = Vel_actual;
        }

        /*  ============================================================================================ */

        /*Desplazamiento en Z*/

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vel_actual += Impulso_Z;
            if (Vel_actual.magnitude > Vel_Max_Z.magnitude)
            {
                Vel_actual = Vel_Max_Z;
            }
            rbd.velocity = Vel_actual;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Vel_actual -= Impulso_Z;

            if (Vel_actual.magnitude < Vel_Min.magnitude)
            {
                Vel_actual = Vel_Min;
            }
            rbd.velocity = Vel_actual;

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vel_actual -= Impulso_Z;
            if ((-1 * Vel_actual.magnitude) < (-1 * Vel_Max_Z.magnitude))
            {
                Vel_actual = -1 * Vel_Max_Z;
            }
            rbd.velocity = Vel_actual;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Vel_actual += Impulso_Z;

            if ((-1 * Vel_actual.magnitude) > Vel_Min.magnitude)
            {
                Vel_actual = Vel_Min;
            }
            rbd.velocity = Vel_actual;
        }

    }
}
