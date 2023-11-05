using System.Collections;
using UnityEngine;

public class TutorialManager : WorldManager {
    [SerializeField] private PPBlanket pPBlanket;

    protected override void Start()
    {
        base.Start();

        enemies.Add(pPBlanket);

        StartCoroutine(StartDelayedBattle());
    }

    private IEnumerator StartDelayedBattle()
    {
        yield return new WaitForSeconds(1);

        StartBattle();
    }
}