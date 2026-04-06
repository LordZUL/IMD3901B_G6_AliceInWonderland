using UnityEngine;

public class Room1Spawn : MonoBehaviour
{
    public float threshold = -5; //defined as y value of the transform
    //runs on fixed timestep
    [SerializeField] private Transform spawnPoint;


    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            Vector3 spawnPos = spawnPoint.position;
            spawnPos.y += 10;
            transform.position = spawnPos;
        }
    }
}
