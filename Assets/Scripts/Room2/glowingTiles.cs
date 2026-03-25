using System.Collections;
using UnityEngine;
public class glowingTiles : MonoBehaviour
{
    public Renderer rend;
    public Color glowColor = Color.cyan;
    public float glowIntensity = 5f;

    void Start()
    {
        StartCoroutine(GlowRoutine());
    }

    IEnumerator GlowRoutine()
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
    }

    void SetGlow(bool state)
    {
        if (state)
        {
            rend.material.EnableKeyword("_EMISSION");
            rend.material.SetColor("_EmissionColor", glowColor * glowIntensity);
        }
        else
        {
            rend.material.SetColor("_EmissionColor", Color.black);
        }
    }
}
