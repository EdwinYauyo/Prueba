using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto_Johor : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rbd;
    public float fuerza, fuerzaM, tufrenoXD; //aún falta ajustar los valores, pero lacosa se mmueve
    // usar de preferencia fuerza =10, fuerzaM = 0.15 y tufrenoXD = 5.5 o 5
    //public float vel;
    private Vector3 velo; // para acotar la velocidad
    //private Vector3 velo2;
    private int saltos = 0; //para el doble salto
    //bool click;

    Transform tran;

    void Start()
    {
        rbd = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //velo2 = new Vector3(rbd.velocity.x, 0, rbd.velocity.y);
        velo = new Vector3(rbd.velocity.x, 0, rbd.velocity.y);
        velo = Vector3.ClampMagnitude(velo, 1); // aquí lo acoto

        //velo2 = Vector3.ClampMagnitude(velo2, 1);


        tran = gameObject.GetComponent<Transform>();
        //click = Input.GetKeyDown(KeyCode.Space) 
        //if (Input.GetKeyDown(KeyCode.Space) && rbd.velocity.magnitude <= 0)


        if (Input.GetKeyDown(KeyCode.Space)) //para el doble salto
        {

            saltos += 1;
            if (saltos <= 2)
            {
                rbd.AddForce(new Vector3(0, 1, 0) * fuerza / Time.fixedDeltaTime);
            }
        }



        if (Input.GetKey(KeyCode.UpArrow))
        {
            //rbd.velocity = new Vector3(1, 0, 0) * -vel;
            tran.localRotation = Quaternion.Euler(0, 0, 0); // para que mire al frente ya que mi objeto en pepinillo Rick XD
            rbd.AddForce(new Vector3(-1, 0, 0) * fuerzaM / Time.fixedDeltaTime);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            rbd.AddForce(new Vector3(1, 0, 0) * tufrenoXD * Mathf.Abs(rbd.velocity.x) * fuerzaM / Time.fixedDeltaTime); // para que frene
            //el frenoXD depende si mi personaje estará con botas para escalar o patines XD
            //velo = new Vector3(rbd.velocity.x, 0, rbd.velocity.y);
            //velo = Vector3.ClampMagnitude(velo, 0.1f);
            //velo = Vector3.ClampMagnitude(velo, -0.1f);
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            //rbd.velocity = new Vector3(1, 0, 0) * vel;
            tran.localRotation = Quaternion.Euler(0, 180, 0); //para que mire donde va
            rbd.AddForce(new Vector3(1, 0, 0) * fuerzaM / Time.fixedDeltaTime);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            rbd.AddForce(new Vector3(-1, 0, 0) * tufrenoXD * Mathf.Abs(rbd.velocity.x) * fuerzaM / Time.fixedDeltaTime);
            //velo = new Vector3(rbd.velocity.x, 0, rbd.velocity.y);
            //velo = Vector3.ClampMagnitude(velo, 0.1f);
            //velo = Vector3.ClampMagnitude(velo, -0.1f);
        }




        if (Input.GetKey(KeyCode.RightArrow))
        {
            //rbd.velocity = new Vector3(0, 0, 1) * vel;
            tran.rotation = Quaternion.Euler(0, 90, 0);
            //tran.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
            rbd.AddForce(new Vector3(0, 0, 1) * fuerzaM / Time.fixedDeltaTime);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rbd.AddForce(new Vector3(0, 0, -1) * tufrenoXD * Mathf.Abs(rbd.velocity.z) * fuerzaM / Time.fixedDeltaTime);
            //velo = new Vector3(rbd.velocity.x, 0, rbd.velocity.y);
            //velo = Vector3.ClampMagnitude(velo, 0.1f);
            //velo = Vector3.ClampMagnitude(velo, -0.1f);
        }







        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rbd.velocity = new Vector3(0, 0, 1) * -vel;
            tran.rotation = Quaternion.Euler(0, -90, 0); //para mirar a donde voltea 
                                                         //tran.Rotate(new Vector3(0, -90, 0) * Time.deltaTime);
            rbd.AddForce(new Vector3(0, 0, -1) * fuerzaM / Time.fixedDeltaTime);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rbd.AddForce(new Vector3(0, 0, 1) * tufrenoXD * Mathf.Abs(rbd.velocity.z) * fuerzaM / Time.fixedDeltaTime);
            //velo = new Vector3(rbd.velocity.x, 0, rbd.velocity.y);
            //velo = Vector3.ClampMagnitude(velo, 0.1f);
            //velo = Vector3.ClampMagnitude(velo, -0.1f);
        }


    }

    private void OnCollisionEnter(Collision collision) //para el doble salto
    {
        saltos = 0;
    }

    private void OnTriggerEnter(Collider other) //para que haga un respwan
    {
        if (other.tag == "Respawn")
        {
            tran.position = new Vector3(0, 0, 0);
            tran.localRotation = Quaternion.Euler(0, 0, 0);
            rbd.velocity = new Vector3(0, 0, 0);
        }
    }
}
