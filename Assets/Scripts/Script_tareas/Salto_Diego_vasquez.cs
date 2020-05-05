using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto_Diego_vasquez : MonoBehaviour
{
    Rigidbody rbd;
    public float Force, ForceMove, VelMax;
    bool mover, salto;
    bool desacelerar, redondeo;
    Vector3 dz;
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) salto = true;
        else salto = false;

        Debug.Log(rbd.velocity);

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {

            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                mover = false;
                desefect();
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                desacelerar = false;
                redondeo = false;
                dz = new Vector3(0, 0, 1);
                if (rbd.velocity.z < VelMax) mover = true;
                else mover = false;
            }
            else
            {
                desacelerar = false;
                redondeo = false;
                dz = new Vector3(0, 0, -1);
                if (rbd.velocity.z > -VelMax) mover = true;
                else mover = false;
            }
        }
        else
        {
            mover = false;
            desefect();
        }
    }

    void FixedUpdate()
    {
        //Salto 
        if (salto) rbd.AddForce(new Vector3(0, 1, 0) * Force * 40);

        if (mover) rbd.AddForce(dz * ForceMove);
        if (desacelerar) rbd.AddForce(dz * -ForceMove);
        if (redondeo) rbd.velocity = new Vector3(rbd.velocity.x, rbd.velocity.y);
    }

    void desefect()
    {
        if (0.2 < rbd.velocity.z)
        {
            dz = new Vector3(0, 0, 1);
            desacelerar = true;
        }
        else if (-0.2 > rbd.velocity.z)
        {
            dz = new Vector3(0, 0, -1);
            desacelerar = true;
        }
        else desacelerar = false;

        if (-0.2 <= rbd.velocity.z && rbd.velocity.z <= 0.2)
        {
            redondeo = true;
            dz = new Vector3();
        }
        else redondeo = false;
    }
}
