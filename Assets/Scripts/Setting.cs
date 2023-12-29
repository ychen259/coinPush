using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : singleTon<Setting> {

    public GameObject inGameMenu;
    public GameObject optionsMenu;
    private bool inMenu = false;

    private int coins;

    public int Coins
    {
        get
        {

            coins = PlayerPrefs.GetInt("coins", 30);
            return coins;
        }

        set
        {
            coins = value;
            PlayerPrefs.SetInt("coins", coins);
        }
    }

    /*open the menu when click the setting button*/
    public void openSetting()
    {
        /*cannot click the setting button when win or gameover menu is visible*/
        if (!inMenu || inGameMenu.activeSelf || optionsMenu.activeSelf)
        {
            ShowIngameMenu();
        }
    }

    public void ShowIngameMenu()
    {
        if (optionsMenu.activeSelf)
        {
            ShowMain();
        }
        else
        {
            SoundManager.Instance.PlaySFX("PressButton");

            inGameMenu.SetActive(!inGameMenu.activeSelf);

            if (!inGameMenu.activeSelf)
            {
                Time.timeScale = 1; /*run the game*/
                inMenu = false;
            }
            else
            {
                Time.timeScale = 0; /*stop the game*/
                inMenu = true;
            }
        }
    }

    public void ShowMain()
    {
        SoundManager.Instance.PlaySFX("PressButton");

        inGameMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void ShowOptions()
    {
        SoundManager.Instance.PlaySFX("PressButton");
        inGameMenu.SetActive(false);
        optionsMenu.SetActive(true);

    }

    /*quit from the game*/
    public void QuitGame()
    {
        SoundManager.Instance.PlaySFX("PressButton");
        StartCoroutine(waitForASecondInQuit());
    }

    IEnumerator waitForASecondInQuit()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }
}
