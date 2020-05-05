using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    float time;
    public int _time,limit_time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            timer(limit_time);
        }
        _time = (int)time;
    }

    

    void timer(int limit_time)
    {

        if(time<=limit_time)time += Time.deltaTime;
        
    }

    
}
