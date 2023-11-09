using UnityEngine;

public class PPBlanket : EnemyBattle {
    protected override void Start() {
        base.Start();

        CharacterName = "PP Blanket";

        attackKeys.Add("throw");

        attackActions.Add(AttackList.GetInstance().GetAction(attackKeys[0]));
    }

    public override void Attacked(int damage)
    {
        base.Attacked(damage);

        if ((float)health / maxHealth <= .25f)
            characterAnimation.AnimationSetBool("Weak", true);
    }
}