using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    public Text scoreTxt;
    #region Singleton
    private static ScorePanel _instance;
    public static ScorePanel Instance { get { return _instance; } }
    #endregion
    [SerializeField] Button restartBtn;
    [SerializeField] Button shareBtn;
    [SerializeField] GameObject scorePanelUI;

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
        restartBtn.onClick.AddListener(GameManager.Instance.RestartGame);
    }

    void Update()
    {

    }

    public void ShowScorePanel()
    {
        scorePanelUI.SetActive(true);
        scoreTxt.text = "You collected " + ScoreManager.Instance.numberOfCollectedTrashItems + " items & about " + ScoreManager.Instance.numberOfCollectedTrashGrams + " Grams of Plastic!";
    }
}
