using UnityEngine;

public class Rose : MonoBehaviour
{
    public Material redMaterial;
    private Renderer rend;
    private bool isPainted = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void Paint()
    {
        if (isPainted) return;

        isPainted = true;

        if (redMaterial != null)
        {
            rend.material = redMaterial;
        }

        Debug.Log("Rose painted 🌹");

        // ✅ ADD THIS
        MazeManager.instance.AddPaintedRose();
    }
}