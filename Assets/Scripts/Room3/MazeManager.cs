using UnityEngine;

public class MazeManager : MonoBehaviour
{
    public static MazeManager instance;

    public int totalRoses = 5;
    private int paintedRoses = 0;

    public GameObject exitDoor; // or hedge wall

    void Awake()
    {
        instance = this;
    }

    public void AddPaintedRose()
    {
        paintedRoses++;

        Debug.Log("Painted: " + paintedRoses + "/" + totalRoses);

        if (paintedRoses >= totalRoses)
        {
            OpenExit();
        }
    }

    void OpenExit()
    {
        Debug.Log("Maze Complete!");

        // Option 1: disable door
        exitDoor.SetActive(false);

        // Option 2 (better later): play animation
    }
}