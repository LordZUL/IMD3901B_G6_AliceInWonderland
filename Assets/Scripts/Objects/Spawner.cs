using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform parentContainer;
    public GameObject carrotPrefab;
    private GameObject currentCarrot;
    void Awake()
    {
        parentContainer = GameObject.Find("PivotCenter").transform;
    }
    void Start()
    {
        SpawnCarrot();
    }
    public void SpawnCarrot()
    {
        currentCarrot = Instantiate(
        carrotPrefab,
        transform.position,
        transform.rotation,
        parentContainer
        );

        var grabbable = currentCarrot.GetComponent<ObjectGrabbable>();
        if (grabbable != null)
        {
            grabbable.spawner = this;
        }

    }
    public void OnCarrotDestroyed()
    {
        SpawnCarrot();
    }
}
