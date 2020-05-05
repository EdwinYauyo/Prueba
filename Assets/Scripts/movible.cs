using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movible : MonoBehaviour
{

    public GameObject player,inf,sup;
    public float velocidad;
    public bool stay;
    public int i=1;
    // Start is called before the first frame update
    void Start()
    {
       
    }



    // Update is called once per frame
    void Update()
    {

        



    }
    private void FixedUpdate()
    {
        
        if (i == -1) transform.position=(Vector3.MoveTowards(transform.position, inf.transform.position, velocidad * Time.fixedDeltaTime));


        if (i == 1) transform.position = (Vector3.MoveTowards(transform.position, sup.transform.position, velocidad * Time.fixedDeltaTime));


        if (transform.position == sup.transform.position)
        {
            i = -1;
        }
        else if(transform.position == inf.transform.position) i = 1;

        

        
        
    }


    

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            collision.transform.parent = transform;
            stay = true;
        }   
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            collision.transform.parent = null;
            stay = false;
        }
    }

    

}
