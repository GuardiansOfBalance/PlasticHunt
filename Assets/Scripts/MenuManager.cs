using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject menuUI;
    [SerializeField] Button playBtn;
    [SerializeField] Button donateBtn;
    [SerializeField] Button reportIncidentBtn;
    [SerializeField] Button alternativeSolutionsBtn;
    [SerializeField] Button storeBtn;

    [SerializeField] GameObject comingSoonImg;
    [SerializeField] GameObject alternativesImg;
    [SerializeField] AudioSource btnClkAS;
    [SerializeField] GameObject storeImg;

    public GameObject tapToPlaceAR;


    GameObject currentPopup;
    #region Singleton
    private static MenuManager _instance;
    public static MenuManager Instance { get { return _instance; } }
    #endregion

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
        GameManager.Instance.gameIsPaused = true;
        GameManager.Instance.gameStarted = false;

        playBtn.onClick.AddListener(StartGame);
        donateBtn.onClick.AddListener(DonateBtnClk);
        reportIncidentBtn.onClick.AddListener(ReportIncidentBtnClk);
        alternativeSolutionsBtn.onClick.AddListener(AlternativeSolutionsBtnClk);
        storeBtn.onClick.AddListener(storeBtnClk);
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.gameIsPaused && GameManager.Instance.gameStarted && currentPopup == null)
        {
            ResumeGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.gameIsPaused && !GameManager.Instance.gameEnded)
        {
            PauseGame();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.gameIsPaused && currentPopup != null)
        {
            currentPopup.gameObject.SetActive(false);
            currentPopup = null;
        }

    }

    void PauseGame()
    {
        Time.timeScale = 0;
        menuUI.SetActive(true);
        GameManager.Instance.gameIsPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        menuUI.SetActive(false);
        GameManager.Instance.gameIsPaused = false;
    }

    void StartGame()
    {
        Time.timeScale = 1;
        menuUI.SetActive(false);
        GameManager.Instance.gameStarted = true;
        GameManager.Instance.gameIsPaused = false;
        tapToPlaceAR.SetActive(true);
        btnClkAS.Play();
    }

    void DonateBtnClk()
    {
        Time.timeScale = 0;
        comingSoonImg.SetActive(true);
        currentPopup = comingSoonImg;
        btnClkAS.Play();
    }

    void ReportIncidentBtnClk()
    {
        Time.timeScale = 0;
        comingSoonImg.SetActive(true);
        currentPopup = comingSoonImg;
        btnClkAS.Play();
    }

    void AlternativeSolutionsBtnClk()
    {
        Time.timeScale = 0;
        alternativesImg.SetActive(true);
        currentPopup = alternativesImg;
        btnClkAS.Play();
    }

    void storeBtnClk()
    {
        Time.timeScale = 0;
        storeImg.SetActive(true);
        btnClkAS.Play();
        currentPopup = storeImg;
    }

    public void PlayBtnClkAudio()
    {
        btnClkAS.Play();

    }
    public void HideGameMenu()
    {
        menuUI.SetActive(false);
    }
}
