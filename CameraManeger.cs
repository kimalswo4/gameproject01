using UnityEngine;
using System.Collections;

public class CameraManeger : MonoBehaviour {
    private Vector3 Origin;
    private Vector3 Diference;

    private bool tower1 = false;
    private bool tower2 = false;
    private bool tower3 = false;
    public GameObject Manager;
    public GameObject NotEnoughMoney;

    public GameObject TowerObject1;
    public GameObject TowerObject2;
    public GameObject TowerObject3;

    public GameObject Light;
    public GameObject Sun;
    public GameObject Moon;

    private bool NotMoney;

    public bool Night = false; //밤일경우에만 타워가 설치가능해야함
    private bool Drag = false;

    void start()
    {
        NotMoney = false;
        Sun.SetActive(false);
        Moon.SetActive(false);
    }


    void Update()
    {
        CehckNight();
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
        MoveLimit();

    }

   void check()
   {
       RaycastHit hit = new RaycastHit();

       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       if(Input.GetMouseButtonDown(0))
       { 
           if (Physics.Raycast(ray, out hit))
           {
               if (Night == false)
                    return;
               if (hit.collider.tag == "Tower1")
               {
                   if (Manager.GetComponent<GameManger>().CheckGold(150) != false)
                   {
                       tower1 = true;
                       tower2 = false;
                       tower3 = false;
                   }
                   else
                   {
                       NotEnoughMoney.SetActive(true);
                       NotMoney = true;
                       if (NotMoney == true)
                       {
                           Invoke("CheckSet", 1);
                       }
                   }
               }

               if(hit.collider.tag == "Tower2")
               {
                   if(Manager.GetComponent<GameManger>().CheckGold(100) != false)
                   {
                       tower1 = false;
                       tower2 = true;
                       tower3 = false;
                   }
                   else
                   {
                       NotEnoughMoney.SetActive(true);
                       NotMoney = true;
                       if(NotMoney == true)
                       {
                           Invoke("CheckSet", 1);
                       }
                   }
               }
           
               if(hit.collider.tag == "Tower3")
               {
                   if(Manager.GetComponent<GameManger>().CheckGold(200) != false)
                   {
                       tower1 = false;
                       tower2 = false;
                       tower3 = true;
                   }
                   else
                   {
                       NotEnoughMoney.SetActive(true);
                       NotMoney = true;
                       if (NotMoney == true)
                       {
                           Invoke("CheckSet", 1);
                       }
                   }
               }
               if(hit.collider.tag == "Ground" && hit.collider.gameObject.GetComponent<GroundScript>().build == false)
               {
                   if(tower1 == true)
                   {
                       Manager.GetComponent<GameManger>().UseGold(150);
                       Instantiate(TowerObject1, hit.transform.position, Quaternion.identity);
                       hit.collider.gameObject.GetComponent<GroundScript>().build = true;
                       tower1 = false;
                   }
                   
                   else if(tower2 == true)
                   {
                       Manager.GetComponent<GameManger>().UseGold(100);
                       Instantiate(TowerObject2, hit.transform.position, Quaternion.identity);
                       hit.collider.gameObject.GetComponent<GroundScript>().build = true;
                       tower2 = false;
                   }

                   else if(tower3 == true)
                   {
                       Manager.GetComponent<GameManger>().UseGold(200);
                       Instantiate(TowerObject3, hit.transform.position, Quaternion.identity);
                       hit.collider.gameObject.GetComponent<GroundScript>().build = true;
                       tower3 = false;
                   }
               }          
           }
       }
   }
    
   void CehckNight()
   {
       if (Night == false)
       {
           Moon.SetActive(false);
           Sun.SetActive(true);
           Light.GetComponent<Light>().color = Color.white;
       }

       else
       {
           Moon.SetActive(true);
           Sun.SetActive(false);
           Light.GetComponent<Light>().color = Color.gray;
       }
   }

   void CheckSet()
   {
       NotMoney = false;
       NotEnoughMoney.SetActive(false);
   }

   void MoveLimit()
   {
       Vector3 temp;
       temp.x = Mathf.Clamp(transform.position.x, 0, 10);
       temp.y = Mathf.Clamp(transform.position.y, 0, 7);
       temp.z = Mathf.Clamp(transform.position.z, -10, -10);

       transform.position = temp;
   }
}
