using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemie : MonoBehaviour
{
    public float velocidad;
    public GameObject enemie;
    public GameObject pos;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("instance",0,2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void instance()
    {
        GameObject temp_enemie = Instantiate(enemie,pos.transform.position,Quaternion.identity);
        temp_enemie.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1) * velocidad;
        Destroy(temp_enemie, 5);
        Debug.Log("toy funcionando");
    }
}
