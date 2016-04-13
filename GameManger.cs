using UnityEngine;
using System.Collections;

public class GameManger : MonoBehaviour {

    public int StartMoney; //시작돈
    public int TurnMoney; //매초마다주는돈
    public int GameLife; //체력
    public int KillMoney; //적잡앗을때 받는돈

	// Use this for initialization
	void Start () {
        StartMoney = 500;
        TurnMoney = 10;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
