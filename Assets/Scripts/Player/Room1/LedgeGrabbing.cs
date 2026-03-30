using UnityEngine;
//tutorial based on https://www.youtube.com/watch?v=EOn4IPEJf8k
public class LedgeGrabbing : MonoBehaviour
{
    private Rigidbody rb;
    public bool hanging;
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
            Vector3 lineDownStart = (transform.position + Vector3.up*3f) + transform.forward;
            Vector3 lineDownEnd = (transform.position + Vector3.up * 1.5f) + transform.forward;
            Physics.Linecast(lineDownStart, lineDownEnd, out downHit, LayerMask.GetMask("VaultLayer"));

            if (downHit.collider != null) 
            {
                RaycastHit fwdHit;
                Vector3 lineFwdStart = new Vector3(transform.position.x, downHit.point.y-0.1f, transform.position.z);
                Vector3 lineFwdEnd = new Vector3(transform.position.x, downHit.point.y - 0.1f, transform.position.z) + transform.forward;
                Physics.Linecast(lineFwdStart, lineFwdEnd, out fwdHit, LayerMask.GetMask("VaultLayer"));

                if (fwdHit.collider != null) 
                {
                    rb.useGravity = false;
                    rb.linearVelocity = Vector3.zero;

                    hanging = true;

                    Vector3 hangPos = new Vector3(fwdHit.point.x, downHit.point.y, fwdHit.point.z);
                    Vector3 offset = transform.forward * -0.1f + transform.up * -1f;
                    hangPos += offset;
                    transform.position = hangPos;
                    //normal is direction of face we hit
                    transform.forward = -fwdHit.normal;
                }
            }
        }
    }
}
