using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov_fis : MonoBehaviour
{
    public float velocidad;
    int i=1;
    public bool stay;
    Rigidbody rbd_plat;
    // Start is called before the first frame update
    void Start()
    {
        rbd_plat = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rbd_plat.velocity = new Vector3(0, 0, i) * velocidad;

        
       
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("inf"))
        {
            i = 1;
        }

        if (other.CompareTag("sup"))
        {
            i = -1;
        }
    }
}
