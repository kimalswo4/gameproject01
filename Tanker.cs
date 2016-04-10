using UnityEngine;
using System.Collections;

public class Tanker : MonoBehaviour {
    public float Wait;
    public Renderer rend;
    public int hp;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        hp = 24;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("CheckPosition", Wait);
        if (hp == 0)
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
}
