using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GameTimer : MonoBehaviour
{
    #region Singleton
    private static GameTimer _instance;
    public static GameTimer Instance { get { return _instance; } }
    #endregion
    [SerializeField] Image gameTimerFillImg;
    [SerializeField] Text timerTxt;
    bool callGameEnd;
    float currentTime;

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
        currentTime = GameManager.Instance.gameTotalTime;
    }

    void Update()
    {
        if (gameTimerFillImg.fillAmount > 0 && GameManager.Instance.gameStarted)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= GameManager.Instance.gameTotalTime / 2 && currentTime > GameManager.Instance.gameTotalTime / 4)
            {
                TrashSpawner.Instance.currentDragValue = 4;
            }
            else if (currentTime <= GameManager.Instance.gameTotalTime / 2 && currentTime <= GameManager.Instance.gameTotalTime / 4)
            {
                TrashSpawner.Instance.currentDragValue = 2;
            }
            gameTimerFillImg.fillAmount -= 1.0f / GameManager.Instance.gameTotalTime * Time.deltaTime;
            int seconds = (int)currentTime % (int)GameManager.Instance.gameTotalTime;
            timerTxt.text = seconds.ToString();
        }
        else if (gameTimerFillImg.fillAmount <= 0 && !callGameEnd)
        {
            GameManager.Instance.EndGame();
            callGameEnd = true;
        }
    }
}
