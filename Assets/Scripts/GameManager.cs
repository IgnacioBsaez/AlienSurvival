using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gm;

    public int score;
    public float time;

    private void Awake()
    {
        gm = this;
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

}
