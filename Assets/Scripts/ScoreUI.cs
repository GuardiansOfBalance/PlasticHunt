using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text scoreTxt;

    void Start()
    {
        scoreTxt.text = "0";
    }

    void Update()
    {
        scoreTxt.text = ScoreManager.Instance.numberOfCollectedTrashGrams.ToString();
    }
}
