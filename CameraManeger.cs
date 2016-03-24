using UnityEngine;
using System.Collections;

public class CameraManeger : MonoBehaviour {
    private Vector3 ResetCamera;
    private Vector3 Origin;
    private Vector3 Diference;



    private bool Drag = false;

    void start()
    {
        ResetCamera = Camera.main.transform.position;

    }

    void LateUpdate() //LateUpdate()는 Update() 후 프레임마다 한 번씩 호출됩니다. Update()에서 수행되는 계산이 완료되면 LateUpdate() 함수가 시작 합니다. 
    {
        if (Input.GetMouseButton(0))
        {
            Diference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (Drag == false)
            {
                Drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            Drag = false;
        }
        if (Drag == true)
        {
            Camera.main.transform.position = Origin - Diference;
        }

        if (Input.GetMouseButton(1))
        {
            Camera.main.transform.position = ResetCamera;
        }

    }
}
