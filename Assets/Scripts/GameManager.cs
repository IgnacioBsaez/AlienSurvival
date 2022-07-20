using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{

    public static GameManager gm;

    public int score;
    public float time;
    public TextMeshProUGUI socre;

    private void Awake()
    {
        gm = this;
    }

    private void Update()
    {
        time += Time.deltaTime;
        socre.text = score.ToString("00000");
    }

}
