using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{


    AudioSource EnAttack;
    public Player thePlayer;

    public int attackDamage = 1;

    public float move_speed = 4f;

    private float timeBtwAttacks = 0;
    public float startTimeBtwAttacks;

    private bool nearCastleWalls = false;

    void Start()
    {
        EnAttack = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();

        if (nearCastleWalls == true)
        {

        
        if (timeBtwAttacks <= 0)
        {
            HitCastle();
            timeBtwAttacks = startTimeBtwAttacks;
        }

        else
        {
            timeBtwAttacks -= Time.deltaTime;
        }

        }
    }


    void MoveEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, Time.deltaTime * move_speed);
        
    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Time.timeScale = 0f;
            Debug.Log("Kaybettin");
        }

        if (other.tag == "Castle")
        {
            nearCastleWalls = true;
            move_speed = 0f;
          
        }
        
    }


    void HitCastle()
    {
        Castle.currentCastleHitPoints -= attackDamage;
        EnAttack.Play();
        Debug.Log("Kale Hasar Aldı !");
    }
}


