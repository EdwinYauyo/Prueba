using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ejemploColTriger : MonoBehaviour
{
    public int vida=5;
    bool stay_life;
    public int points;
    Rigidbody rbd;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (stay_life)
        {
            vida++;
        }

    }

    private void FixedUpdate()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        
    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("life"))
        {
            stay_life = true;
        }
        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("life"))
        {
            stay_life = false;
        }
    }



}
