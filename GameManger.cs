using UnityEngine;
using System.Collections;

public class GameManger : MonoBehaviour {
    
    private int StartMoney; //시작돈
    private int TurnMoney; //매초마다주는돈
    public int CurrentMoney = 0;
    public int GameLife; //체력
    public int KillMoney; //적잡앗을때 받는돈

    private float time = 0.0f;
    [SerializeField]
    private float TurnGoldTime;


    void Awake()
    {
        CurrentMoney = StartMoney;
    }

	// Use this for initialization
	void Start () {
        StartMoney = 500;
        TurnMoney = 10;
	}
	
	// Update is called once per frame
	void Update () {
	    
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

    private void TurnAddGold()
    {
        if (time > TurnGoldTime)
        {
            CurrentMoney += TurnMoney;
        }
        else
        {
            time += Time.deltaTime;
        }
    }

     
}
