using UnityEngine;
using System.Collections;


public class Pioneer : MonoBehaviour {
    public float Wait;
    public Renderer rend;
    public int hp;
    public int DeathMoney;
    public int Buff;
    private int G_Damage;
    private int T_Damage;
    private int W_Damage;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        G_Damage = GetComponent<Missile>().Damage;
        T_Damage = GetComponent<t_missile>().Damage;
        W_Damage = GetComponent<w_missile>().Damage;
        hp = 12;
        DeathMoney = 20;
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("CheckPosition", Wait);
        
        if (hp == 0)
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
        if(rend.enabled ==false)
        {
            rend.enabled = true;
            
        }
    }

   
   
}
