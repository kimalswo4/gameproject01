using UnityEngine;
using System.Collections;


public class Pioneer : Enemy {
    public float Wait;
    public Renderer rend;
    public int DeathMoney;
    public int Buff;
    private GameObject Manger;
    
    public bool BuffOn;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        Invoke("CheckPosition", Wait);
        hp = 12;
        DeathMoney = 20;
        BuffOn = false;
        Manger = GameObject.Find("GameManger");
	}
	
	// Update is called once per frame
	void Update () {
        
        
       
	}
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Missile"))//연산을 적게먹음
        {
            Destroy(coll.gameObject);
            hp -= coll.gameObject.GetComponent<Missile>().GetDamage();
            if (hp <= 0)
            {
                Destroy(gameObject);
                Manger.GetComponent<GameManger>().AddGold(DeathMoney);
            }
        }
        
        if(coll.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
            Manger.GetComponent<GameManger>().TotalHp(1);
        }
    }
   

    void CheckPosition()
    {
        if(rend.enabled ==false)
        {
            rend.enabled = true;
        }
    }

   
   
}
