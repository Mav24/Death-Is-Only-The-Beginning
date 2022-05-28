using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Score Board")]
    [SerializeField] int lives;
    [SerializeField] int score;
    
    [Header("UI Settings")]
    [SerializeField] UI ui;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausePanel;

    [Header("SFX ")]
    [SerializeField] SFX sfx;

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
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            
        }
        else
        {
            PlayerPrefs.SetInt("Lives", lives);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void PlayEnemyDeathParticles(Vector3 pos)
    {
        Instantiate(sfx.enemyHitSFX, pos, Quaternion.identity);
    }

    public void PlayPlayerHitParticles(Vector3 pos)
    {
        Instantiate(sfx.playerHitSFX, pos, Quaternion.identity);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }
    
    public void ReturnToGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
