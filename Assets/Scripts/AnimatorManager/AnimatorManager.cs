using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimationSetup> animationSetups;

    public enum AnimationType
    {
        IDLE,
        RUN,
        DEATH
    }

    public void Play(AnimationType type, float currentSpeedFactor = 1f)
    {
        foreach (var animation in animationSetups)
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                animator.speed = animation.speed * currentSpeedFactor;
                break;
            }
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Play(AnimationType.IDLE);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Play(AnimationType.RUN);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Play(AnimationType.DEATH);
        }
    }
}

    [System.Serializable]
    public class AnimationSetup
    {
        public AnimatorManager.AnimationType type;
        public string trigger;
    public float speed = 1f;
    }
