using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MenuManager.Instance.tapToPlaceAR.SetActive(false);
    }
    void OnEnable()
    {
        FindObjectOfType<PlaceOnPlane>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
