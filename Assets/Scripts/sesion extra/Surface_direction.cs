using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface_direction : MonoBehaviour
{
    
    
    [SerializeField]    
    GameObject player;
    public bool stay;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player!=null)
        {
            
            player.transform.up = transform.up;
            
            Physics.gravity = -transform.up * 9.81f*player.GetComponent<sesion3>().escala_gravedad;
            //Debug.Log(Physics.gravity);

        }
        
       
        
        
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            
            player = collision.gameObject;
            player.GetComponent<Rigidbody>().velocity = new Vector3();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            
            player = null;
            
        }
    }

    
}
