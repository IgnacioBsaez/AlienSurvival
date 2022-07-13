using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruir : MonoBehaviour
{

    public float timer = 5f;
    public float lifespame = 0;

    // Update is called once per frame
    void Update()
    {
        lifespame += Time.deltaTime;
        if(lifespame >= timer)
        {
            Destroy(gameObject);
        }
    }
}
