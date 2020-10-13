using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public GameObject gm;
    public int count=0;
    public string op="";
    GameMaster gmScript;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gmScript = gm.GetComponent<GameMaster>();

        Color baseColorRed = new Color( 0.7f,0f,0f);
        Renderer rend = GetComponent<Renderer>();
        Material mat = rend.material;
        mat.SetColor("_Color", baseColorRed);
    }

    void FixedUpdate()
    {
        if (!gmScript.IsGameOver())
        {
            rb.velocity = new Vector3(0, rb.velocity.y, speed);

            rb.AddForce(Vector3.down * 100f);

            if (this.transform.position.y < -3)
            {
                Debug.Log("Killed by falling");
                gmScript.SetGameOver(true);
            }

        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision hit)
    {
        Color baseColorBlue = new Color( 0f,0f,0.7f);
        Color baseColorRed = new Color( 0.7f,0f,0f);
        Color baseColorGreen = new Color( 0.0f,0.7f,0f);
        Renderer rend = GetComponent<Renderer>();
        Material mat = rend.material;
        Debug.Log("Collision:" + (mat.color==baseColorRed));

        if (hit.gameObject.CompareTag("Red") && (mat.color==baseColorRed)) {
            Destroy(hit.gameObject);
        } else if (hit.gameObject.CompareTag("Green") && (mat.color==baseColorGreen) ) {
            Destroy(hit.gameObject);
        } else if(hit.gameObject.CompareTag("Blue") && (mat.color==baseColorBlue) ) {
            Destroy(hit.gameObject);
        } else if(hit.gameObject.CompareTag("BlueLoop")) {
            mat.SetColor("_Color", baseColorBlue);
            Destroy(hit.gameObject);
        } else if(hit.gameObject.CompareTag("GreenLoop")) {
            mat.SetColor("_Color", baseColorGreen);
            Destroy(hit.gameObject);
        } else if(hit.gameObject.CompareTag("RedLoop")) {
            mat.SetColor("_Color", baseColorRed);
            Destroy(hit.gameObject);
        } else if( (hit.gameObject.CompareTag("Red") && (mat.color!=baseColorRed)) || (hit.gameObject.CompareTag("Blue") && (mat.color!=baseColorBlue)) || (hit.gameObject.CompareTag("Green") && (mat.color!=baseColorGreen)) ) {
            gmScript.SetGameOver(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            gmScript.IncreamentScore(5);
            Destroy(other.gameObject);
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetSpeed()
    {
        return this.speed;
    }
}

 