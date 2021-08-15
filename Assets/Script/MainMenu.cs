using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject UpgradeMenu;
    public GameObject closeButton;
    public GameObject goldText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            closeButton.SetActive(true);
            goldText.SetActive(true);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OpenUpgradeMenu()
    {
        UpgradeMenu.SetActive(true);
    }

    public void CloseUpgradeMenu()
    {
        UpgradeMenu.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
