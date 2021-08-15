using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DefeatedEnemies : MonoBehaviour
{
    Text text;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowDefeatedEnemies();
        
    }

    void ShowDefeatedEnemies()
    {
        text.text = GameManager.enemiesToDefeat + "/" + GameManager.EnemyToBeSpawned[GameManager.vaweCounter]; 
    }
}
