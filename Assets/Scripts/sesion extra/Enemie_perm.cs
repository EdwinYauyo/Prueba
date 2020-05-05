using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie_perm : MonoBehaviour
{
    public GameObject player,bullet,canon;
    public float velocity_bullet;
    public float limite;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Inst_bullet",2,0.2f); 
    }

    // Update is called once per frame
    void Update()
    {

        direction = (player.transform.position - transform.position);
        if (direction.magnitude <= limite)
        {
            transform.forward = direction.normalized;
        }
        
        
    }

    void Inst_bullet()
    {
        if (direction.magnitude <= limite)
        {
            GameObject temp_bullet = Instantiate(bullet, canon.transform.position, Quaternion.identity);


            temp_bullet.transform.up = direction.normalized;
            temp_bullet.GetComponent<Rigidbody>().velocity = direction.normalized * velocity_bullet;
        }
        
    }
}
