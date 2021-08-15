using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public static int PlayerInGameMoney = 0;


     int[] wallUpgradeCosts = new int[10];
     int[] wallUpgradeValues = new int[10];

     int[] FireSpeedUpgradeCosts = new int[10];
     float[] FireSpeedUpgradeValues = new float[10];

     int[] FireRateUpgradeCosts = new int[10];
     float[] FireRateUpgradeValues = new float[10];

     int[] DamageUpgradeCosts = new int[10];
     float[] DamageUpgradeValues = new float[10];

     int[] catapultUpgradeCosts = new int[4];
     bool[] isCatapultsUpgraded = new bool[4];

     int[] catapultFireRateUpgradeCosts = new int[10];
     float[] catapultFireRateUpgradeValues = new float[10];

    [Header("Text Objects")]
    public Text wallUpgradeCostText;
    public Text fireSpeedUpgradeCostText;
    public Text fireRateUpgradeCostText;
    public Text damageUpgradeCostText;
    public Text catapultCostsText;
    public Text catapultFireRateCostsText;


    [Header("Catapults")]
    public GameObject[] catapults;

    [Header("Catapult Fire Rate Upgrade")]
    public GameObject catapultFireRateUpgradeLine;


    int currentWallUpgrade = 0;
    int currentFireSpeedUpgrade = 0;
    int currentFireRateUpgrade = 0;
    int currentDamageUpgrade = 0;
    int currentCatapultFireRate = 0;

    bool isAnyCatapultUpgraded = false;

    // Start is called before the first frame update
    void Start()
    {
        
        SetWallUpgradeCostsAndValues();
        SetFireSpeedUpgradeCostsAndValues();
        SetFireRateUpgradeCostsAndValues();
        SetCatapultCostsAndValues();
        SetCatapultFireRateCosts();
        LoadSavedData();
        
    }

    void ResetSavedData()
    {
        PlayerPrefs.SetInt("playerInGameMoney", 0);
        PlayerPrefs.SetInt("savedCurrentWallUpgrade", 0);
        PlayerPrefs.SetInt("savedCurrentFireSpeedUpgrade", 0);
        PlayerPrefs.SetInt("savedCurrentFireRateUpgrade", 0);
        PlayerPrefs.SetInt("savedCurrentDamageUpgrade", 0);
        PlayerPrefs.SetInt("savedCurrentCatapultFireRate", 0);
        PlayerPrefs.SetInt("isAnyCatapultUpgraded", 0);

        PlayerPrefs.SetInt("WallStrenght", 0);
        PlayerPrefs.SetFloat("fireSpeed", 0);
        PlayerPrefs.SetFloat("fireRate", 0);
        PlayerPrefs.SetFloat("catapultFireRate", 0);
        for (int i = 0; i < 4; i++)
        {
            PlayerPrefs.SetInt("Catapult" + i.ToString(), 0);  
        }
    }
    void LoadSavedData()
    {
        if (PlayerPrefs.GetInt("playerInGameMoney") >0)
        {
         PlayerInGameMoney = PlayerPrefs.GetInt("playerInGameMoney");
        }
     
        currentWallUpgrade = PlayerPrefs.GetInt("savedCurrentWallUpgrade");
        currentFireSpeedUpgrade = PlayerPrefs.GetInt("savedCurrentFireSpeedUpgrade");
        currentFireRateUpgrade = PlayerPrefs.GetInt("savedCurrentFireRateUpgrade");
        currentDamageUpgrade = PlayerPrefs.GetInt("savedCurrentDamageUpgrade");
        currentCatapultFireRate = PlayerPrefs.GetInt("savedCurrentCatapultFireRate");

        if (PlayerPrefs.GetInt("isAnyCatapultUpgraded") == 0)
        {
            isAnyCatapultUpgraded = false;
        }

        else if(PlayerPrefs.GetInt("isAnyCatapultUpgraded") == 1)
        {
            isAnyCatapultUpgraded = true;
        }

        //Stats
        if (PlayerPrefs.GetInt("WallStrenght") != 0)
        {
            Castle.castleHitPoints = PlayerPrefs.GetInt("WallStrenght");
        }
        if (PlayerPrefs.GetFloat("fireSpeed") != 0) 
        {
            Player.startTimeBtwShots = PlayerPrefs.GetFloat("fireSpeed"); 
        }

        if (PlayerPrefs.GetFloat("fireRate") != 0)
        {
            BulletController.speed = PlayerPrefs.GetFloat("fireRate");
        }

        if (PlayerPrefs.GetFloat("catapultFireRate") != 0)
        {
            Turret.fireRate = PlayerPrefs.GetFloat("catapultFireRate");
        }

        for (int i = 0; i < 4; i++)
        {
            if (PlayerPrefs.GetInt("Catapult"+i.ToString()) == 1)
            {
                catapults[i].SetActive(true);
                isCatapultsUpgraded[i] = true;
                isAnyCatapultUpgraded = true;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        SetCostTextValues();

        for (int i = 0; i < isCatapultsUpgraded.Length; i++)
        {
            if (isCatapultsUpgraded[i] == true)
            {
                isAnyCatapultUpgraded = true;
                break;
            }
        }

        if (isAnyCatapultUpgraded == true)
        {
            catapultFireRateUpgradeLine.SetActive(true);
        }
    }

    void SetWallUpgradeCostsAndValues()
    {
        for (int i = 0; i < wallUpgradeCosts.Length; i++)
        {
            if (i == 0)
            {
                wallUpgradeCosts[i] = 100;
            }
            else
            {
                wallUpgradeCosts[i] = ((wallUpgradeCosts[i - 1] * 3) / 2);
            }
            
        }

        for (int i = 0; i < wallUpgradeValues.Length; i++)
        {
            if (i == 0 )
            {
                wallUpgradeValues[i] = 50;
            }

            else
            {
                wallUpgradeValues[i] = wallUpgradeValues[i - 1] + 50; 
            }
        }

    }


    void SetFireSpeedUpgradeCostsAndValues()
    {
        for (int i = 0; i < FireSpeedUpgradeCosts.Length; i++)
        {
            if (i == 0)
            {
                FireSpeedUpgradeCosts[i] = 100;
            }
            else
            {
                FireSpeedUpgradeCosts[i] = ((FireSpeedUpgradeCosts[i - 1] * 3) / 2);
            }
        }

        for (int i = 0; i < FireSpeedUpgradeValues.Length; i++)
        {
           
                FireSpeedUpgradeValues[i] = -0.1f;
            
          
        }
    }

    void SetFireRateUpgradeCostsAndValues()
    {
        for (int i = 0; i < FireRateUpgradeCosts.Length; i++)
        {
            if (i == 0)
            {
                FireRateUpgradeCosts[i] = 100;
            }

            else
            {
                FireRateUpgradeCosts[i] = ((FireRateUpgradeCosts[i - 1] * 3) / 2); 
            }
        }

        for (int i = 0; i < FireRateUpgradeValues.Length; i++)
        {
            if (i == 0)
            {
                FireRateUpgradeValues[i] = 6;
            }

            else
            {
                FireRateUpgradeValues[i] = FireRateUpgradeValues[i - 1] + 1;
            }
        }
    }

   void SetDamageUpgradeCostsAndValues()
    {
        for (int i = 0; i < DamageUpgradeCosts.Length; i++)
        {
            if (i == 0)
            {
                DamageUpgradeCosts[i] = 100;
            }
            else
            {
                DamageUpgradeCosts[i] = (DamageUpgradeCosts[i - 1] * 3) / 2;
            }
        }

        for (int i = 0; i < DamageUpgradeValues.Length; i++)
        {
            if (i == 0)
            {
                DamageUpgradeValues[i] = 10;
            }

            else
            {
                DamageUpgradeValues[i] = (DamageUpgradeValues[i - 1] + 5);
            }
        }
   }

    void SetCatapultCostsAndValues()
    {
        for (int i = 0; i < catapultUpgradeCosts.Length; i++)
        {
            if (i == 0)
            {
                catapultUpgradeCosts[i] = 5000;
            }

            else
            {
                catapultUpgradeCosts[i] = (catapultUpgradeCosts[i - 1] * 3) / 2;
            }
            
        }

        for (int i = 0; i < catapultFireRateUpgradeValues.Length; i++)
        {
                catapultFireRateUpgradeValues[i] = 0.1f;
        }
    }

    void SetCatapultFireRateCosts()
    {
        for (int i = 0; i < catapultFireRateUpgradeCosts.Length; i++)
        {
            if (i == 0)
            {
                catapultFireRateUpgradeCosts[i] = 300;
            }
            else
            {
                catapultFireRateUpgradeCosts[i] = (catapultFireRateUpgradeCosts[i - 1] * 3 / 2);
            }
        }
    }

    void SetCostTextValues()
    {
        if (currentWallUpgrade <10)
        {
            wallUpgradeCostText.text = wallUpgradeCosts[currentWallUpgrade].ToString();
            
        }

        else
        {
            wallUpgradeCostText.text = "MAX";
        }

        if (currentFireSpeedUpgrade < 10)
        {
            fireSpeedUpgradeCostText.text = FireSpeedUpgradeCosts[currentFireSpeedUpgrade].ToString();
        }

        else
        {
            fireSpeedUpgradeCostText.text = "MAX";
        }

        if (currentFireRateUpgrade < 10)
        {
            fireRateUpgradeCostText.text = FireRateUpgradeCosts[currentFireRateUpgrade].ToString();
        }
        else
        {
            fireRateUpgradeCostText.text = "MAX";
        }

        if (currentDamageUpgrade < 10)
        {
            damageUpgradeCostText.text = DamageUpgradeCosts[currentDamageUpgrade].ToString();
        }

        else
        {
            damageUpgradeCostText.text = "MAX";
        }

        CatapultCostsText();

        if (currentCatapultFireRate < 10)
        {
            catapultFireRateCostsText.text = catapultFireRateUpgradeCosts[currentCatapultFireRate].ToString();
        }
        else
        {
            catapultFireRateCostsText.text = "MAX";
            
        }
      
        
       

    }


    void CatapultCostsText()
    {
        catapultCostsText.text = "";

        for (int i = 0; i < isCatapultsUpgraded.Length; i++)
        {
            if (isCatapultsUpgraded[i] == false)
            {
                catapultCostsText.text += catapultUpgradeCosts[i] + "/";
            }
            else
            {
                catapultCostsText.text += "MAX" + "/";
            }
            
        }
    }
    

    


    public void UpgradeWallStrenght()
    {
        if(PlayerInGameMoney >= wallUpgradeCosts[currentWallUpgrade] && currentWallUpgrade < 10)
        {
            PlayerInGameMoney -= wallUpgradeCosts[currentWallUpgrade];
            PlayerPrefs.SetInt("playerInGameMoney", PlayerInGameMoney);
            Castle.castleHitPoints += wallUpgradeValues[currentWallUpgrade];
            Castle.UpdateCastleUpgrades();
            PlayerPrefs.SetInt("WallStrenght", Castle.castleHitPoints);
            currentWallUpgrade++;
            PlayerPrefs.SetInt("savedCurrentWallUpgrade", currentWallUpgrade);

        }
    }

    public void FireSpeedUpgrade()
    {
        if (PlayerInGameMoney >= FireSpeedUpgradeCosts[currentFireSpeedUpgrade] && currentFireSpeedUpgrade < 10)
        {
            PlayerInGameMoney -= FireSpeedUpgradeCosts[currentFireSpeedUpgrade];
            PlayerPrefs.SetInt("playerInGameMoney", PlayerInGameMoney);
            Player.startTimeBtwShots = Player.startTimeBtwShots + FireSpeedUpgradeValues[currentFireSpeedUpgrade];
            PlayerPrefs.SetFloat("fireSpeed", Player.startTimeBtwShots);
            currentFireSpeedUpgrade++;
            PlayerPrefs.SetInt("savedCurrentFireSpeedUpgrade", currentFireSpeedUpgrade);
        }
    }

    public void FireRateUpgrade()
    {
        if (PlayerInGameMoney >= FireRateUpgradeCosts[currentFireRateUpgrade] && currentFireRateUpgrade < 10)
        {
            PlayerInGameMoney -= FireRateUpgradeCosts[currentFireRateUpgrade];
            BulletController.speed = FireRateUpgradeValues[currentFireRateUpgrade];
            PlayerPrefs.SetFloat("fireRate", BulletController.speed);
            currentFireRateUpgrade++;
            PlayerPrefs.SetInt("savedCurrentFireRateUpgrade", currentFireRateUpgrade);
        }
    }

    public void DamageUpgrade()
    {
        if (PlayerInGameMoney >= DamageUpgradeCosts[currentDamageUpgrade] && currentDamageUpgrade < 10)
        {
            PlayerInGameMoney -= DamageUpgradeCosts[currentDamageUpgrade];
            PlayerPrefs.SetInt("playerInGameMoney", PlayerInGameMoney);
            currentDamageUpgrade++;
            PlayerPrefs.SetInt("savedCurrentDamageUpgrade", currentDamageUpgrade);
        }
    }

    public void CatapultUpgrade(int catapultNumber)
    {
        if (PlayerInGameMoney >= catapultUpgradeCosts[catapultNumber] && isCatapultsUpgraded[catapultNumber] == false)
        {

            PlayerInGameMoney -= catapultUpgradeCosts[catapultNumber];
            PlayerPrefs.SetInt("playerInGameMoney", PlayerInGameMoney);
            catapults[catapultNumber].SetActive(true);
            PlayerPrefs.SetInt("Catapult" + catapultNumber.ToString(), 1);
            isCatapultsUpgraded[catapultNumber] = true;

        }

    }
    public void CatapultFireRateUpgrade()
    {
        if (PlayerInGameMoney >= catapultFireRateUpgradeCosts[currentCatapultFireRate] && isAnyCatapultUpgraded == true && currentCatapultFireRate < 10)
        {
            PlayerInGameMoney -= catapultFireRateUpgradeCosts[currentCatapultFireRate];
            PlayerPrefs.SetInt("playerInGameMoney", PlayerInGameMoney);
            Turret.fireRate += catapultFireRateUpgradeValues[currentCatapultFireRate];
            PlayerPrefs.SetFloat("catapultFireRate", Turret.fireRate);
            currentCatapultFireRate++;
            PlayerPrefs.SetInt("savedCurrentCatapultFireRate", currentCatapultFireRate);
        }
    }
}
