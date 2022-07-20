using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Evento
{
    public string tag;
    public UnityEvent eventos;


    public void ChequearEvento(Collider2D col2d, bool desActivar)
    {
        if (col2d.tag == tag)
        {
            if (desActivar)
            {
                col2d.gameObject.SetActive(false);

            }
            eventos.Invoke();
        }
    }

}

public class DetectarColision : MonoBehaviour
{
    public bool destruirTrigger;

    public List<Evento> onEnter = new List<Evento>();
    public List<Evento> onStay = new List<Evento>();
    public List<Evento> onExit = new List<Evento>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RecorrerLista(onEnter, collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        RecorrerLista(onStay, collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RecorrerLista(onExit, collision);
    }

    void RecorrerLista(List<Evento> _evento, Collider2D col2d)
    {
        for(int i = 0; i < _evento.Count; i++)
        {
            _evento[i].ChequearEvento(col2d, destruirTrigger);
        }
    }
}
