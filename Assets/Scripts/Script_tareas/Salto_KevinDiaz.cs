using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto_KevinDiaz : MonoBehaviour
{
    public float jumpForce = 5;
    public float force = 5;
    public float vmax = 5;

    private bool canMoving;
    private bool isMoving = false;
    private Rigidbody rbd;

    // Start is called before the first frame update
    void Start()
    {
        rbd = this.GetComponent<Rigidbody>();
        canMoving = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("space") && rbd.velocity.y == 0)
        {
            canMoving = false;
            rbd.AddForce(new Vector3(0, 1, 0) * jumpForce);
        }
        else { if (rbd.velocity.y == 0) canMoving = true; }



        if (Input.GetKey(KeyCode.RightArrow) && (!Input.GetKey(KeyCode.LeftArrow)) && (!Input.GetKey(KeyCode.UpArrow)) && (!Input.GetKey(KeyCode.DownArrow)) && canMoving)
        {
            if (rbd.velocity.x <= vmax && (!isMoving))
            {
                rbd.AddForce(new Vector3(1, 0, 0) * force);
            }
        }

        if ((!Input.GetKey(KeyCode.RightArrow)) && Input.GetKey(KeyCode.LeftArrow) && (!Input.GetKey(KeyCode.UpArrow)) && (!Input.GetKey(KeyCode.DownArrow)) && canMoving)
        {
            if (rbd.velocity.x >= -vmax && (!isMoving))
            {
                rbd.AddForce(new Vector3(-1, 0, 0) * force);
            }
        }

        if ((!Input.GetKey(KeyCode.RightArrow)) && (!Input.GetKey(KeyCode.LeftArrow)) && Input.GetKey(KeyCode.UpArrow) && (!Input.GetKey(KeyCode.DownArrow)) && canMoving)
        {
            if (rbd.velocity.z <= vmax && (!isMoving))
            {
                rbd.AddForce(new Vector3(0, 0, 1) * force );
            }
        }

        if ((!Input.GetKey(KeyCode.RightArrow)) && (!Input.GetKey(KeyCode.LeftArrow)) && (!Input.GetKey(KeyCode.UpArrow)) && Input.GetKey(KeyCode.DownArrow) && canMoving)
        {
            if (rbd.velocity.z >= -vmax && (!isMoving))
            {
                rbd.AddForce(new Vector3(0, 0, -1) * force );
            }
        }

        if ((!Input.GetKey(KeyCode.RightArrow)) && (!Input.GetKey(KeyCode.LeftArrow)) && (!Input.GetKey(KeyCode.UpArrow)) && (!Input.GetKey(KeyCode.DownArrow)) && canMoving)
        {
            if (rbd.velocity.magnitude < -0.1 || rbd.velocity.magnitude > 0.1)
            {
                isMoving = true;
                if (isMoving)
                {
                    if (rbd.velocity.x > 0) { rbd.AddForce(Vector3.left * force); }
                    if (rbd.velocity.z > 0) { rbd.AddForce(Vector3.back * force ); }
                    if (rbd.velocity.x < 0) { rbd.AddForce(Vector3.right * force); }
                    if (rbd.velocity.z < 0) { rbd.AddForce(Vector3.forward * force); }
                }
            }
            else { isMoving = false; }
        }
    }
}
