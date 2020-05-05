using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salto_mariano : MonoBehaviour
{
    Rigidbody rbd;
    public float salto;
    public float mov;
    float a;
    float b;
    float velmax = 5;

    void Start()
    {
        rbd = gameObject.GetComponent<Rigidbody>();
        a = rbd.velocity.x;
        b = rbd.velocity.z;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && rbd.velocity.y == 0)
        {
            rbd.AddForce(new Vector3(0, 1, 0)*salto / Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (a <= velmax)
            {
                rbd.AddForce(new Vector3(-1, 0, 0)*mov / Time.fixedDeltaTime);
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            //a = 0;
            rbd.velocity = new Vector3(0, rbd.velocity.y, rbd.velocity.z);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (a <= velmax)
            {
                rbd.AddForce(new Vector3(1, 0, 0)*mov / Time.fixedDeltaTime);
            }
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            //a = 0;
            rbd.velocity = new Vector3(0, rbd.velocity.y, rbd.velocity.z);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (b <= velmax)
            {
                rbd.AddForce(new Vector3(0, 0, 1)*mov / Time.fixedDeltaTime);
            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //b = 0;
            rbd.velocity = new Vector3(rbd.velocity.x, rbd.velocity.y, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (b <= velmax)
            {
                rbd.AddForce(new Vector3(0, 0, -1) * mov / Time.fixedDeltaTime);
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //b = 0;
            rbd.velocity = new Vector3(rbd.velocity.x, rbd.velocity.y, 0);
        }
    }
}
