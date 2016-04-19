using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManger : MonoBehaviour
{
    private int StartMoney; //시작돈
    private int TurnMoney; //매초마다주는돈
    public int CurrentMoney = 0; //돈계산도와줌
    private int GameLife; //체력
    public GameObject EnemySpawn;
    public Text Gold;
    public Text WaveCount;
    public Text Life;
    public Text Wave;
    public GameObject GameOver;


    [SerializeField]
    private float TurnGoldTime;

    

    // Use this for initialization
    void Start()
    {
        GameLife = 30;
        StartMoney = 500;
        TurnMoney = 10;
        StartCoroutine(TurnAddGold(1));
        CurrentMoney += StartMoney;
    }

    // Update is called once per frame
    void Update()
    {
        GUI();
    }

    public void AddGold(int g)
    {
        CurrentMoney += g;
    }

    public void UseGold(int g)
    {
        CurrentMoney -= g;
    }

    public bool CheckGold(int g)
    {
        return CurrentMoney >= g;
    }

    IEnumerator TurnAddGold(float delay)
    {
        yield return new WaitForSeconds(delay);
        CurrentMoney += TurnMoney;
        StartCoroutine(TurnAddGold(1));
    }

    public void TotalHp(int damage)
    {
        GameLife -= damage;
        if (GameLife <= 0)
        {
            GameOver.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    private void GUI()
    {
        Gold.text = CurrentMoney + "";
        Life.text = "X" + GameLife;
        Wave.text = EnemySpawn.GetComponent<EnemySpawn>().waveCount + "Wave";
    }
}
