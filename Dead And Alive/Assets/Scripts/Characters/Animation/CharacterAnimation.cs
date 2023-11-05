using UnityEngine;

public class CharacterAnimation : MonoBehaviour {
    protected Animator anim;
    protected SpriteRenderer sr;

    public string currentTrigger = "";
    protected bool isFighting = false;
    public bool isAttacking = false;

    protected virtual void Start() {
        TryGetComponent(out anim);
        TryGetComponent(out sr);
    }

    public virtual void AnimationTrigger(string triggerName)
    {
        if (anim != null && TriggerExists(triggerName, anim))
        {
            currentTrigger = triggerName;
            anim.SetTrigger(currentTrigger);
        }
    }

    private bool TriggerExists(string triggerName, Animator anim) 
    {
        int hash = Animator.StringToHash(triggerName);
        for (int i = 0; i < anim.parameterCount; i++)
        {
            AnimatorControllerParameter param = anim.GetParameter(i);
            if (param.nameHash == hash && param.type == AnimatorControllerParameterType.Trigger)
                return true;
        }
        return false;
    }

    public virtual void ResetTrigger()
    {
        if (anim != null)
        {
            anim.ResetTrigger(currentTrigger);
            isAttacking = false;
        }
    }

    public virtual Animator GetAnimator() {return anim;}
}