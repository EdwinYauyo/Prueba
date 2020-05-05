using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salto_gianfranco : MonoBehaviour
{
    Rigidbody rbd;
    public float fuerza, fuerza_p, vel_limite;


    // Start is called before the first frame update
    void Start()
    {
        rbd = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && rbd.velocity.y == 0)
        {
            rbd.AddForce(new Vector3(0, 1, 0) * fuerza, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (rbd.velocity.x < vel_limite)
            {
                rbd.AddForce(new Vector3(1, 0, 0) * fuerza_p / Time.fixedDeltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (rbd.velocity.x > -vel_limite)
            {
                rbd.AddForce(new Vector3(1, 0, 0) * -fuerza_p / Time.fixedDeltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (rbd.velocity.z < vel_limite)
            {
                rbd.AddForce(new Vector3(0, 0, 1) * fuerza_p / Time.fixedDeltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (rbd.velocity.z > -vel_limite)
            {
                rbd.AddForce(new Vector3(0, 0, 1) * -fuerza_p / Time.fixedDeltaTime);
            }
        }

        if (rbd.velocity.x != 0 || rbd.velocity.z != 0)
        {
            //float a = rbd.velocity.x * rbd.velocity.x + rbd.velocity.z * rbd.velocity.z;
            //Debug.Log(a);
            rbd.AddForce(-rbd.velocity);
        }

    }

    private void FixedUpdate()
    {

    }
}
