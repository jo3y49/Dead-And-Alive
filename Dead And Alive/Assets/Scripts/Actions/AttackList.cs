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
            {"physical", new AttackAction("Physical", Physical)},
            {"ranged", new AttackAction("Ranged", Ranged)},
            {"heal", new AttackAction("Heal", Heal)},
            {"throw", new AttackAction("Throw", Throw)},
        };
    }

    public bool EmptyAction(CharacterBattle self, CharacterBattle target)
    {
        Debug.Log("This action is null");
        string attackName = "null";
        float accuracy = 0;
        float damageMultiplier = 0;
        uint attackID = 0;

        return AttackAction.DoAttack(self, target, attackName, attackID, accuracy, damageMultiplier);
    }

    public bool Physical(CharacterBattle self, CharacterBattle target)
    {
        string attackName = GetAction("physical").Name;
        float accuracy = 1f;
        float damageMultiplier = 1f;
        uint attackID = 3313907494;
        
        return AttackAction.DoAttack(self, target, attackName, attackID, accuracy, damageMultiplier);
    }

    public bool Ranged(CharacterBattle self, CharacterBattle target)
    {
        string attackName = GetAction("ranged").Name;
        float accuracy = 1f;
        float damageMultiplier = 1f;
        uint attackID = 1166900932;

        return AttackAction.DoAttack(self, target, attackName, attackID, accuracy, damageMultiplier);
    }

    public bool Heal(CharacterBattle self, CharacterBattle target)
    {
        string attackName = GetAction("heal").Name;
        float healMultiplier = 1f;
        uint attackID = 2093969607;

        return AttackAction.DoHeal(self, attackName, attackID, healMultiplier);
    }

    public bool Throw(CharacterBattle self, CharacterBattle target)
    {
        string attackName = GetAction("throw").Name;
        float accuracy = 1f;
        float damageMultiplier = 1f;
        uint attackID = 1177863625;

        return AttackAction.DoAttack(self, target, attackName, attackID, accuracy, damageMultiplier);
    }
}