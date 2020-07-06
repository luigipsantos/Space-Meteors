using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text loseText;
    public Text rLvlTxt;
    public Button menuButton;
    public Button level2Button;

    public Image bar;
    public int health = 3;
    public int maxHealth = 3;
    private readonly int damage = 1;

    public Text ScoreText;
    private int score;

    public Player lazerActivator;
    public Text congratzs;

    void Start()
    {
        bar.fillAmount = 1f * health / maxHealth;

        ScoreText.text = "Score : 0";
    }

    void Update()
    {
        bar.fillAmount = 1f * health / maxHealth;

        ScoreText.text = "Score : " + score;

        if (health == 0f)
        {
            EndGame();
        }

        if (score == 15f)
        {
            lazerActivator.LazerActivator();

            congratzs.gameObject.SetActive(true);

            if(congratzs.gameObject != null)
            {
                Destroy(congratzs, 4.0f);
            }
            
        }
    }

    public void ScoreCounter()
    {
        score = score + 1;
    }

    public void LoseHealth()
    {
        health = health - damage;
    }

    private void EndGame()
    {
        loseText.gameObject.SetActive(true);
        rLvlTxt.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        level2Button.gameObject.SetActive(true);

        Time.timeScale = 0f;
    }
}
