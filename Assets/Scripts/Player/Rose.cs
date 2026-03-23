using UnityEngine;

public class Rose : MonoBehaviour
{
    public bool isPainted = false;
    public Material redMaterial;

    private Renderer rend;

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

        Debug.Log("Rose painted red 🌹");
    }
}