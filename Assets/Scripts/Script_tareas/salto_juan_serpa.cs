using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salto_juan_serpa : MonoBehaviour
{

    Rigidbody rbd;
    public float fuerza;
    public float vel;

    // Start is called before the first frame update
    void Start()
    {
        rbd = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            rbd.AddForce(new Vector3(0, fuerza, 0) / Time.fixedDeltaTime);

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rbd.velocity = new Vector3(0, 0, 1) * vel;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            rbd.velocity = Vector3.zero;
            /////////////////
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rbd.velocity = new Vector3(0, 0, -1) * vel;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            rbd.velocity = Vector3.zero;
        }
        ///////////
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rbd.velocity = new Vector3(1, 0, 0) * vel;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rbd.velocity = Vector3.zero;
        }
        ////////////////////
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rbd.velocity = new Vector3(1, 0, 0) * -vel;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rbd.velocity = Vector3.zero;
        }
        //movimientos diagonales
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            rbd.velocity = new Vector3(1, 0, 1) * vel;
        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            rbd.velocity = new Vector3(-1, 0, 1) * vel;
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            rbd.velocity = new Vector3(1, 0, -1) * vel;
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            rbd.velocity = new Vector3(1, 0, 1) * -vel;
        }

    }
}
