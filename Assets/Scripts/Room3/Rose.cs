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

        // The materials on leaves_geo and rose_geo are grabbed
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer r in renderers)
        {
            // Only apply the material change to rose_geo, not leaves_geo
            if (r.gameObject.name == "rose_geo")
            {
                // Get all materials
                Material[] mats = r.materials;

                for (int i = 0; i < mats.Length; i++)
                {
                    // Applies the red material
                    mats[i] = redMaterial;
                }

                r.materials = mats;
            }
        }

        Debug.Log("Rose painted red");

        // Painted rose count++
        MazeManager.instance.AddPaintedRose();
    }
}