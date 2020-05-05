using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto_felix : MonoBehaviour
{
    Rigidbody rgb;
    Transform trm;
    public GameObject plano;
    public int fuerza;
    int contador = 0;
    public int velocidad;
    float posicion_inicial;
    void Start()
    {
        rgb = gameObject.GetComponent<Rigidbody>();
        trm = gameObject.GetComponent<Transform>();
        posicion_inicial = plano.transform.position.y + 1;
    }
    void Update()
    {
        //Reinicia los saltos
        if (trm.position.y <= posicion_inicial)
        {
            contador = 0;
        }
        //Para el salto doble
        if (contador < 2)
        {
            if (Input.GetKeyDown("space"))
            {
                rgb.AddForce(new Vector3(0, 1, 0) * fuerza / Time.fixedDeltaTime);
                contador++;
            }
        }
        if (Input.GetKey("up"))
        {
            rgb.AddForce(new Vector3(0, 0, 1) * velocidad);
        }
        if (Input.GetKeyUp("up"))
        {
            if (trm.position.y <= posicion_inicial)
            {
                rgb.velocity = new Vector3(0, 0, 0);
            }
        }
        if (Input.GetKey("down"))
        {
            rgb.AddForce(new Vector3(0, 0, 1) * -velocidad);
        }
        if (Input.GetKeyUp("down"))
        {
            if (trm.position.y <= posicion_inicial)
            {
                rgb.velocity = new Vector3(0, 0, 0);
            }
        }
        if (Input.GetKey("right"))
        {
            rgb.AddForce(new Vector3(1, 0, 0) * velocidad);
        }
        if (Input.GetKeyUp("right"))
        {
            if (trm.position.y <= posicion_inicial)
            {
                rgb.velocity = new Vector3(0, 0, 0);
            }
        }
        if (Input.GetKey("left"))
        {
            rgb.AddForce(new Vector3(1, 0, 0) * -velocidad);
        }
        if (Input.GetKeyUp("left"))
        {
            if (trm.position.y <= posicion_inicial)
            {
                rgb.velocity = new Vector3(0, 0, 0);
            }
        }
    }

    private void FixedUpdate()
    {
        //Después de un salto
        if (Input.GetKey("left") == false && Input.GetKey("right") == false && Input.GetKey("down") == false && Input.GetKey("up") == false)
        {
            if (trm.position.y <= posicion_inicial)
            {
                rgb.velocity = new Vector3(0, 0, 0);
            }
        }

    }
}
