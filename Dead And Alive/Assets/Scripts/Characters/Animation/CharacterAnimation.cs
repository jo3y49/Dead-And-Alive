using System.Collections;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {
    [SerializeField] protected Animator anim;

    public string currentTrigger = "";
    protected bool isFighting = false;
    public bool isAttacking = false;

    public virtual void AttackTrigger(string triggerName)
    {
        if (Utility.TriggerExists("Attack", anim))
        {
            StartCoroutine(AttackDuration());
            anim.SetTrigger("Attack");

            if (Utility.TriggerExists(triggerName, anim))
            {
                currentTrigger = triggerName;
                anim.SetTrigger(currentTrigger);
            }
        }
    }

    public virtual void AnimationTrigger(string triggerName)
    {
        if (Utility.TriggerExists(triggerName, anim))
        {
            currentTrigger = triggerName;
            anim.SetTrigger(currentTrigger);
        }
    }

    public virtual void AnimationSetBool(string triggerName, bool b)
    {
        if (Utility.TriggerExists(triggerName, anim))
            anim.SetBool(triggerName, b);
    }

    private IEnumerator AttackDuration()
    {
        isAttacking = true;

        yield return new WaitForSeconds(1);

        isAttacking = false;
    }

    public virtual Animator GetAnimator() {return anim;}
}