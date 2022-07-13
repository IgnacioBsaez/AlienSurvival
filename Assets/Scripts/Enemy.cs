using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string orientacion;
    private GameObject target;
    public float speed = 5f;
    public Animator anim;
    Vector2 direccion;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        Vector2 vector2 = (Vector2)target.transform.position - (Vector2)transform.position;
         direccion = vector2;
        //transform.up = direccion;
        direccion.Normalize();


    }

    // Update is called once per frame
    void Update()
    {
       // transform.position += transform.up * speed * Time.deltaTime;
       transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        Vector3 d = target.transform.position - transform.position;
        d.Normalize();

        if(Vector3.Angle(d,Vector3.up)<= 45.0)
        {
            orientacion = "norte";
            anim.Play("TarUP");
        }
        else if(Vector3.Angle(d, Vector3.right) <= 45.0)
        {
            orientacion = "este";
            anim.Play("TarRIG");
        }
        else if(Vector3.Angle(d,Vector3.down) <= 45.0)
        {
            orientacion = "sur";
             anim.Play("TarDOWN");
        }
        else
        {
            orientacion = "oeste";
            anim.Play("TarLFT");
        }

        print(orientacion);
        //transform.Translate(direccion * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.tag == "Bullet")
        //{
        //    Destroy(gameObject);
        //}
        //if (collision.tag == "Player")
        //{
        //    Destroy(gameObject);
        //}
    }

  
}
