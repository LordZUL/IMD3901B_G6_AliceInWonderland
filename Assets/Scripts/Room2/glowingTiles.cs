using System.Collections;
using UnityEngine;
public class glowingTiles : MonoBehaviour
{
    //public Renderer rend;
    public Renderer tileRenderer;
    public float rayDistance = 2f;
    public LayerMask catLayer;

    //public Color emissionColor = Color.green;
    private Color baseEmissionColor;
    public float emissionIntensity = 0.1f;

    private Material mat;
    private bool isActive = false;

    //private Coroutine emissionRoutine;

    void Start()
    {
        mat = tileRenderer.material;
        baseEmissionColor = mat.GetColor("_EmissionColor");
        //mat.DisableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", Color.black);
    }

    void Update()
    {
        // Cast ray upward
        // I am having issues where the ray is not detecting anything for the first and last tiles, so I am going to use the box colider method 

        Vector3 halfExtents = new Vector3(0.8f, 0.5f, 0.8f); // tile size
        //RaycastHit hit;
        Vector3 origin = transform.position + Vector3.up * 0.2f;

        Collider[] hits = Physics.OverlapBox(origin, halfExtents, Quaternion.identity, catLayer);

        foreach (var h in hits)
        {
            if (!isActive && h.CompareTag("Cat"))
            {
                StartCoroutine(EmissionRoutine());
                break;
            }
        }

        /*if (Physics.BoxCast(origin, halfExtents, Vector3.up, out hit, Quaternion.identity, rayDistance, catLayer))
        {
            if (!isActive && hit.collider.CompareTag("Cat"))
            {
                StartCoroutine(EmissionRoutine());
            }
        }*/






        /*Ray ray = new Ray(transform.position, Vector3.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, catLayer))
        {
            if (!isActive && hit.collider.CompareTag("Cat"))
            {
                StartCoroutine(EmissionRoutine());
            }
        }*/
    }

    IEnumerator EmissionRoutine()
    {
        isActive = true;

        // Turn emission ON
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", baseEmissionColor * emissionIntensity);

        yield return new WaitForSeconds(5f);

        // Turn emission OFF
        mat.DisableKeyword("_EMISSION");

        isActive = false;
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

    /*public void SetGlow(bool state)
    {
        if (state)
        {
            mat.SetColor("_EmissionColor", glowColor * glowIntensity);
        }
        else
        {
            mat.SetColor("_EmissionColor", Color.black);
        }
    }*/
}
