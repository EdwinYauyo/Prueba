using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posicion_relativa : MonoBehaviour
{
    public GameObject player;
    public bool stay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stay)
        {
            player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            stay = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            stay = false;
        }
    }
}
