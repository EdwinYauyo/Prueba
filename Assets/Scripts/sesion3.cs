using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sesion3 : MonoBehaviour
{

    public bool on_surface;
    Vector3 gravity = new Vector3(0, -9.81f, 0);
    public float velocidad, fuerzaJ, escala_gravedad;
    public int points,saltos,i;
    
    float x, z;
    Rigidbody rbd;





    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        Physics.gravity = gravity * escala_gravedad;
       
        

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            
            if (on_surface==true)
            {
                i = 0;
            }
            i++;
            if (i <= saltos)
            {
                rbd.AddForce(transform.up * fuerzaJ, ForceMode.Impulse);
                
            }

        }



        
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        //rbd.velocity = new Vector3(x * velocidad, rbd.velocity.y, z * velocidad);
        transform.position += x *velocidad* transform.right * Time.deltaTime;
        transform.position += z *velocidad* transform.forward * Time.deltaTime;


        //    Debug.Log(rbd.velocity.y);

    }

    
    

   
        
    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("surface"))
        {
            on_surface = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("surface"))
        {
            on_surface = false;
        }
    }
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("point"))
        {
            points++;

        }
       
    }

   





}
