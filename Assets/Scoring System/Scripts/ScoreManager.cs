using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    private static ScoreManager _instance;
    public static ScoreManager Instance { get { return _instance; } }
    #endregion
    public int numberOfCollectedTrashItems;
    public float numberOfCollectedTrashGrams;

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
        numberOfCollectedTrashItems = 0;
        numberOfCollectedTrashGrams = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore(float trashItemWeight)
    {
        numberOfCollectedTrashItems++;
        numberOfCollectedTrashGrams += trashItemWeight;
        Debug.Log(numberOfCollectedTrashItems);
        Debug.Log(numberOfCollectedTrashGrams);

    }
}
