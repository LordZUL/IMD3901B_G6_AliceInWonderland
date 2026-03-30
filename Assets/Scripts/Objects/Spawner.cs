using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject carrot;
    public void SpawnCarrot()
    {
        Instantiate(carrot);

    }
}
