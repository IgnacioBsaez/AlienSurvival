using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BotonSimple : MonoBehaviour
{
    public UnityEvent onEnter, onExit, onDown, onUp;


    private void OnMouseEnter()
    {
        onEnter.Invoke();
    }

    private void OnMouseExit()
    {
        onExit.Invoke();
    }

    private void OnMouseDown()
    {
        onDown.Invoke();
    }

    private void OnMouseUpAsButton()
    {
        onUp.Invoke();
    }
}
