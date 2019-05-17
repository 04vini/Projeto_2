using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float vel = 6, velRot = 10;
 
    private Animator heroiAnim;
    public float stamina = 100, maxStamina = 100;
    public KeyCode dash;
    public Image staminaBar;
    float countdown = 1.0f;
    bool countdownActive;
    bool countdownActivePunch;
    float countdownPunch = 0.5f;
    public GameObject PunchHand;
    bool stateDodge;
    public float moveX, moveY, RunX;
    private void Start()
    {
        heroiAnim = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        //movimentaçao
        moveY = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");
        heroiAnim.SetFloat("X", moveX, 0.1f, Time.deltaTime);
        heroiAnim.SetFloat("Y", moveY, 0.1f, Time.deltaTime);
      
        
        //float rot = Input.GetAxis("Horizontal") * velRot;
         //colocar na camera
        float rotPerson = Input.GetAxis("Mouse X") * velRot;
        float Dodge = Input.GetAxis("Dodge");
        float Run = Input.GetAxis("Run") * vel * 5;
        

        staminaBar.fillAmount = stamina / maxStamina;
        
        if (stamina >= maxStamina) {
            stamina = maxStamina;
        }
        if (stamina <= 0) {
            stamina = 0;
        }
       

        
        //rot *= Time.deltaTime;
        Dodge *= Time.deltaTime;
        Run *= Time.deltaTime;
        //colocar na cam
        //transform.Rotate(0, rotPerson * Time.deltaTime, 0);
        
       
        //dodge
        if (Input.GetKeyDown(dash) && stamina >= 20 && countdownActive == false)
        {
            heroiAnim.SetBool("Dodge", true);
            stamina -= 20;
            countdownActive = true;
         
        }
        if (countdownActive)
        {
            countdown -= Time.deltaTime;

        }

        if (countdown < 0) {
       
            heroiAnim.SetBool("Dodge", false);
            countdownActive = false;
            countdown = 1.0f;
        }
        //corrida
        if (Run != 0 && stamina > 0) {
          
            heroiAnim.SetBool("Run", true);
            
            if (!countdownActive)
            {
                stamina -= Time.deltaTime * 10;
            }
        }
    
        else
        {
            heroiAnim.SetBool("Run", false);
            stamina += Time.deltaTime * 10;
        }
        //soco
        if (Input.GetMouseButtonDown(0) && stamina >= 20)
        {
            heroiAnim.SetBool("Punch", true);
            stamina -= 20;
            countdownActivePunch = true;
            PunchHand.SetActive(true);
        }
        if (countdownActivePunch)
        {
            countdownPunch -= Time.deltaTime;
        }

        if (countdownPunch < 0)
        {

            heroiAnim.SetBool("Punch", false);
            countdownActivePunch = false;
            countdownPunch = 0.5f;
            PunchHand.SetActive(false);
        }
    }

 
}
