using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock_on : MonoBehaviour
{
    private bool locked;
    Rigidbody rb;
    private GameObject enemy;
    public GameObject player;
    public GameObject cam;
    public Camera camerabase;
    public Camera cameracharacter;


    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {

        if (enemy == null){ acharplayer(); locked = false; }
        if (Input.GetKeyDown("p"))
        {
            if (enemy != null)
            {
                camerabase.enabled = !camerabase.enabled;
                cameracharacter.enabled = !cameracharacter.enabled;
                mov_cam.lockedON = !mov_cam.lockedON;
                locked = !locked;
            }
        }
            if (locked == true)
        {
            rotacionar();
        }
    }
    public void rotacionar() {
        player.transform.LookAt(enemy.transform.position);
        cam.transform.LookAt(enemy.transform.position);
    }
    public void acharplayer() {
        enemy = GameObject.FindGameObjectWithTag("enemy").gameObject;
    }
}
