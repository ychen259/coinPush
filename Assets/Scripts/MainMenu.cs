using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject optionsMenu;
    public GameObject mainMenu;
    public GameObject ConfirmPanel;
    public Text continuteText;

    private bool CanContinue
    {
        get
        {
            return PlayerPrefs.HasKey("newGame");
        }
    }

    public void Update()
    {           
        handleContinueButton();
    }

    public void Options()
    {
        SoundManager.Instance.PlaySFX("PressButton");

        if (optionsMenu.activeSelf)
            {
                mainMenu.SetActive(true);
                optionsMenu.SetActive(false);

            }
            else
            {
                mainMenu.SetActive(false);
                optionsMenu.SetActive(true);
            }
    }

    public void Quit()
    {
        SoundManager.Instance.PlaySFX("PressButton");
        Application.Quit();
    }

    public void Continue()
    {
        SoundManager.Instance.PlaySFX("PressButton");
        StartCoroutine(waitForASecondInContinue());
    }

    IEnumerator waitForASecondInContinue()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Level-Configuration");
    }

    public void StartGame()
    {
        SoundManager.Instance.PlaySFX("PressButton");
        StartCoroutine(waitForASecondInStartGame());
    }

    IEnumerator waitForASecondInStartGame()
    {
        yield return new WaitForSeconds(0.1f);
        ConfirmPanel.SetActive(true);
    }

    public void yesInConfirmPanel()
    {
        SoundManager.Instance.PlaySFX("PressButton");
        StartCoroutine(waitForASecondInyes());
    }

    IEnumerator waitForASecondInyes()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt("newGame", 1);

        SceneManager.LoadScene("CoinPusherC#");
    }

    public void noInConfirmPanel()
    {
        SoundManager.Instance.PlaySFX("PressButton");
        StartCoroutine(waitForASecondInNo());
    }

    IEnumerator waitForASecondInNo()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        ConfirmPanel.SetActive(false);
    }

    public void ContinueGame()
    {
        if (CanContinue)
        {
            SoundManager.Instance.PlaySFX("PressButton");
        }
        else
        {
            SoundManager.Instance.PlaySFX("wrong");
        }

        StartCoroutine(waitForASecondInContinueGame());
    }

    IEnumerator waitForASecondInContinueGame()
    {
        yield return new WaitForSeconds(0.1f);

        if (CanContinue)
        {
            SceneManager.LoadScene("CoinPusherC#");
        }

    }

    public void handleContinueButton()
    {
        if (CanContinue)
        {
            continuteText.color = new Color32(51, 183, 255, 255);
        }
        else
        {
            continuteText.color = new Color32(16, 72, 98, 255);
        }
    }
}
