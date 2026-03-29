using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
// make cat animation play loop after animation duration + 30 sec delay
public class catAnimationLoop : MonoBehaviour
{
    public Animator animator;
    public Renderer cat;
    // Loop time, accounts for the animation time which is 12s. So the cat animation loops 3s after the animation is done.
    public float loop = 30f;
    public float animationLength = 13f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = true;
        StartCoroutine(AnimationLoop());
    }

    IEnumerator AnimationLoop()
    {
        while (true)
        {
            // Make cat visible when animation plays
            cat.enabled = true;

            // Start animation
            animator.Play("path", 0 , 0f);
            yield return new WaitForSeconds(animationLength);

            // Hide cat after animation plays
            cat.enabled = false;

            yield return new WaitForSeconds(loop);
        }
    }
}
