using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour
{
    [SerializeField] float itemWeight;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        ScoreManager.Instance.AddToScore(itemWeight);
        Destroy(gameObject);
    }
}
