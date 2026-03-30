using UnityEngine;

public class Rose : MonoBehaviour
{
    public Material redMaterial;
    private Renderer rend;
    private bool isPainted = false;

    public void Paint()
    {
        if (isPainted) return;

        isPainted = true;

        
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer r in renderers)
        {
  
            if (r.gameObject.name == "rose_geo")
            {
                r.material = redMaterial;
                Debug.Log("Rose painted red");
            }
        }

    
        MazeManager.instance.AddPaintedRose();
    }
}