using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
// make cat animation play loop after animation duration + 30 sec delay
public class catAnimationLoop : MonoBehaviour
{
    public Animator animator;
    //public string stateName = "Play";
    //public float animationLength = 3f; // set this manually or detect dynamically
    public float loop = 1f;

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
            // Start animation
            animator.Play("path", 0 , 0f);
            yield return new WaitForSeconds(loop);

            // Wait until the animation is actually playing
            //yield return null;

            // Wait until animation finishes
            // yield return new WaitUntil(() =>
            // animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f
        }
    }
}
