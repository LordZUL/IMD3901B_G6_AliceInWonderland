using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject carrotPrefab;
    private GameObject currentCarrot;

    void Start()
    {
        SpawnCarrot();
    }
    public void SpawnCarrot()
    {
        currentCarrot = Instantiate(carrotPrefab, transform.position, transform.rotation);
        currentCarrot.GetComponent<ObjectGrabbable>().spawner = this;

    }
    public void OnCarrotDestroyed()
    {
        SpawnCarrot();
    }
}
