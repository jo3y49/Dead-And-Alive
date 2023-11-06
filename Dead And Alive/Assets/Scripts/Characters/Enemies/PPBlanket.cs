using UnityEngine;

public class PPBlanket : EnemyBattle {
    protected override void Start() {
        base.Start();

        CharacterName = "PP Blanket";

        attackKeys.Add("physical");

        attackActions.Add(AttackList.GetInstance().GetAction(attackKeys[0]));
    }
}