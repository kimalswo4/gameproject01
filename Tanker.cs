using UnityEngine;
using System.Collections;

public class Tanker : MonoBehaviour {
    public float Wait;
    public Renderer rend;
    public int hp;
    public int DeathMoney;
    private int G_Damage;
    private int T_Damage;
    private int W_Damage;
    private Transform _transform;
    private Vector3 _Attackrange;
    public float Range = 2.5f; //버프 범위
    public bool BuffOn;

    // Use this for initialization
    void Start()
    {
        _transform = this.transform;
        _Attackrange = new Vector3(Range, Range);
        G_Damage = GetComponent<Missile>().Damage;
        T_Damage = GetComponent<t_missile>().Damage;
        W_Damage = GetComponent<w_missile>().Damage;
        rend = GetComponent<Renderer>();
        hp = 24;
        DeathMoney = 50;
        BuffOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("CheckPosition", Wait);
        if (hp <= 0)
        {
            Destroy(gameObject);
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
        if (coll.tag == "g_missile")
        {
            hp -= G_Damage;
            if (BuffOn == true) 
            {
                hp -= G_Damage + 1;
            }
        }

        if (coll.tag == "t_missile")
        {
            hp -= T_Damage;
            if (BuffOn == true)
            {
                hp -= T_Damage + 1;
            }
        }

        if (coll.tag == "w_missile")
        {
            hp -= W_Damage;
            if (BuffOn == true)
            {
                hp -= W_Damage + 1;
            }
        }
    }
    
    void Buff() // 자기주위에 자신의팀에게 대미지1감소시키는 버프를 넣어준다.
    {
        RaycastHit[] hit = Physics.BoxCastAll(_transform.position, _Attackrange, Vector3.forward, Quaternion.identity, Mathf.Infinity);
        
           if (hit != null)
            {                
                for (int num = 0; num < hit.Length; num++)
                {
                    if (hit[num].collider.gameObject.tag == "Enemy")
                    {
                        
                        
                    }
                }

            }

        
    }
    
}
