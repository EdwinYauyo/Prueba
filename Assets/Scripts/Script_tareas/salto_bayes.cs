using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salto_bayes : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject obejto;
    Rigidbody rbd;
    Transform tran;
    int salto;

    public float fuerza;
    void Start()
    {
        tran = gameObject.GetComponent<Transform>();
        rbd = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (tran.position.y < -1)
        {
            tran.position = new Vector3(0, 0, 0);
            rbd.velocity = new Vector3(0, 0, 0);
            salto = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rbd.AddForce(new Vector3(-1, 0, 0) * fuerza / Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rbd.AddForce(new Vector3(1, 0, 0) * fuerza / Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rbd.AddForce(new Vector3(0, 0, -1) * fuerza / Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rbd.AddForce(new Vector3(0, 0, 1) * fuerza / Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            rbd.AddForce(new Vector3(-1, 0, 1) * fuerza / Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            rbd.AddForce(new Vector3(-1, 0, -1) * fuerza / Time.fixedDeltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && salto < 2)
        {
            rbd.AddForce(new Vector3(0, 1, 0) * fuerza / Time.fixedDeltaTime);
            salto++;
        }
        if (salto >= 2 && tran.position.y <= 1)
        {
            salto = 0;
        }
        Debug.Log(salto);


    }

    void FixedUpdate()
    {

    }


}
