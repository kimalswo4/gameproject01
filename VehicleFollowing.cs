using UnityEngine;
using System.Collections;

public class VehicleFollowing : MonoBehaviour {
    public Path path;
    public float speed = 2.0f;
    public float mass = 2.0f;

    private float monSpeed;
    private int monPathIndex;
    private float pathLength;
    private Vector3 targetPoint;

    Vector3 velocity;
	// Use this for initialization
	void Start () {
        pathLength = path.Length;
        monPathIndex = 0;
        
        velocity = transform.forward;
	}
	
	// Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y, -1.401298e-45f);

        monSpeed = speed * Time.deltaTime;

        targetPoint = path.Getpoint(monPathIndex);
         
        //목적지의 반지름내에 들어왓을시 경로다음지점이동
        if (Vector3.Distance(transform.position, targetPoint) < path.Radius)
        {
            //경로끝낫을시 정지
            if (monPathIndex < pathLength - 1)
                monPathIndex++;
            else
                return;
        }
        //최종지점에 도착안햇을시에 계속 이동
        if (monPathIndex >= pathLength)
            return;
        
        //경로를 따라서 다음Velocity계산
        if (monPathIndex >= pathLength - 1)
            velocity += Steer(targetPoint, true);
        else
            velocity += Steer(targetPoint);

        //속도에 따라 이동
        transform.position += velocity;
        
        
         
    }
    
    public Vector3 Steer(Vector3 target, bool bFinalPoint = false)
    {
        //현재 위치에서 목적지 방향으로 방향벡터 계산
        Vector3 desiredVelocity = (target - transform.position);
        float dist = desiredVelocity.magnitude;

        //원하는 velocity를 정규화
        desiredVelocity.Normalize();

        //속력에 따라 속력계산
        if (bFinalPoint && dist < 10.0f)     
            desiredVelocity *= (monSpeed * (dist / 10.0f));
            
        else
            desiredVelocity *= monSpeed;
             

        //힘vector계산
        Vector3 steeringForce = desiredVelocity - velocity;
        Vector3 acceleration = steeringForce / mass;

        return acceleration;

        
    }
    
}

