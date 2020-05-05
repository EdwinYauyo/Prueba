using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_fall : MonoBehaviour
{
    bool player_ground;
    Rigidbody rbd;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
        rbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("player_ground",player_ground);
    }

    IEnumerator retraso()
    {
        yield return new WaitForSeconds(2);
        rbd.isKinematic = false;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            player_ground = true;
            StartCoroutine(retraso());
            
        }
    }
}
