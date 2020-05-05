using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_sphere : MonoBehaviour
{
    public Transform camera_sphere,canon;
    public float vmax, mov,camera_distance,vel_rot;
    Vector3 distance;
    bool movUP, movD, movR, movL;
    Rigidbody rbd;
    Transform tran;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        tran = GetComponent<Transform>();
        distance = camera_sphere.transform.position-transform.position;
    }

    
    void Update()
    {
        
        camera_sphere.transform.position = transform.position+distance.normalized*camera_distance;
        canon.position = transform.position + new Vector3(0, 0, 0.6f);
        

        movUP = Input.GetKey(KeyCode.UpArrow);
        movD = Input.GetKey(KeyCode.DownArrow);
        movR = Input.GetKey(KeyCode.RightArrow);
        movL = Input.GetKey(KeyCode.LeftArrow);



        if (Input.GetKey(KeyCode.D))
        {
            canon.RotateAround(canon.transform.position, new Vector3(0,0.6f,0), vel_rot * Time.deltaTime);
        }
   

        if (Input.GetKey(KeyCode.A))
        {
            
        }
       
    }

    private void FixedUpdate()
    {
        if (movUP)
        {
            if (rbd.velocity.z < vmax) rbd.AddForce(new Vector3(0, 0, 1) * mov);
        }

        if (movD)
        {
            if (rbd.velocity.z > -vmax) rbd.AddForce(new Vector3(0, 0, 1) * -mov);
        }

        if (movR)
        {
            if (rbd.velocity.x < vmax) rbd.AddForce(new Vector3(1, 0, 0) * mov);
        }

        if (movL)
        {
            if (rbd.velocity.x > -vmax) rbd.AddForce(new Vector3(1, 0, 0) * -mov);
        }

    }
}
