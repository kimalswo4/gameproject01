﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tanker : Enemy
{
    public float Wait;
    public Renderer rend;
    public int DeathMoney;

    private Transform _transform;
    private Vector3 _Attackrange;
    public float Range = 2.5f; //버프 범위
    public bool BuffOn;
    private List<Enemy> PrevEnemy;
    private List<Enemy> CurrentEnemy;

    private float time;




    // Use this for initialization
    void Start()
    {
        time = 0;
        _transform = this.transform;
        _Attackrange = new Vector3(Range, Range);
        rend = GetComponent<Renderer>();
        hp = 24;
        DeathMoney = 50;
        BuffOn = false;
        Invoke("CheckPosition", Wait); //Invoke는 Update함수에 넣으면 안됨 프레임마다 Invoke가실행되기때문에 몇초뒤 프레임마다 실행됨
        PrevEnemy = new List<Enemy>();
        CurrentEnemy = new List<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        Buff();

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
            }
        }



    }

    void Buff() // 자기주위에 자신의팀에게 대미지1감소시키는 버프를 넣어준다.
    {
        RaycastHit[] hit = Physics.BoxCastAll(_transform.position, _Attackrange, Vector3.forward, Quaternion.identity, Mathf.Infinity);
        PrevEnemy = CurrentEnemy;
        CurrentEnemy.Clear();
        if (hit != null)
        {
            for (int num = 0; num < hit.Length; num++)
            {
                if (hit[num].collider.gameObject.tag == "Enemy")
                {
                    Debug.Log(hit[num].collider.name);
                    CurrentEnemy.Add(hit[num].collider.GetComponent<Enemy>());
                }
            }
        }
        BuffToList(PrevEnemy);
        BuffToList(CurrentEnemy);
    }

    private void BuffToList(List<Enemy> EnemyList)
    {
        for (int index = 0; index < EnemyList.Count; ++index)
        {
            EnemyList[index].SetBuffDeffence(1);
        }
    }
}