using UnityEngine;
using System.Collections;
// make cat animation play loop after animation duration + 30 sec delay
public class catAnimationLoop : MonoBehaviour
{
    public Animator animator;
    public string animationTrigger = "Play";
    public float animationLength = 3f; // set this manually or detect dynamically
    public float delayAfter = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(AnimationLoop());
    }

    IEnumerator AnimationLoop()
    {
        while (true)
        {
            animator.SetTrigger(animationTrigger);

            // Wait for animation to finish
            yield return new WaitForSeconds(animationLength);

            // Wait extra 30 seconds
            yield return new WaitForSeconds(delayAfter);
        }
    }
}
