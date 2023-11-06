using System.Collections;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {
    [SerializeField] protected Animator anim;

    public string currentTrigger = "";
    protected bool isFighting = false;
    public bool isAttacking = false;

    public virtual void AttackTrigger(string triggerName)
    {
        if (TriggerExists(triggerName, anim))
        {
            StartCoroutine(AttackDuration());
            anim.SetTrigger("Attack");
            currentTrigger = triggerName;
            anim.SetTrigger(currentTrigger);
        }
    }

    public virtual void AnimationTrigger(string triggerName)
    {
        if (TriggerExists(triggerName, anim))
        {
            currentTrigger = triggerName;
            anim.SetTrigger(currentTrigger);
        }
    }

    private bool TriggerExists(string triggerName, Animator anim) 
    {
        if (anim == null) return false;

        int hash = Animator.StringToHash(triggerName);
        for (int i = 0; i < anim.parameterCount; i++)
        {
            AnimatorControllerParameter param = anim.GetParameter(i);
            if (param.nameHash == hash && param.type == AnimatorControllerParameterType.Trigger)
                return true;
        }
        return false;
    }

    private IEnumerator AttackDuration()
    {
        isAttacking = true;

        yield return new WaitForSeconds(1);

        isAttacking = false;
    }

    public virtual Animator GetAnimator() {return anim;}
}