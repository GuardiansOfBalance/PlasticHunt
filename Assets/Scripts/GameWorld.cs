using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorld : MonoBehaviour
{
    #region Singleton
    private static GameWorld _instance;
    public static GameWorld Instance { get { return _instance; } }
    #endregion
    public GameObject gameUI;

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
        MenuManager.Instance.tapToPlaceAR.SetActive(false);
        GameManager.Instance.arPlaced = true;
        transform.SetAsLastSibling();
    }
    void OnEnable()
    {
        FindObjectOfType<PlaceOnPlane>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void ShowGameUI()
    {
        MenuManager.Instance.tapToPlaceAR.SetActive(false);
        gameUI.SetActive(true);
    }

    public void HideGameUI()
    {
        MenuManager.Instance.tapToPlaceAR.SetActive(false);
        gameUI.SetActive(false);
    }
}
