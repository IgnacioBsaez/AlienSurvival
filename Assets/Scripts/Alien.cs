using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Alien : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 10;
    public int healt;
    public float speed, punch;
    public Rigidbody2D rb2d;
    public TrailRenderer tr;

    public Vector2 direccion;
    public float limiteXizquierda, limiteXderecha, limiteYarriba, limiteYabajo;

    public Animator animator;

    public float dobleTapTimer;
    public float temp;
    public int dashSpeed = 2;
    public float distaciaDash = 3f;

    public bool W,A,S,D;


    public GameManager gm;
    Vector3 direccionDash,direccionHit;
    public bool onDash;
    public bool onHit;

    private void Start()
    {
        //healt = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        tr.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        temp += Time.deltaTime;
        //---------------------------- movimiento -----------------------------------------------
        direccion.x = Input.GetAxisRaw("Horizontal");
        direccion.y = Input.GetAxisRaw("Vertical");

        // normalizar el vector
        if (!onDash && !onHit)
        {

            transform.Translate(direccion.normalized * speed * Time.deltaTime);
        }
        else if(onDash && !onHit)
        {
            transform.position = Vector3.MoveTowards(transform.position,direccionDash,speed * dashSpeed * Time.deltaTime);
            tr.enabled = true;
            if(transform.position == direccionDash)
            {
                onDash = false;
                tr.enabled = false;
            }
        }
        else if (!onDash && onHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, direccionHit, speed * dashSpeed * Time.deltaTime);
            if (transform.position == direccionHit)
            {
                onHit = false;

            }
        }

        // confinar espacio de movimiento

        Vector2 posicionCorregida = transform.position;

        posicionCorregida.x = Mathf.Clamp(posicionCorregida.x, limiteXizquierda, limiteXderecha);
        posicionCorregida.y = Mathf.Clamp(posicionCorregida.y, limiteYabajo, limiteYarriba);

        transform.position = posicionCorregida;

        DobleTapDetecter();

        //-----------------------------------------------------------------------------------------

        //animator.SetFloat("X",direccion.x);
        //animator.SetFloat("Y",direccion.y);

        //-----------------------------------------------------------------------------------------

        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("UP");
        }else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("DWN");
        }else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("LFT");
        }else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("RIG");
        }

        healt = Mathf.Clamp(healt, 0 , maxHealth);

        if(healt <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("food"))
        //{
        //    // a?adir puntaje y destruir objeto
        //    healt += 1;
        //    gm.score += 1;
        //    Destroy(collision.gameObject);
        //}
        if (onDash && collision.gameObject.CompareTag("Enemy")) // al deslizarse destrulle enemigos
        {

                //Debug.Log("coliciona");
                gm.score += 1;
                Destroy(collision.gameObject);

        }
        if(!onDash && collision.gameObject.CompareTag("Enemy"))
        {
            onHit = true;
            direccionHit = (transform.position - collision.transform.position).normalized * punch;
            healt -= 1;
            healthBar.SetHealth(healt);
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
                   // Debug.Log("doble tab");
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
                   // Debug.Log("doble tab");
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
                   // Debug.Log("doble tab");
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
                   // Debug.Log("doble tab");
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

    public void SetHeal(int cantidad)
    {
        healt += cantidad;
        healthBar.SetHealth(healt);
    }



}
