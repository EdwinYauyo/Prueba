using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repollo : MonoBehaviour
{
    Rigidbody rbd;
    public float fuerza,velmax;
    public float vel,tiempo_desal;
    float vel_inst;
    public bool up,desUP;
    private void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            up = true;
            desUP = false;
        }
        else
        {
            up = false;
            
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            vel_inst = rbd.velocity.y;
            desUP = true;
        }
        
        //up = Input.GetKey(KeyCode.Space);
        Debug.Log(vel_inst);
    }

    private void FixedUpdate()
    {
        vel = rbd.velocity.y;
        
        if (up)
        {
            if(rbd.velocity.y<velmax)rbd.AddForce(new Vector3(0, 1, 0) * fuerza);
            
        }
        rbd.velocity = Vector3.ClampMagnitude(rbd.velocity, velmax);

        if (desUP)
        {
            if (rbd.velocity.y > 0.001) rbd.AddForce(new Vector3(0, -vel_inst / tiempo_desal, 0));
            else
            {
                
                rbd.velocity = new Vector3(rbd.velocity.x,0,rbd.velocity.z);
                desUP = false;
            }
        }
        
        
    }
}
