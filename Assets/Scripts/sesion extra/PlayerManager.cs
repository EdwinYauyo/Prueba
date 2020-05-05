using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject player1, player2;
    bool skin=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            skin = !skin;
            if(skin==false)player2.transform.position = player1.transform.position;
            else player1.transform.position = player2.transform.position;
            player1.SetActive(skin);
            player2.SetActive(!skin);
        }
    }
}
