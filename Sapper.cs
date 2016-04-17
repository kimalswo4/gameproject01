using UnityEngine;
using System.Collections;

public class Sapper : Enemy {
    public float Wait;
    public Renderer rend;
    public int DeathMoney;
   
    private Vector3 _Attackrange;
    public float Range = 2.5f; //디버프 범위
    public bool BuffOn;
    private GameObject Manger;
	// Use this for initialization
	void Start () {
        _Attackrange = new Vector3(Range, Range);
        rend = GetComponent<Renderer>();
        hp = 9;
        DeathMoney = 30;
        BuffOn = false;
        Invoke("CheckPosition", Wait);
        Manger = GameObject.Find("GameManger");
	}
	
	// Update is called once per frame
    void Update()
    {
        if(BuffOn == false)
        {
            Debuff();
        }
        
    }

    void CheckPosition()
    {
        if (rend.enabled == false)
        {
            rend.enabled = true;

        }
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
        if (coll.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
            Manger.GetComponent<GameManger>().TotalHp(1);
        }
    }

    void Debuff() // 디버프 타워공격 5초간못하게함
    {
        RaycastHit hit;
        if (Physics.BoxCast(transform.position, _Attackrange,Vector3.right,out hit))
        {
                if (hit.collider.gameObject.tag == "Tower")
                {
                    hit.collider.GetComponent<Tower>().StartCoroutine("StopDebuff");
                    StartCoroutine("CheckDebuff");
                }
        }
    }

    IEnumerator CheckDebuff()
    {
        BuffOn = true;
        yield return new WaitForSeconds(5.0f);
        BuffOn = false;
    }
}
