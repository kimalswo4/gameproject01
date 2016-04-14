using UnityEngine;
using System.Collections;

public class Sapper : Enemy {
    public float Wait;
    public Renderer rend;
    public int DeathMoney;
   
    private Transform _transform;
    private Vector3 _Attackrange;
    public float Range = 2.5f; //디버프 범위
    public bool BuffOn;
	// Use this for initialization
	void Start () {
        _transform = this.transform;
        _Attackrange = new Vector3(Range, Range);
        rend = GetComponent<Renderer>();
        hp = 9;
        DeathMoney = 30;
        BuffOn = false;
        Invoke("CheckPosition", Wait);
	}
	
	// Update is called once per frame
    void Update()
    {
        
        
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
