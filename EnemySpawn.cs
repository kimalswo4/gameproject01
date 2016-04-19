using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class EnemySpawn : MonoBehaviour {
    private enum EnemyType { Pioneer, Tanker, Sapper };
    public int waveCount;
    private float CreateTime;
    public GameObject[] Enemy;
    public GameObject Night;
   
    void Start()
    {
        //waveFormation = new int[] {};
        //enemiesLeft = waveFormation.Length;
        waveCount = 1;
        StartCoroutine(OpenMapData(Application.dataPath+"/Data/Stage1.txt"));
    }

    void Update()
    {
        
        
        
    }
        
    IEnumerator OpenMapData(string path)
    {
        FileStream fs = new FileStream(path, FileMode.Open);
        StreamReader sr = new StreamReader(fs);
        float totalTime = 0.0f;
        float wait = 0.0f;
        while (sr.Peek() > -1)//코루틴으로 바꿔야함
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
                        yield return new WaitForSeconds(CreateTime);
                        CreatePioneer();
                    }
                    else if (data[1] == "Tanker" )
                    {
                        yield return new WaitForSeconds(CreateTime);
                        CreateTanker();
                        //Invoke("CreateTanker", totalTime);
                    }
                    else if (data[1] == "Sapper")
                    {
                        yield return new WaitForSeconds(CreateTime);
                        CreateSapper();
                    }
                    break;
                case "Stop":
                    wait = float.Parse(data[1]);
                    Night.GetComponent<CameraManeger>().Night = true;
                    yield return new WaitForSeconds(wait);
                    Night.GetComponent<CameraManeger>().Night = false;
                    waveCount++;
                    break;
                case "Start":
                    wait = float.Parse(data[1]);
                    Night.GetComponent<CameraManeger>().Night = true;
                    yield return new WaitForSeconds(wait);
                    Night.GetComponent<CameraManeger>().Night = false;
                    break;
             
            }
        }
        
    }

    private void CreateEnemy(EnemyType type)
    {
        switch(type)
        {
            case EnemyType.Pioneer:
                Instantiate(Enemy[0], transform.position, Quaternion.Euler(0,-180.0f,0));
                break;

            case EnemyType.Sapper:
                Instantiate(Enemy[1], transform.position, Quaternion.Euler(0, -180.0f, 0));
                break;
                
            case EnemyType.Tanker:
                Instantiate(Enemy[2], transform.position, Quaternion.Euler(0, -180.0f, 0));
                break;
        }
    }
    private void CreatePioneer()
    {
        CreateEnemy(EnemyType.Pioneer);
    }

    private void CreateSapper()
    {
        CreateEnemy(EnemyType.Sapper);
    }

    private void CreateTanker()
    {
        CreateEnemy(EnemyType.Tanker);
    }
}
