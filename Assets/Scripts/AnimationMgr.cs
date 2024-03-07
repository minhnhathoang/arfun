using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMgr : MonoBehaviour
{
    private int currentAnimationIndex = 0;
    private float doubleClickTime = 0.3f;
    private float lastClickTime = 0f;
    private bool isAnimating = false;
    private Animation legacyAnimation;
    private AnimationClip[] animationClips;

    IEnumerator PlayNextAnimation()
    {
        Debug.Log("Playing Animation" + currentAnimationIndex);
        legacyAnimation.clip = animationClips[currentAnimationIndex];
        legacyAnimation.Play(); 
        yield return new WaitForSeconds(legacyAnimation.clip.length);
        currentAnimationIndex = (currentAnimationIndex + 1) % animationClips.Length;
    }

    void Start()
    {
        legacyAnimation = GetComponent<Animation>();
        animationClips = GetAnimationClips(legacyAnimation);
        StartCoroutine(PlayNextAnimation());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= doubleClickTime)
            {
                if (!isAnimating)
                {
                    isAnimating = true;
                    StartCoroutine(PlayNextAnimation());
                }
            }
            else
            {
                lastClickTime = Time.time;
                isAnimating = false;
            }
        }
    }

    // Helper method to get animation clips from the legacy Animation component
    AnimationClip[] GetAnimationClips(Animation anim)
    {
        List<AnimationClip> clips = new List<AnimationClip>();
        foreach (AnimationState state in anim)
        {
            clips.Add(state.clip);
        }

        return clips.ToArray();
    }
}