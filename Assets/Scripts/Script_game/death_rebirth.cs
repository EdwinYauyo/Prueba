using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death_rebirth : MonoBehaviour
{
    public bool checkpoint_active=false;
    public GameObject checkpoint;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player")&&checkpoint_active==false)
        {
            //player.transform.position = new Vector3();
            SceneManager.LoadScene("SampleScene");
            
        }
        if(other.CompareTag("player") && checkpoint_active == true)
        {
            other.transform.position = checkpoint.transform.position;
        }

        
    }
}
