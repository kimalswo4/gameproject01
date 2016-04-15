using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class EnemySpawn : MonoBehaviour {
    private enum EnemyType { Pioneer, Tanker, Sapper };


    public int enemiesLeft;
    public float spawnTime;
    public float spawnTimeLeft;
    public float spawnTimeSeconds = 2f;

    private float CreateTime;

    public GameObject[] Enemy;
    
    //public WaveArray[] waveFormation;
   
    void Start()
    {
        //waveFormation = new int[] {};
        //enemiesLeft = waveFormation.Length;
        OpenMapData(Application.dataPath+"/Data/Stage1.txt");
    }

    void Update()
    {
        
        
        
    }

    public void OpenMapData(string path)
    {
        FileStream fs = new FileStream(path, FileMode.Open);
        StreamReader sr = new StreamReader(fs);
        float totalTime = 0.0f;
        while (sr.Peek() > -1)
        {
            string[] data = sr.ReadLine().Split('\t'); //Splite \t기준으로 나눠서 배열에저장
            switch (data[0])
            {
                case "TimeSet":
                    CreateTime = float.Parse(data[1]); //Parse 변환 ex. float.Parse float형으로 형변환
                    break;
                case "Create":
                    totalTime += CreateTime;
                    if (data[1] == "Pionner")
                    {
                        Invoke("CreatePioneer", totalTime);
                    }
                    else if (data[1] == "Tanker")
                    {
                        Invoke("CreateTanker", totalTime);
                    }
                    else if (data[1] == "Sapper")
                    {
                        Invoke("CreateSapper", totalTime);
                    }
                    break;
                case "Stop":

                    break;
                
            }
        }
    }

    private void CreateEnemy(EnemyType type)
    {
        switch(type)
        {
            case EnemyType.Pioneer:
                Instantiate(Enemy[0], transform.position, Quaternion.identity);
                break;

            case EnemyType.Sapper:
                Instantiate(Enemy[1], transform.position, Quaternion.identity);
                break;
                
            case EnemyType.Tanker:
                Instantiate(Enemy[2], transform.position, Quaternion.identity);
                break;
        }
    }
    private void CreatePioneer()
    {
        Debug.Log("1");
        CreateEnemy(EnemyType.Pioneer);
    }

    private void CreateSapper()
    {
        Debug.Log("2");
        CreateEnemy(EnemyType.Sapper);
    }

    private void CreateTanker()
    {
        Debug.Log("3");
        CreateEnemy(EnemyType.Tanker);
    }
}
