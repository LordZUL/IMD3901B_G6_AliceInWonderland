using UnityEngine;

// Originally I was thinking it could be set trigger where player touch then transport back. Here is a tutorial using threshold
// https://www.youtube.com/watch?v=Mic9ERhr0HA 
public class GameSpawn : MonoBehaviour
{
    public float threshold = -10; //defined as y value of the transform
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //runs on fixed timestep
    void FixedUpdate()
    {
        if(transform.position.y < threshold)
        {
            transform.position = new Vector3(0f, 2.25f, 2.43f);
        }
    }
}
