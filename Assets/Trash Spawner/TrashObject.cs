using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TrashObject : MonoBehaviour
{
    [SerializeField] float itemWeight;
    bool collected;
    AudioSource collectedEffectAS;

    void Start()
    {
        collected = false;
        collectedEffectAS = GetComponent<AudioSource>();
    }

    void Update()
    {


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
        collectedEffectAS.Play();
        yield return new WaitForSeconds(0.2f);
        while (timeElapsed < 0.2)
        {
            transform.position = Vector3.Lerp(gameObject.transform.position, Camera.main.transform.position, timeElapsed / 0.2f);
            timeElapsed += Time.deltaTime;
            if (timeElapsed > 0.15f)
            {
                Destroy(gameObject);
            }
            yield return null;
        }
        transform.position = Camera.main.transform.position;
    }
}
