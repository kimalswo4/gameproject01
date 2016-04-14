using UnityEngine;
using System.Collections;


public class Pioneer : Enemy {
    public float Wait;
    public Renderer rend;
    public int DeathMoney;
    public int Buff;
    
    public bool BuffOn;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        Invoke("CheckPosition", Wait);
        hp = 12;
        DeathMoney = 20;
        BuffOn = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        
       
	}

   

    void CheckPosition()
    {
        if(rend.enabled ==false)
        {
            rend.enabled = true;
        }
    }

   
   
}
