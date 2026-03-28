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
    //public Color playerGlowColor = Color.green;
    //public float permanentIntensity = 1.5f;
    public float emissionIntensity = 1f;

    private Material mat;

    private bool isActive = false;
    //private bool isPermanent = false;

    //private Coroutine emissionRoutine;

    void Start()
    {
        mat = tileRenderer.material;
        baseEmissionColor = mat.GetColor("_EmissionColor");
        //mat.DisableKeyword("_EMISSION
        // this will disable the glow
        mat.SetColor("_EmissionColor", Color.black);
    }

    void Update()
    {
        // Cast ray upward
        // I am having issues where the ray is not detecting anything for the first and last tiles, so I am going to use the box colider method 
        //if (isPermanent) return;

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

        
    }
    /*void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MakePermanent();
        }
    }*/
    IEnumerator EmissionRoutine()
    {
        isActive = true;

        // Turn emission ON
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", baseEmissionColor * emissionIntensity);

        yield return new WaitForSeconds(5f);

        // Turn emission OFF
        /*if (!isPermanent)
        {
            mat.DisableKeyword("_EMISSION");
        }*/
        mat.DisableKeyword("_EMISSION");

        isActive = false;
    }

    /*public void MakePermanent()
    {
        isPermanent = true;

        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", playerGlowColor * permanentIntensity);
    }*/


}
