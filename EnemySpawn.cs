using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemySpawn : MonoBehaviour {

    public GameObject Pioneer;
    public GameObject Tanker;
    public GameObject Sapper;

    
    public int enemiesLeft;
    public float spawnTime;
    public float spawnTimeLeft;
    public float spawnTimeSeconds = 2f;

    public int i; //웨이브 몬스터숫자
    public int t_m;//웨이브몬스터 총수
    public int w; //웨이브단위
    public int t_w;//총웨이브수

    
    //public WaveArray[] waveFormation;
   
    void Start()
    {
        //waveFormation = new int[] {};
        //enemiesLeft = waveFormation.Length;
        
    }

    void Update()
    {
        
        
        spawnTimeLeft = Time.time - spawnTime;
        if(spawnTimeLeft >= spawnTimeSeconds)
        {
            
           
                    /*
                    if (waveFormation.Length == 0)
                    {

                        Instantiate(Pioneer, transform.position, Quaternion.identity);
                        spawnTime = Time.time;
                        spawnTimeLeft = 0;

                    }
                    else if (waveFormation[w][i] == 1)
                    {

                        Instantiate(Tanker, transform.position, Quaternion.identity);
                        spawnTime = Time.time;
                        spawnTimeLeft = 0;

                    }
                    else if (waveFormation[w][i] == 2)
                    {
                        Instantiate(Sapper, transform.position, Quaternion.identity);
                        spawnTime = Time.time;
                        spawnTimeLeft = 0;

                    }
                     */
                
            
        }
    }

}
