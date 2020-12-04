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

    [SerializeField] GameObject comingSoonImg;
    [SerializeField] GameObject alternativesImg;
    [SerializeField] AudioSource btnClkAS;

    public GameObject tapToPlaceAR;

    bool gameIsPaused;
    bool gameStarted;
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
        gameIsPaused = true;
        gameStarted = false;

        playBtn.onClick.AddListener(StartGame);
        donateBtn.onClick.AddListener(DonateBtnClk);
        reportIncidentBtn.onClick.AddListener(ReportIncidentBtnClk);
        alternativeSolutionsBtn.onClick.AddListener(AlternativeSolutionsBtnClk);

        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused && gameStarted && currentPopup == null)
        {
            ResumeGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !gameIsPaused)
        {
            PauseGame();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && gameIsPaused && currentPopup != null)
        {
            currentPopup.gameObject.SetActive(false);
            currentPopup = null;
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
        tapToPlaceAR.SetActive(true);
        btnClkAS.Play();
    }

    void DonateBtnClk()
    {
        comingSoonImg.SetActive(true);
        currentPopup = comingSoonImg;
        btnClkAS.Play();
    }

    void ReportIncidentBtnClk()
    {
        comingSoonImg.SetActive(true);
        currentPopup = comingSoonImg;
        btnClkAS.Play();
    }

    void AlternativeSolutionsBtnClk()
    {
        alternativesImg.SetActive(true);
        currentPopup = alternativesImg;
        btnClkAS.Play();
    }
}
