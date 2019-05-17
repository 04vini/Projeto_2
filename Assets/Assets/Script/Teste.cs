using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    public int Health = 100;
    Animator npcAnim;
    public CapsuleCollider col;
    
    // Start is called before the first frame update
    void Start()
    {
        npcAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0) {
            Health = 0;
            npcAnim.SetBool("Death", true);
            col.enabled = false;
          }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Punch"))
        {
            npcAnim.SetTrigger("Hit");   
            Health -= 20;
            FindObjectOfType<PlayerControl>().PunchHand.SetActive(false);

        }
       
    }
}
