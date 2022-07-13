using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject enemy;
    

    private float spawnInterval = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval,enemy));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new  WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-9f,9),Random.Range(0,100) >50? -6 :6,0), Quaternion.identity); 
        StartCoroutine(spawnEnemy(interval,enemy));
    }


}
