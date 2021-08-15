using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject restartPanel;

    public static int enemiesToDefeat;
    public static int spawnedEnemy = 0;
    public static int[] EnemyToBeSpawned = new int[100];
    public static int vaweCounter = 0;

    public GameObject UpgradePanel;

    bool preperationPeriod = false;
    bool bossVawe = false;
    bool control = false;

    public GameObject[] enemy_2Spawners;

    public static bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        LoadSavedData();
        //ResetData();
       
    }

    void ResetData()
    {
        PlayerPrefs.SetInt("vaweCounter", 0);
    }
    void LoadSavedData()
    {
        if (PlayerPrefs.GetInt("vaweCounter") > 0)
        {
            vaweCounter = PlayerPrefs.GetInt("vaweCounter");
        }
    }


    // Update is called once per frame
    void Update()
    {
        SetVawes();
        //SetPreperationPeriod();

        if (control == false)
        {
            enemiesToDefeat = EnemyToBeSpawned[vaweCounter];
            Debug.Log("EnemiesToDefeat = " + enemiesToDefeat);
            control = true;
        }

        if (Castle.currentCastleHitPoints <= 0)
        {
            restartPanel.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Kaybettin");
        }

        if (enemiesToDefeat <= 0)
        {
            Debug.Log("Wave Cleared !");
            vaweCounter++;
            PlayerPrefs.SetInt("vaweCounter", vaweCounter);
            control = false;
            preperationPeriod = true;
            SetPreperationPeriod();
            ManageVawes();
          
        }

        for (int i = 0; i < 2; i++)
        {
            if (i == 0)
            {
                if (vaweCounter > 5)
                {
                    enemy_2Spawners[i].SetActive(true);
                }
            }
            else
            {
                if (vaweCounter > 10)
                {
                    enemy_2Spawners[i].SetActive(true);
                }
              
            }
        }





    }

    void SetPreperationPeriod()
    {
     
            Time.timeScale = 0f;
            ShowUpgradePanel();
            

    }

    public void ShowUpgradePanel()
    {
        UpgradePanel.SetActive(true);
        
    }

    public void CloseUpgradePanel()
    {
        UpgradePanel.SetActive(false);
        Time.timeScale = 1f;
    }


    void SetVawes()
    {
        for (int i = 0; i < EnemyToBeSpawned.Length; i++)
        {

            if (i == 0)
            {
                EnemyToBeSpawned[i] = 10;

              
            }

            else 
            {
                EnemyToBeSpawned[i] = (EnemyToBeSpawned[i - 1] + 5);
                
            }

        }
        
    }

        
    

    void ManageVawes()
    {

        /*if (vaweCounter % 10 == 0)
        {
            bossVawe = true;
        }*/

        if (EnemySpawner.spawnRate >= 1f)
        {
            EnemySpawner.spawnRate = EnemySpawner.spawnRate - 0.5f;
            PlayerPrefs.SetFloat("spawnRate", EnemySpawner.spawnRate);
        }
        else
        {
            EnemySpawner.spawnRate = 1f;
        }
        Castle.currentCastleHitPoints = Castle.castleHitPoints;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in enemies)
        {
            GameObject.Destroy(Enemy);
        }
    }





    

}
