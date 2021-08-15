using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
   
    AudioSource EnDeath;
    public static float speed = 5f;
    public Rigidbody2D bulletPhysics;
    // Start is called before the first frame update
    void Start()
    {
        EnDeath = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        moveBullet();
    }

    void moveBullet()
    {
        bulletPhysics.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            
           EnDeath.Play();    
            Destroy(other.gameObject);
            GameManager.enemiesToDefeat--;
            Upgrades.PlayerInGameMoney += 20;
            PlayerPrefs.SetInt("playerInGameMoney", Upgrades.PlayerInGameMoney);
        }

        if (other.tag != "SolidObjects" &&  other.tag != "Castle")
        {
            Destroy(gameObject);
        }
        
       
    }
}
