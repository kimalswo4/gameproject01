using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
    private golem tower;
    private Transform Target;
    private Transform TowerPosition;
    
    public float speed;

    //public GameObject golemObject;
	// Use this for initialization
	void Start () {
        tower = GameObject.Find("TowerTest(Clone)").GetComponent<golem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Target == null || TowerPosition == null) { return; }
        Vector3 dir = Target.position - TowerPosition.position;
        dir.Normalize();
        this.transform.position += speed * dir * Time.deltaTime;
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Enemy")
        {
            
            Destroy(gameObject);
            
        }
    }

    public void SetTarget(Transform get)
    {
        Target = get; 
    }

    public void SetTower(Transform towerget)
    {
        TowerPosition = towerget;
    }
}
