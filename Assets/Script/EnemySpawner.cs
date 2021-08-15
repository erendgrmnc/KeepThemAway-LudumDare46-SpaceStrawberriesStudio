using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float positiveRange = 0, negativeRange = 0;
    

    public GameObject Enemy;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public static float spawnRate = 10f;
    float nextSpawn = 0f;

    public bool TopBot;

   

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
           
            

            if (TopBot == true)
            {
                randX = Random.Range(negativeRange, positiveRange);
                whereToSpawn = new Vector2(randX, transform.position.y);
                Instantiate(Enemy, whereToSpawn, Quaternion.identity);
                GameManager.spawnedEnemy++;
            }

            else
            {
                randY = Random.Range(negativeRange, positiveRange);
                whereToSpawn = new Vector2(transform.position.x, randY);
                Instantiate(Enemy, whereToSpawn, Quaternion.identity);
                GameManager.spawnedEnemy++;
            }
            
            
        }
      
    }
}
