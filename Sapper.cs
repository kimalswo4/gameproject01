using UnityEngine;
using System.Collections;

public class Sapper : MonoBehaviour {
    public float Wait;
    public Renderer rend;
    public int hp;
    public int DeathMoney;
    private int G_Damage;
    private int T_Damage;
    private int W_Damage;
    private Transform _transform;
    private Vector3 _Attackrange;
    public float Range = 2.5f; //디버프 범위
	// Use this for initialization
	void Start () {
        _transform = this.transform;
        _Attackrange = new Vector3(Range, Range);
        rend = GetComponent<Renderer>();
        hp = 9;
        G_Damage = GetComponent<Missile>().Damage;
        T_Damage = GetComponent<t_missile>().Damage;
        W_Damage = GetComponent<w_missile>().Damage;
        DeathMoney = 30;
	}
	
	// Update is called once per frame
    void Update()
    {
        Invoke("CheckPosition", Wait);
        if(hp == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "g_missile")
        {
            hp -= G_Damage;
        }

        if (coll.tag == "t_missile")
        {
            hp -= T_Damage;
        }

        if (coll.tag == "w_missile")
        {
            hp -= W_Damage;
        }
    }

    void CheckPosition()
    {
        if (rend.enabled == false)
        {
            rend.enabled = true;

        }
    }
    void Debuff() // 디버프 타워공격 5초간못하게함
    {
        RaycastHit[] hit = Physics.BoxCastAll(_transform.position, _Attackrange, Vector3.forward, Quaternion.identity, Mathf.Infinity);

        if (hit != null)
        {
            for (int num = 0; num < hit.Length; num++)
            {
                if (hit[num].collider.gameObject.tag == "Tower1" || hit[num].collider.gameObject.tag == "Tower2" || hit[num].collider.gameObject.tag == "Tower3")
                {


                }
            }

        }


    }
}
