using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    AudioSource catapultfire;
    public Transform target;
    public float range = 5f;

    public Transform partToRotate;

    public string enemyTag = "Enemy";

    float rotationSpeed = 1f;


    public GameObject bulletPrefab;
    public Transform firePoint;
    public static float fireRate = 0.1f;
    private float fireCountDown = 0f;
        

    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        catapultfire = GetComponent<AudioSource>();
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector2 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        if (fireCountDown <= 0)
        {
            Fire();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;

    }

    void Fire()
    {

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        catapultfire.Play();
    }
}
