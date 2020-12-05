using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour
{
    [SerializeField] float itemWeight;
    bool collected;
    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;
    void Start()
    {
        collected = false;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector3.Lerp(transform.position, Camera.main.transform.position, Time.deltaTime);
        if (collected)
        {

        }
            //    //transform.position = Vector3.Lerp(transform.position, Camera.main.transform.position, Time.deltaTime);
            //    //if (transform.position == Camera.main.transform.position)
            //    //{
            //    //    Debug.Log("t");
            //    //    collected = false;
            //    //}
            //    StartCoroutine(MoveToCamera());
            //    collected = false;
            //}

        }
    void OnMouseDown()
    {
        ScoreManager.Instance.AddToScore(itemWeight);
        collected = true;
        StartCoroutine(MoveToCamera());
    }
    IEnumerator MoveToCamera()
    {
        float timeElapsed = 0;

        while (timeElapsed < 0.2)
        {
            transform.position = Vector3.Lerp(gameObject.transform.position, Camera.main.transform.position, timeElapsed / 0.2f);
            timeElapsed += Time.deltaTime;
            if (timeElapsed > 0.1f)
                Destroy(gameObject);
            yield return null;
        }
        transform.position = Camera.main.transform.position;
    }
}
