using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{
    private int pointCoin = 0;
    public TextMeshProUGUI pointText;
    public GameObject gameOverUi;
    public GameObject gameWinUi;
    public GameObject MenuUi;
    private bool isGameOver = false;
    private bool isGameWin = false;
     private bool isPaused = false;
    public static GameManager Instance;
    

    void Awake()
    {
         if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdatePoint();
        gameOverUi.SetActive(false);
        gameWinUi.SetActive(false);
        MenuUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoin(int point)
    {
        if(!isGameOver  && !isGameWin)
        {
        pointCoin += point;
        UpdatePoint();    
        }
        
    }

    public void UpdatePoint()
    {
        pointText.text = pointCoin.ToString();
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        pointCoin = 0;
        gameOverUi.SetActive(true);
    }

    public void GameWin()
    {
        isGameWin = true;
        Time.timeScale = 0;
        gameWinUi.SetActive(true);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        isGameOver = false;
        Time.timeScale = 1;
        pointCoin = 0;
        UpdatePoint();
        SceneManager.LoadScene("Game");
    }

    public bool IsGameOver()
    {
        return isGameOver;
    } 

    public bool IsGameWin()
    {
        return isGameWin;
    }

    public void Menu()
    {
        Time.timeScale = 0;
        MenuUi.SetActive(true);
        
    }

    

    public void TogglePause()
    {
        isPaused = !isPaused;

        MenuUi.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
