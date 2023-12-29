using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : singleTon<Levels> {

    private int level;
    public float ExperienceNeed;
    private float currentExperience;

    public Image experienceBar;
    public Text levelText;

    public Transform coins;
    private Transform clone;

    public int Level
    {
        get
        {

            level = PlayerPrefs.GetInt("level", 1);
            return level;
        }

        set
        {
            level = value;
            PlayerPrefs.SetInt("level", level);
        }
    }

    public float CurrentExperience{
        get
        {

            currentExperience = PlayerPrefs.GetFloat("currentExperience", 0);
            return currentExperience;
        }

        set
        {
            currentExperience = value;
            PlayerPrefs.SetFloat("currentExperience", currentExperience);
        }
    }

    public void Awake()
    {
        ExperienceNeed = (Mathf.Pow(Level - 1, 3) + 60) / 5f * (Mathf.Pow(Level - 1, 2) + 60);
    }

    void Update () {
        experienceBar.fillAmount = CurrentExperience / ExperienceNeed;

        if (CurrentExperience >= ExperienceNeed)
        {
            LevelUp();
        }

        levelText.text = "LV\n" + Level;
    }

    public void LevelUp()
    {
        //((x-1)^3+60)/5*((x-1)*2+60)
        //lv1 720
        //lv2 744
        //lv3 870
        //lv4 1200
        //lv5 1884
        //lv6 3145
        //lv7 5299
        Level++;
        ExperienceNeed = (Mathf.Pow(Level - 1, 3) + 60) / 5f * (Mathf.Pow(Level - 1, 2) + 60);
        CurrentExperience = 0;

        Setting.Instance.Coins += 10;

        for (int i = 0; i < 5; i++)
        {
            clone = Instantiate(coins, new Vector3(Random.Range(-1.5f, 1.5f), 5, Random.Range(-9, -6)), Quaternion.identity);
            clone.GetChild(0).GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-1, 1), Random.Range(-1, -1), Random.Range(-7, -10));
        }

        SoundManager.Instance.PlaySFX("level-up");

        SoundManager.Instance.PlaySFX("bonus");


    }
}
