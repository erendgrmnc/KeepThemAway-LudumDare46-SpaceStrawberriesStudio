using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D physics;

    private Camera theCam;
    
    public Transform firePoint;
    public GameObject bulletToFire;
    AudioSource pshoot;
    private float timeBtwShots;
    public static float startTimeBtwShots  = 1f;

    void Start()
    {
        theCam = Camera.main;
        pshoot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        FaceMouseDirection();
        
        FireBullet();
        
    }

    void FaceMouseDirection()
    {
        Vector3 mouse = Input.mousePosition;

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void FireBullet()
    {
        if (timeBtwShots <=0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bulletToFire, firePoint.position, transform.rotation);
                pshoot.Play();
                timeBtwShots = startTimeBtwShots;
            }
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
      
    }
}
