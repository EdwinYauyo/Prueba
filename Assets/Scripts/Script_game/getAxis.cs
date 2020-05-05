using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getAxis : MonoBehaviour
{
    public int points;
    Vector3 gravity= new Vector3(0,-9.81f,0);
    public Vector3 new_grav;
    Animator anim;
    Rigidbody rbd;
    public bool up, down, ground;
    int i;
    public float x, z, fuerza,f_salto, scale_gravity,num_saltos;

    private void Awake()
    {
        
        
    }

    private void Start()
    {
        rbd = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        Physics.gravity = gravity * scale_gravity;

    }

    public  void Update()
    {
        new_grav = Physics.gravity;
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        
        move(x, z);
        

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (rbd.velocity.y == 0)
            {
                i = 0;
            }
            i++;
            if (i <= num_saltos)
            {
                rbd.AddForce(new Vector3(0, 1, 0) * f_salto / Time.fixedDeltaTime);
                //rbd.AddForce(new Vector3(0, 1, 0) * fuerza_salto, ForceMode.Impulse);
                Debug.Log(i);
            }

        }

        if (rbd.velocity.y > 0)
        {
            up = true;
        }
        else up = false;

        if (rbd.velocity.y < 0)
        {
            down = true;
        }
        else down=false;

        

        anim.SetBool("up",up);
        anim.SetBool("down", down);
        anim.SetBool("ground",ground);
        

    }


    private void FixedUpdate()
    {
        
        rbd.velocity = new Vector3(x*fuerza, rbd.velocity.y,rbd.velocity.z);
        rbd.velocity = new Vector3(rbd.velocity.x, rbd.velocity.y, z * fuerza);

    }


    void move(float x,float y)
    {
        anim.SetFloat("velx", x);
        anim.SetFloat("vely", y);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            ground = true;
            StartCoroutine(retraso());
        }

        

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            ground = false;
        }
    }

    IEnumerator retraso()
    {
        yield return new WaitForSeconds(0.5f);
        ground = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            points++;
            Destroy(other.gameObject);
        }


    }


}
