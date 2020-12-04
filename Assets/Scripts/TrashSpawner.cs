using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] trashPrefabs;
    public GameObject yOrigin;
    public bool canSpawn;
    public float timeBetweenEachSpawn;
    GameObject mainCam;
    public int offsetFromCamRange;

    void Start()
    {
        canSpawn = true;
        mainCam = Camera.main.gameObject;
        // Vector3 random = new Vector3(Random.Range(mainCam.transform.position.x, 3), , Random.Range(mainCam.transform.position.z, 3));
        StartCoroutine(TrashSpawnerCoroutine(timeBetweenEachSpawn));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider != null)
                {

                    GameObject touchedObject = hit.transform.gameObject;

                    Debug.Log("Touched " + touchedObject.transform.name);
                }
            }
        }
    }
    IEnumerator TrashSpawnerCoroutine(float timeBetweenEachSpawn)
    {
        while (canSpawn)
        {
            int randomizerValue = Randomizer();
            Instantiate(trashPrefabs[Random.Range(0, trashPrefabs.Length)], new Vector3(Random.Range(mainCam.transform.position.x, randomizerValue), yOrigin.transform.position.y, Random.Range(mainCam.transform.position.z, randomizerValue)), Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenEachSpawn);

        }
        yield return null;
    }
    int Randomizer()
    {
        int randomValue = Random.Range(0, 2);
        if (randomValue == 0)
            return offsetFromCamRange;
        else
            return -offsetFromCamRange;
    }
}
