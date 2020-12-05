using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    #endregion
    public bool gameIsPaused;
    public bool gameStarted;
    public float gameTotalTime;
    public bool gameEnded;
    public bool arPlaced;

    void Awake()
    {
        #region Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        #endregion
    }

    void Start()
    {

    }
    void Update()
    {

    }

    public void EndGame()
    {
        MenuManager.Instance.HideGameMenu();
        gameEnded = true;
        Time.timeScale = 0;
        ScorePanel.Instance.ShowScorePanel();
    }

    public void RestartGame()
    {
        MenuManager.Instance.PlayBtnClkAudio();
        SceneManager.LoadScene("PlasticHunt");
    }
}
