using UnityEngine;

public class MazeManager : MonoBehaviour
{
    public static MazeManager instance;

    public int totalRoses = 7;
    private int paintedRoses = 0;

    public GameObject exitDoor;

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

        
        exitDoor.SetActive(true);
    }
}