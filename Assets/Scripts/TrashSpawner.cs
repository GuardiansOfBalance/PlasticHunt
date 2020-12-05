using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    #region Singleton
    private static TrashSpawner _instance;
    public static TrashSpawner Instance { get { return _instance; } }
    #endregion

    public GameObject[] trashPrefabs;
    public GameObject yOrigin;
    public bool canSpawn;
    public float timeBetweenEachSpawn;
    GameObject mainCam;
    public int offsetFromCamRange;
    public int currentDragValue;

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
        currentDragValue = 8;
        canSpawn = true;
        mainCam = Camera.main.gameObject;
        // Vector3 random = new Vector3(Random.Range(mainCam.transform.position.x, 3), , Random.Range(mainCam.transform.position.z, 3));
        StartCoroutine(TrashSpawnerCoroutine(timeBetweenEachSpawn));
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(currentDragValue);
    }

    IEnumerator TrashSpawnerCoroutine(float timeBetweenEachSpawn)
    {
        while (canSpawn)
        {
            int randomizerValue = Randomizer();
            GameObject currentTrashItem = Instantiate(trashPrefabs[Random.Range(0, trashPrefabs.Length)], new Vector3(Random.Range(mainCam.transform.position.x, randomizerValue), yOrigin.transform.position.y, Random.Range(mainCam.transform.position.z, randomizerValue)), Quaternion.identity);
            currentTrashItem.GetComponent<Rigidbody>().drag = currentDragValue;
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
