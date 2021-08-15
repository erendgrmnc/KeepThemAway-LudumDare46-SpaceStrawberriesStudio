using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowGold : MonoBehaviour
{
    Text goldText;


    // Start is called before the first frame update
    void Start()
    {
        goldText = GetComponent<Text>();

        if (PlayerPrefs.GetInt("playerInGameMoney") > 0)
        {
            Upgrades.PlayerInGameMoney = PlayerPrefs.GetInt("playerInGameMoney");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShowGoldText();
    }

    void ShowGoldText()
    {
        
        goldText.text = Upgrades.PlayerInGameMoney.ToString();
    }
}
