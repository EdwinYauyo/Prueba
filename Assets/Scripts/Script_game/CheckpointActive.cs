using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointActive : MonoBehaviour
{
    public death_rebirth DeathZone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            DeathZone.checkpoint = gameObject;
            DeathZone.checkpoint_active = true;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            //gameObject.GetComponent<Material>().color = Color.red;
            
        }
    }
}
