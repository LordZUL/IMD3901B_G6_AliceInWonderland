using UnityEngine;

public class LedgeGrabbing : MonoBehaviour
{
    private Rigidbody rb;
    bool hanging;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        LedgeGrab();
    }

    void LedgeGrab()
    {
        // is player falling and not hanging
        if (rb.linearVelocity.y < 0 && !hanging)
        {
            RaycastHit downHit;
            Vector3 lineDownStart;
            Vector3 lineDownEnd;
        }
    }
}
