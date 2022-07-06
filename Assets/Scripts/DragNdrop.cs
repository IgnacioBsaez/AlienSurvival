using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNdrop : MonoBehaviour
{

    bool isDragging;
    Vector3 diferencia;
    private void OnMouseDown()
    {
        isDragging = true;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        diferencia = transform.position - worldPos;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldPos + diferencia;
    }

    private void OnMouseUpAsButton()
    {
        isDragging = false;
    }

}
