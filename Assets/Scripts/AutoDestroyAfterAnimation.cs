using UnityEngine;

public class AutoDestroyAfterAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        float clipLength = animator.runtimeAnimatorController.animationClips[0].length;
        Destroy(gameObject, clipLength);
    }
}
