using UnityEngine;

public class MazeManager : MonoBehaviour
{
    public static MazeManager instance;

    public int totalRoses = 7;
    private int paintedRoses = 0;

    public GameObject exitDoor;

    void Awake()
    {
        // Door isn't visible for now because it should only appear once all roses have been painted
        exitDoor.SetActive(false);
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

        // Door appears once all roses have been found, so player can interact with it and be brought to the finishing scene
        exitDoor.SetActive(true);
    }
}