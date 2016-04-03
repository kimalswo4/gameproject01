using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
    private golem tower;
    private Transform Target;
    

    //public GameObject golemObject;
	// Use this for initialization
	void Start () {
        tower = GameObject.Find("TowerTest").GetComponent<golem>();
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime);
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Enemy")
        {
            
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }

    public void SetTarget(Transform get)
    {
        Target = get; 

    }
}
