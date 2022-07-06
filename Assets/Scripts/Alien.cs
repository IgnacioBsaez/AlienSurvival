using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{

    public int healt = 3;
    public float speed;

    public Vector2 direccion;
    public float limiteXizquierda, limiteXderecha, limiteYarriba, limiteYabajo;

    public float dobleTapTimer;
    public float temp;
    public int dashSpeed = 2;
    public float distaciaDash = 3f;

    public bool W,A,S,D;


    public GameManager gm;
    Vector3 direccionDash;
    bool onDash;

    // Update is called once per frame
    void Update()
    {
        temp += Time.deltaTime;
        //---------------------------- movimiento -----------------------------------------------
        direccion.x = Input.GetAxisRaw("Horizontal");
        direccion.y = Input.GetAxisRaw("Vertical");

        // normalizar el vector
        if (!onDash)
        {

            transform.Translate(direccion.normalized * speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,direccionDash,speed * dashSpeed * Time.deltaTime);
            if(transform.position == direccionDash)
            {
                onDash = false;

            }
        }

        // confinar espacio de movimiento

        Vector2 posicionCorregida = transform.position;

        posicionCorregida.x = Mathf.Clamp(posicionCorregida.x, limiteXizquierda, limiteXderecha);
        posicionCorregida.y = Mathf.Clamp(posicionCorregida.y, limiteYabajo, limiteYarriba);

        transform.position = posicionCorregida;

        DobleTapDetecter();

        //-----------------------------------------------------------------------------------------
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("food"))
        {
            // añadir puntaje y destruir objeto

            gm.score += 1;
            Destroy(collision.gameObject);
        }
    }

    private void DobleTapDetecter()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(W == false)
            {
                W = true;
                temp = 0;
                DesabilitarBools(1);
            }
            else
            {
                if(temp <= dobleTapTimer)
                {
                    direccionDash = transform.position + Vector3.up * distaciaDash ;
                    onDash = true;
                    Debug.Log("doble tab");
                    temp = 0;
                    W = false;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (A == false)
            {
                A = true;
                temp = 0;
                DesabilitarBools(2);
            }
            else
            {
                if (temp <= dobleTapTimer)
                {
                    direccionDash = transform.position + Vector3.left * distaciaDash;
                    onDash = true;
                    Debug.Log("doble tab");
                    temp = 0;
                    A = false;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (S == false)
            {
                S = true;
                temp = 0;
                DesabilitarBools(3);
            }
            else
            {
                if (temp <= dobleTapTimer)
                {
                    direccionDash = transform.position + Vector3.down * distaciaDash;
                    onDash = true;
                    Debug.Log("doble tab");
                    temp = 0;
                    S = false;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (D == false)
            {
                D = true;
                temp = 0;
                DesabilitarBools(4);
            }
            else
            {
                if (temp <= dobleTapTimer)
                {
                    direccionDash = transform.position + Vector3.right * distaciaDash;
                    onDash = true;
                    Debug.Log("doble tab");
                    temp = 0;
                    D = false;
                }
            }
        }
    }

    private void DesabilitarBools(int num)
    {
        // W = 1, A= 2, S = 3 , D = 4

        switch (num)
        {
            case 1: 
                W = true;
                A = false;
                S = false;
                D = false;
                break;
            case 2:
                W = false;
                A = true;
                S = false;
                D = false;
                break;
            case 3:
                W = false;
                A = false;
                S = true;
                D = false;
                break;
            case 4:
                W = false;
                A = false;
                S = false;
                D = true;
                break;
        }
    }
}
