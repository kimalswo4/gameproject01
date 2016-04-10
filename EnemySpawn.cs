using UnityEngine;
using System.Collections;



public class EnemySpawn : MonoBehaviour {

    public GameObject Pioneer;
    public GameObject Tanker;
    public GameObject Sapper;

    public int enemiesLeft;
    public float spawnTime;
    public float spawnTimeLeft;
    public float spawnTimeSeconds = 2f;
    public int i = 0; //나온 몬스터 숫자
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
                    
                    Instantiate(Pioneer, transform.position, Quaternion.identity);                  
                    spawnTime = Time.time;
                    spawnTimeLeft = 0;
                    i++;
                }
                else if(waveFormation[i]==1)
                {
                    
                    Instantiate(Tanker, transform.position, Quaternion.identity);
                    spawnTime = Time.time;
                    spawnTimeLeft = 0;
                    i++;
                }
                else if(waveFormation[i]==2)
                {
                    Instantiate(Sapper, transform.position, Quaternion.identity);
                    spawnTime = Time.time;
                    spawnTimeLeft = 0;
                    i++;
                }
            }
        }
    }

}
