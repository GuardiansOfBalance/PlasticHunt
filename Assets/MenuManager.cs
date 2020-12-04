using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject menuUI;
    [SerializeField] Button playBtn;

    bool gameIsPaused;
    bool gameStarted;

    void Start()
    {
        gameIsPaused = true;
        gameStarted = false;
        playBtn.onClick.AddListener(StartGame);

        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused && gameStarted)
        {
            ResumeGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !gameIsPaused)
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        menuUI.SetActive(true);
        gameIsPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        menuUI.SetActive(false);
        gameIsPaused = false;
    }

    void StartGame()
    {
        Time.timeScale = 1;
        menuUI.SetActive(false);
        gameStarted = true;
        gameIsPaused = false;
    }
}
