using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] int lives;
    [SerializeField] int score;
    [SerializeField] UI ui;

    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        lives = PlayerPrefs.GetInt("Lives", 3);
        RefreshUI();
    }

    private void RefreshUI()
    {
        ui.score.text = $"Score: {score}";
        ui.lives.text = $"Lives: {lives}";
    }

    public void AddScore(int value)
    {
        score += value;
        ui.score.text = $"Score: {score}";
    }

    public void MinusScore(int value)
    {
        score -= value;

        if (score < 0)
        {
            CheckLives();
        }
        ui.score.text = $"Score: {score}";

    }

    public void CheckLives()
    {
        lives -= 1;

        if(lives < 0)
        {
            PlayerPrefs.DeleteAll();
            // Load main menu
            Debug.Log("End Game");
        }
        else
        {
            PlayerPrefs.SetInt("Lives", lives);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
