using UnityEngine;
using System.Collections;

public class golem : MonoBehaviour {

    public float Range = 2.5f; //공격범위
    
    
    public float SearchTimeLeft = 0.0f;
    public float SearchTimeSeconds = 2.0f;

    public GameObject Missile;
    public GameObject MissilePoint;
    public float MissileSpeed = 2.0f;

    private Transform _transform;
    private Vector3 _Attackrange;
    private GameObject Enemy;
    public Vector3 targetDir;

	// Use this for initialization
	void Start () {
        _transform = this.transform;
        _Attackrange = new Vector3(Range, Range);
        
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit[] hit = Physics.BoxCastAll(_transform.position, _Attackrange, Vector3.forward, Quaternion.identity, Mathf.Infinity, (-1) - (1 << LayerMask.NameToLayer("Tower")));
        
        if (Time.time > SearchTimeLeft) 
        {
            
            SearchTimeLeft = Time.time + SearchTimeSeconds;
            if (hit != null)
            {                   
                    for (int num = 0; num < hit.Length; num++)
                    {
                        if (hit[num].collider.gameObject.tag == "Enemy" && num <4)
                        {

                            
                               
                            GameObject missile = Instantiate(Missile, MissilePoint.transform.position, MissilePoint.transform.rotation)as GameObject;
                            missile.GetComponent<Missile>().SetTarget(hit[num].collider.transform);
                                                        
                            
                                
                        }
                    }
                
            }

        }
                
	}
    
}
