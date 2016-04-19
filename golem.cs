using UnityEngine;
using System.Collections;

public class golem : Tower
{

    // Use this for initialization
    void Start()
    {
        _transform = this.transform;
        _Attackrange = new Vector3(Range, Range);
        S_Debuff = false;
        Damage = 2;
        MaxEnemyCount = 3;
        MissileImage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemyShot();

    }

}
