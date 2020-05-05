using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salto_Kevin_diaz : MonoBehaviour
{
    public float speed = 0.5f;
    public float jumpForce = 20f;
    public int jumpNumber = 1;

    // public float desTime = 1f;  // Factor de desaceleracion.
    public float aceTime = 2f;  //Factor de aceleracion.

    const float maxTime = 1f;  // Maximo porcentaje de interpolacion.
    private float currentTime;

    Rigidbody capsrgb;

    private bool move = false;

    private bool desD = false;                           // Teclas A, D, W, S.
    private bool desA = false;
    private bool desW = false;
    private bool desS = false;
    private int i = 0;

    private Vector3 startPosition;
    private Vector3 endPosition;

    Vector3 newGravity = Physics.gravity;
    [Range(1, 20)]
    [Header("Gravity")]
    public int gravityScale = 4;

    // Start is called before the first frame update
    void Start()
    {
        capsrgb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (capsrgb.velocity.y == 0) { i = 0; }
            i++;
            if (i <= jumpNumber)
            {
                capsrgb.AddForce(Vector3.up * jumpForce / Time.fixedDeltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            currentTime = 0f;
        }

        // Movimiento acelerado.
        if (Input.GetKey(KeyCode.D))
        {
            move = true;
            startPosition = this.transform.position;
            currentTime += (Time.deltaTime * aceTime);
            if (currentTime >= maxTime) { currentTime = maxTime; }
            float t = currentTime / maxTime;                                         // "porcentaje" del total del tiempo.
            endPosition = startPosition + Vector3.right * speed * SmoothFunction(t);
            this.transform.position = endPosition;
        }

        if (Input.GetKey(KeyCode.A))
        {
            move = true;
            startPosition = this.transform.position;
            currentTime += (Time.deltaTime * aceTime);
            if (currentTime >= maxTime) { currentTime = maxTime; }
            float t = currentTime / maxTime;
            endPosition = startPosition + Vector3.left * speed * SmoothFunction(t);
            this.transform.position = endPosition;
        }

        if (Input.GetKey(KeyCode.W))
        {
            move = true;
            startPosition = this.transform.position;
            currentTime += (Time.deltaTime * aceTime);
            if (currentTime >= maxTime) { currentTime = maxTime; }
            float t = currentTime / maxTime;
            endPosition = startPosition + Vector3.forward * speed * SmoothFunction(t);
            this.transform.position = endPosition;
        }

        if (Input.GetKey(KeyCode.S))
        {
            move = true;
            startPosition = this.transform.position;
            currentTime += (Time.deltaTime * aceTime);
            if (currentTime >= maxTime) { currentTime = maxTime; }
            float t = currentTime / maxTime;
            endPosition = startPosition + Vector3.back * speed * SmoothFunction(t);
            this.transform.position = endPosition;
        }


        // Movimiento desacelerado.
        if (Input.GetKeyUp(KeyCode.D))
        {
            desD = true;
            move = false;
        }
        if (desD)
        {
            startPosition = this.transform.position;
            currentTime -= (Time.deltaTime * aceTime);
            if (currentTime <= 0f) { currentTime = 0f; desD = false; }
            float t = currentTime / maxTime;
            endPosition = startPosition + Vector3.right * speed * SmoothFunction(t);
            this.transform.position = endPosition;
            if (move) { desD = false; currentTime = 0.4f; }         // currentTime = 0.4f para hacerlo mas "suave" el movimiento.
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            desA = true;
            move = false;
        }
        if (desA)
        {
            startPosition = this.transform.position;
            currentTime -= (Time.deltaTime * aceTime);
            if (currentTime <= 0f) { currentTime = 0f; desA = false; }
            float t = currentTime / maxTime;
            endPosition = startPosition + Vector3.left * speed * SmoothFunction(t);
            this.transform.position = endPosition;
            if (move) { desA = false; currentTime = 0.4f; }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            desW = true;
            move = false;
        }
        if (desW)
        {
            startPosition = this.transform.position;
            currentTime -= (Time.deltaTime * aceTime);
            if (currentTime <= 0f) { currentTime = 0f; desW = false; }
            float t = currentTime / maxTime;
            endPosition = startPosition + Vector3.forward * speed * SmoothFunction(t);
            this.transform.position = endPosition;
            if (move) { desW = false; currentTime = 0.4f; }
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            desS = true;
            move = false;
        }
        if (desS)
        {
            startPosition = this.transform.position;
            currentTime -= (Time.deltaTime * aceTime);
            if (currentTime <= 0f) { currentTime = 0f; desS = false; }
            float t = currentTime / maxTime;
            endPosition = startPosition + Vector3.back * speed * SmoothFunction(t);
            this.transform.position = endPosition;
            if (move) { desS = false; currentTime = 0.4f; }
        }


    }

    private void FixedUpdate()
    {
        // Gravity.
        Physics.gravity = gravityScale * newGravity;
    }

    // Funcion de aceleracion que lo hace mas "suave".
    static float SmoothFunction(float t)
    {
        float func;
        func = t * t * (3f - 2f * t);
        return func;
    }
}
