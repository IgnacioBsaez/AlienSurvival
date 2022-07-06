using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{

    public int healt = 3;
    public float speed;

    public Vector2 direccion;
    public float limiteXizquierda, limiteXderecha, limiteYarriba, limiteYabajo;

    public GameManager gm;


    // Update is called once per frame
    void Update()
    {

        //---------------------------- movimiento -----------------------------------------------
        direccion.x = Input.GetAxisRaw("Horizontal");
        direccion.y = Input.GetAxisRaw("Vertical");

        // normalizar el vector

        transform.Translate(direccion.normalized * speed * Time.deltaTime);

        // confinar espacio de movimiento

        Vector2 posicionCorregida = transform.position;

        posicionCorregida.x = Mathf.Clamp(posicionCorregida.x, limiteXizquierda, limiteXderecha);
        posicionCorregida.y = Mathf.Clamp(posicionCorregida.y, limiteYabajo, limiteYarriba);

        transform.position = posicionCorregida;

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
}
