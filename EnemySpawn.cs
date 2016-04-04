using UnityEngine;
using System.Collections;



public class EnemySpawn : MonoBehaviour {

    public GameObject NormalPrefab;
    public GameObject HeavyPrefab;

    public int enemiesLeft;
    public float spawnTime;
    public float spawnTimeLeft;
    public float spawnTimeSeconds = 2f;
    public int i = 0;
    public int[] waveFormation;

    void Start()
    {
        //waveFormation = new int[] {};
        enemiesLeft = waveFormation.Length;
    }

    void Update()
    {
        spawnTimeLeft = Time.time - spawnTime;
        if(spawnTimeLeft >= spawnTimeSeconds)
        {
            if(i != waveFormation.Length)
            {
                if(waveFormation[i]==0)
                {
                    
                    Instantiate(NormalPrefab, transform.position, Quaternion.identity);                  
                    spawnTime = Time.time;
                    spawnTimeLeft = 0;
                    i++;
                }
                else
                {
                    Instantiate(HeavyPrefab, transform.position, Quaternion.identity);
                    spawnTime = Time.time;
                    spawnTimeLeft = 0;
                    i++;
                }
            }
        }
    }

}
