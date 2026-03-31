using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using TMPro;
// make cat animation play loop after animation duration + 30 sec delay
public class catAnimationLoop : MonoBehaviour
{
    public Animator animator;
    public Renderer cat;
    // Loop time, accounts for the animation time which is 12s. So the cat animation loops 3s after the animation is done.
    public float loop = 30f;
    public float animationLength = 13f;

    // UI
    public TMP_Text instructionText;
    // VR UI
    public TMP_Text VRinstructionText;

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
            instructionText.text = "Wait your turn!";
            VRinstructionText.text = "Wait your turn!";

            // Start animation
            animator.Play("path", 0 , 0f);
            yield return new WaitForSeconds(animationLength);

            // Hide cat after animation plays
            cat.enabled = false;
            instructionText.text = "Get to the other side!";
            VRinstructionText.text = "Get to the other side!";

            yield return new WaitForSeconds(loop);
        }
    }
}
