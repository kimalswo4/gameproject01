using UnityEngine;
using System.Collections;

public class CameraManeger : MonoBehaviour {
    private Vector3 ResetCamera;
    private Vector3 Origin;
    private Vector3 Diference;

    private bool tower1 = false;
    private bool tower2 = false;
    private bool tower3 = false;

    public GameObject TowerObject1;
    public GameObject TowerObject2;
    public GameObject TowerObject3;
    


    private bool Drag = false;

    void start()
    {
        ResetCamera = Camera.main.transform.position;
        
    }


    void Update()
    {
        check();
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

   void check()
   {
       RaycastHit hit = new RaycastHit();

       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       if(Input.GetMouseButtonDown(0))
       { 
           if (Physics.Raycast(ray, out hit))
           {
               if (hit.collider.tag == "Tower1")
               {

                   tower1 = true;
                   tower2 = false;
                   tower3 = false;
               }

               if(hit.collider.tag == "Tower2")
               {
                   tower1 = false;
                   tower2 = true;
                   tower3 = false;
               }
           
               if(hit.collider.tag == "Tower3")
               {
                   tower1 = false;
                   tower2 = false;
                   tower3 = true;
               }
               if(hit.collider.tag == "Ground" && hit.collider.gameObject.GetComponent<GroundScript>().build == false)
               {
                   if(tower1 == true)
                   {
                       Instantiate(TowerObject1, hit.transform.position, Quaternion.identity);
                       hit.collider.gameObject.GetComponent<GroundScript>().build = true;
                       tower1 = false;
                   }
                   
                   else if(tower2 == true)
                   {

                   }

                   else if(tower3 == true)
                   {

                   }
               }
               
           }
       }
   }
}
