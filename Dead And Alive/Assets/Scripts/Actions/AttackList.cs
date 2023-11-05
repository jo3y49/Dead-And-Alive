using System.Collections.Generic;
using UnityEngine;

public class AttackList
{
    private static AttackList instance;
    private IDictionary<string, AttackAction> actionList;

    private AttackList()
    {
        FillDictionary();
    }

    public static AttackList GetInstance()
    {
        instance ??= new AttackList();

        return instance;
    }

    public AttackAction GetAction(string key)
    {
        if (actionList.ContainsKey(key)) return actionList[key];

        else return new AttackAction("Null", EmptyAction);
    }


    private void FillDictionary()
    {
        actionList = new Dictionary<string, AttackAction>()
        {
            {"melee", new AttackAction("Melee", Melee)},
            {"ranged", new AttackAction("Ranged", Ranged)},
            {"heal", new AttackAction("Heal", Heal)},
        };
    }

    public bool EmptyAction(CharacterBattle self, CharacterBattle target)
    {
        Debug.Log("This action is null");
        string attackName = "null";
        float accuracy = 0;
        float damageMultiplier = 0;

        return AttackAction.DoAttack(self, target, attackName, accuracy, damageMultiplier);
    }

    public bool Melee(CharacterBattle self, CharacterBattle target)
    {
        string attackName = GetAction("melee").Name;
        float accuracy = 1f;
        float damageMultiplier = 1f;
        
        return AttackAction.DoAttack(self, target, attackName, accuracy, damageMultiplier);
    }

    public bool Ranged(CharacterBattle self, CharacterBattle target)
    {
        string attackName = GetAction("ranged").Name;
        float accuracy = 1f;
        float damageMultiplier = 1f;

        return AttackAction.DoAttack(self, target, attackName, accuracy, damageMultiplier);
    }

    public bool Heal(CharacterBattle self, CharacterBattle target)
    {
        string attackName = GetAction("heal").Name;
        float healMultiplier = 1f;

        return AttackAction.DoHeal(self, attackName, healMultiplier);
    }
}