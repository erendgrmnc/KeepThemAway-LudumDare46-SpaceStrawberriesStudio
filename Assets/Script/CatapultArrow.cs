using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultArrow : MonoBehaviour
{
    
    public static float speed = 5f;
    public Rigidbody2D bulletPhysics;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        moveBullet();
    }

    void moveBullet()
    {
        bulletPhysics.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            GameManager.enemiesToDefeat--;
            Upgrades.PlayerInGameMoney += 20;
        }

        if (other.tag != "SolidObjects" && other.tag != "Castle")
        {
            Destroy(gameObject);
        }


    }
}
