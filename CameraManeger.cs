using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CameraManeger : MonoBehaviour {
    private Vector3 Origin;
    private Vector3 Diference;

    private bool tower1;
    private bool tower2;
    private bool tower3;
    public GameObject Manager;
    public GameObject NotEnoughMoney;
    public GameObject EnemySpawn;

    public GameObject TowerObject1;
    public GameObject TowerObject2;
    public GameObject TowerObject3;
    public Text RootCoolTime;
    public Text DarkCoolTime;
    public Text GameClear;

    public GameObject Light;
    public GameObject Sun;
    public GameObject Moon;
    public GameObject Stop;
    public GameObject Home;
    public GameObject Resume;
    public GameObject Pause;
    private GameObject[] AllEnemy;

    private bool NotMoney;
    public bool Night; //밤일경우에만 타워가 설치가능해야함
    private bool Drag;
    private float R_Cooltime;
    private float D_CoolTime;
    private float D_SkiilTime;
    private bool D_Skiil;

    void start()
    {
        tower1 = false;
        tower2 = false;
        tower3 = false;
        NotMoney = false;
        Sun.SetActive(false);
        Moon.SetActive(false);
        R_Cooltime = 0;
        D_CoolTime = 0;
        D_SkiilTime = 0;
        D_Skiil = false;
        Night = false;
        Drag = false;
    }


    void Update()
    {
        CehckNight();
        check();
        CheckCoolTime();
        GUI();
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
               if (EnemySpawn.GetComponent<EnemySpawn>().End == true && EnemySpawn.GetComponent<EnemySpawn>().ALLENEMY.Length == 0)
               {
                   if (hit.collider.name == "BackHome")
                   {
                       SceneManager.LoadScene("GameMenu");
                   }
               }
               if(hit.collider.tag == "Stop")
               {
                   Stop.SetActive(false);
                   Resume.SetActive(true);
                   Pause.SetActive(true);
                   Time.timeScale = 0.0f;
               }
               if(hit.collider.tag == "Resume")
               {
                   Time.timeScale = 1.0f;
                   Stop.SetActive(true);
                   Pause.SetActive(false);
                   Resume.SetActive(false);
               }
               if(hit.collider.tag == "Home")
               {
                   Time.timeScale = 1.0f;
                   SceneManager.LoadScene("GameMenu");
               }
               if (hit.collider.tag == "Root")
               {                  
                   if (R_Cooltime == 0)
                   {
                       GameObject[] AllEnemy = GameObject.FindGameObjectsWithTag("Enemy");
                       for (int EnemyCount = 0; EnemyCount < AllEnemy.Length; EnemyCount++)
                       {
                           AllEnemy[EnemyCount].GetComponent<VehicleFollowing>().SetSlowBuff(0.5f);

                       }
                       R_Cooltime = 80;
                   }
               }
               if(hit.collider.tag == "Moon")
               {
                   if(D_CoolTime == 0 && Night == false)
                   {
                       Night = true;
                       D_Skiil = true;
                       D_CoolTime = 100;
                   }
               }
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

       if(D_Skiil == true)
       {
           D_SkiilTime += Time.deltaTime;
           if (Night == true && D_SkiilTime >= 7)
           {
               Night = false;
               D_Skiil = false;
               D_SkiilTime = 0;
           }
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
       temp.x = Mathf.Clamp(transform.position.x, -0.42f, 10.42f);
       temp.y = Mathf.Clamp(transform.position.y, 0.4f, 6.57f);
       temp.z = Mathf.Clamp(transform.position.z, -10, -10);

       transform.position = temp;
   }

    void CheckCoolTime()
   {
        if(R_Cooltime != 0)
        {
            R_Cooltime -= Time.deltaTime;
            if(R_Cooltime < 0)
            {
                R_Cooltime = 0;
            }
        }
        if(D_CoolTime != 0)
        {
            D_CoolTime -= Time.deltaTime;
            if(D_CoolTime <0)
            {
                R_Cooltime = 0;
            }
        }
   }

    private void GUI()
    {
        if(R_Cooltime == 0)
        {
            RootCoolTime.text = "On";
        }
        else
        {
            RootCoolTime.text = (int)R_Cooltime + "";
        }

        if(D_CoolTime == 0)
        {
            DarkCoolTime.text = "On";
        }
        else
        {
            DarkCoolTime.text = (int)D_CoolTime + "";
        }
    }
}
