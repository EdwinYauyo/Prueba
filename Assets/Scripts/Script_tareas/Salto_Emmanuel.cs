using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto_Emmanuel : MonoBehaviour
{
    public float fuerza;
    public float vel;
    public float ns = 1;
    Rigidbody rbd;

    // Start is called before the first frame update
    void Start()
    {
        rbd = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ns; i++)
        {
            if (Input.GetKeyDown(KeyCode.Space) && rbd.velocity.y <= 2)
            {
                rbd.AddForce(new Vector3(0, 1, 0) * fuerza / Time.fixedDeltaTime);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rbd.velocity = new Vector3(0, 0, 1) * vel;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            rbd.velocity = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rbd.velocity = new Vector3(0, 0, 1) * -vel;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            rbd.velocity = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rbd.velocity = new Vector3(1, 0, 0) * vel;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rbd.velocity = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rbd.velocity = new Vector3(1, 0, 0) * -vel;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rbd.velocity = new Vector3(0, 0, 0);
        }
    }
}
