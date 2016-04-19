using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
    
    private Transform Target;
    private Transform TowerPosition;
    
    public float speed;
    private int Damage;
    public Sprite[] image;
    //public GameObject golemObject;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
        if (Target == null || TowerPosition == null) { return; }
        Vector3 dir = Target.position - TowerPosition.position;
        dir.Normalize();
        this.transform.position += speed * dir * Time.deltaTime;
	}

    

    public void SetTarget(Transform get)
    {
        Target = get; 
    }

    public void SetTower(Transform towerget)
    {
        TowerPosition = towerget;
    }

    public void SetImage(int index)//타워마다 어떠한 미사일 이미지가 나가는지 받는함수
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = image[index];
    }

    public void SetDamage(int damage) //타워마다의 대미지가 얼마인지 받는 함수
    {
        Damage = damage;
    }

    public int GetDamage() // 적에게 대미지를 수는함수
    {
        return Damage;
    }

 }
