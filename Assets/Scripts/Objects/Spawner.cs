using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform parentContainer;
    public GameObject prefab;
    private GameObject currentPrefab;
    void Awake()
    {
        parentContainer = GameObject.Find("PivotCenter").transform;
    }
    void Start()
    {
        SpawnPrefab();
    }
    public void SpawnPrefab()
    {
        currentPrefab = Instantiate(
        prefab,
        transform.position,
        transform.rotation,
        parentContainer
        );

        var grabbable = currentPrefab.GetComponent<ObjectGrabbable>();
        if (grabbable != null)
        {
            grabbable.spawner = this;
        }

    }
    public void OnPrefabDestroyed()
    {
        SpawnPrefab();
    }
}
