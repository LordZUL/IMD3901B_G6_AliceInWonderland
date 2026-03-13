using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
// need to go over this bug with maryum

public class Vaulting : MonoBehaviour
{
    private LayerMask vaultLayer;
    public Camera cam;
    private float playerHeight = 2f;
    private float playerRadius = 0.5f;
    private CharacterController controller;
    private bool isVaulting;

    Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vaultLayer = LayerMask.GetMask("VaultLayer");
        //controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //controller.Move(Vector3.down * 0.1f);

        Vault();
    }

    private void Vault()
    {
        if (isVaulting) return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // raycast spawns ray at camera location, if firstray hit vaultlayer
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out var firstHit, 1f, vaultLayer))
            {
                print("vaultable in front");
                Vector3 origin =
                    firstHit.point +
                    (cam.transform.forward * playerRadius) +
                    Vector3.up * (playerHeight * 0.6f);

                // second ray spawns from first 
                /*
                if (Physics.Raycast(firstHit.point + (cam.transform.forward * playerRadius) + (Vector3.up * (0.6f * playerHeight + playerHeight / 2)), Vector3.down, out var secondHit, playerHeight))
                {
                    print("found place to land");
                    // how fast
                    StartCoroutine(LerpVault(secondHit.point, 0.5f));
                }*/
                if (Physics.Raycast(origin, Vector3.down, out var secondHit, playerHeight * 2f))
                {
                    Debug.Log("Landing point found");

                    Vector3 targetPosition = secondHit.point + Vector3.up * (playerHeight* 2.5f);
                    //Vector3 targetPosition = secondHit.point + Vector3.up * 0.05f;
                    //rb.isKinematic = true;
                    isVaulting = true;
                    StartCoroutine(LerpVault(targetPosition, 0.5f));
                    //rb.isKinematic = false;
                }
            }
        }
    }
    IEnumerator LerpVault(Vector3 targetPosition, float duration)
    {
        controller.enabled = false;
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        controller.enabled = true;
        //forced grounding
        controller.Move(Vector3.down * 0.1f);
        isVaulting = false;
    }
}
