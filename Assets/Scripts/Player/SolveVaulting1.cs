using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
// need to go over this bug with maryum

public class SolveVaulting : MonoBehaviour
{
    private int vaultLayer;
    public Camera cam;
    private float playerHeight = 3f;
    private float playerRadius = 0.5f;
    void Start()
    {
        vaultLayer = LayerMask.NameToLayer("VaultLayer");
        vaultLayer = ~vaultLayer;
    }

    // Update is called once per frame
    void Update()
    {
        Vault();
    }
    private void Vault()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out var firstHit, 1f, vaultLayer))
            {
                print("vaultable in front");

                if (Physics.Raycast(firstHit.point + (cam.transform.forward * playerRadius) + (Vector3.up * 0.6f * playerHeight), Vector3.down, out var secondHit, playerHeight))
                {
                    print("found place to land");
                    Vector3 targetPosition = secondHit.point + Vector3.up * (playerHeight * 2.5f);
                    StartCoroutine(LerpVault(targetPosition, 0.5f));
                }
            }
        }

    }
    IEnumerator LerpVault(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
