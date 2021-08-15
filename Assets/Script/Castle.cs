using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    
    public static int castleHitPoints = 100;
    public static int currentCastleHitPoints;
    


    // Start is called before the first frame update
    void Start()
    {
        
        currentCastleHitPoints = castleHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        //DestroyCastle();
    }


    void DestroyCastle()
    {
        
        if (castleHitPoints <= 0)
        {
            GameManager.gameOver = true;
            
            Debug.Log("Kale Yıkıldı");

        }
    }

    public static void UpdateCastleUpgrades()
    {
        currentCastleHitPoints = castleHitPoints;
    }

}
