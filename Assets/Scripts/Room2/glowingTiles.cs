using System.Collections;
using UnityEngine;
public class glowingTiles : MonoBehaviour
{
    //public Renderer rend;
    public Color glowColor = Color.cyan;
    public float glowIntensity = 5f;

    Material mat;

    void Start()
    {
        //StartCoroutine(GlowRoutine());
        mat = GetComponent<Renderer>().material;
        mat.EnableKeyword("_EMISSION");
        SetGlow(false);
    }

    /*IEnumerator GlowRoutine()
    {
        while (true)
        {
            // Wait 30 seconds
            yield return new WaitForSeconds(30f);

            // Turn glow ON
            SetGlow(true);

            // Stay glowing for 5 seconds
            yield return new WaitForSeconds(5f);

            // Turn glow OFF
            SetGlow(false);
        }
    }*/

    public void SetGlow(bool state)
    {
        if (state)
        {
            mat.SetColor("_EmissionColor", glowColor * glowIntensity);
        }
        else
        {
            mat.SetColor("_EmissionColor", Color.black);
        }
    }
}
