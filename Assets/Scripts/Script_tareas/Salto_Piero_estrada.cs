using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto_Piero_estrada : MonoBehaviour
{

    Rigidbody rbd;
    public float vel;
    float a, b;
    bool m, n, p, q;
    void Start()
    {
        rbd = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m = Input.GetKey(KeyCode.UpArrow);
        n = Input.GetKey(KeyCode.DownArrow);
        p = Input.GetKey(KeyCode.RightArrow);
        q = Input.GetKey(KeyCode.LeftArrow);
    }

    void FixedUpdate()
    {
        if (m || n || p || q)
        {
            if (m) a = vel;
            else if (n) a = -vel;
            if (p) b = vel;
            else if (q) b = -vel;
            rbd.velocity = new Vector3(b, 0, a);

            a = 0; b = 0;
        }

        if ((!m && rbd.velocity.z > 0))
        {
            float z = vel / 18;
            rbd.velocity -= new Vector3(0, 0, z);
        }

        if (!n && rbd.velocity.z < 0)
        {
            float z = -vel / 18;
            rbd.velocity -= new Vector3(0, 0, z);
        }

        if (!p && rbd.velocity.x > 0)
        {
            float x = vel / 18;
            rbd.velocity -= new Vector3(x, 0, 0);
        }

        if (!q && rbd.velocity.x < 0)
        {
            float x = -vel / 18;
            rbd.velocity -= new Vector3(x, 0, 0);
        }
    }
}
