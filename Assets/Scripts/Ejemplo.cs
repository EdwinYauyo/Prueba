using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo : MonoBehaviour
{
    public bool movR;
    Rigidbody rbd;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movR = true;
            Debug.Log("debo funcionar una vez");
        }
        else movR = false;

        
    }

    private void FixedUpdate()
    {

    }
}
