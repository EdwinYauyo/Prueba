using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto_Paul_Hans : MonoBehaviour
{
    Rigidbody rbd;
    public int saltos;
    public int salto = 0;
    public float normal, velocidad;
    bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //salto
        if (Input.GetKeyDown(KeyCode.Space) && (flag || saltos > salto))
        {
            rbd.AddForce(new Vector3(0, 1, 0) * normal / Time.fixedDeltaTime);
            flag = false;
            salto++;
        }
        //adelante
        if (Input.GetKeyDown(KeyCode.W))
        {
            rbd.AddForce(new Vector3(0, 0, 1) * velocidad / Time.fixedDeltaTime);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            rbd.AddForce(new Vector3(0, 0, -1) * velocidad / Time.fixedDeltaTime);
        }
        //atras
        if (Input.GetKeyDown(KeyCode.S))
        {
            rbd.AddForce(new Vector3(0, 0, -1) * velocidad / Time.fixedDeltaTime);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            rbd.AddForce(new Vector3(0, 0, 1) * velocidad / Time.fixedDeltaTime);
        }
        //derecha
        if (Input.GetKeyDown(KeyCode.D))
        {
            rbd.AddForce(new Vector3(1, 0, 0) * velocidad / Time.fixedDeltaTime);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rbd.AddForce(new Vector3(-1, 0, 0) * velocidad / Time.fixedDeltaTime);
        }
        //izquierda
        if (Input.GetKeyDown(KeyCode.A))
        {
            rbd.AddForce(new Vector3(-1, 0, 0) * velocidad / Time.fixedDeltaTime);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            rbd.AddForce(new Vector3(1, 0, 0) * velocidad / Time.fixedDeltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        flag = true;
        salto = 0;
    }
}
