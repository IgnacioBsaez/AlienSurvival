using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private GameObject Target;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Player");
        Vector2 vector2 = (Vector2)Target.transform.position - (Vector2)transform.position;
        Vector2 direccion = vector2;
        transform.up = direccion;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
