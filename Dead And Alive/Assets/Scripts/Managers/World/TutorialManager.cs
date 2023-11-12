using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialManager : WorldManager {
    [SerializeField] private PPBlanket pPBlanket;
    [SerializeField] private List<BlanketCheck> blanketSpots;
    [SerializeField] private SleepCheck sleepCheck;

    public Vector3 playerStartLocation, pPBlanketBattleLocation, playerBattleLocation;
    public Vector3 playerStartRotation, playerBattleRotation;
    
    public bool grabTutorial = true;
    private int blanketCounter = 3;
    public TextMeshProUGUI textBox;
    public float textDisplayTime = 2f;

    private Coroutine tutorial;
    private Coroutine textDisplay;
    private InputActions inputActions;

    private void Awake() {
        inputActions = new InputActions();

        textBox.enabled = false;
    }

    protected override void Start()
    {
        base.Start();

        player.transform.position = playerStartLocation;
        player.transform.rotation = Quaternion.Euler(playerStartRotation);

        enemies.Add(pPBlanket);

        foreach (BlanketCheck blanketCheck in blanketSpots)
        {
            blanketCheck.SetTutorialManager(this);
        }

        sleepCheck.interactable = false;

        tutorial = StartCoroutine(WaitForGrab());
    }

    private IEnumerator WaitForGrab()
    {
        if (!grabTutorial) StopCoroutine(tutorial);

        inputActions.Enable();
        inputActions.Player.Interact.performed += context => grabTutorial = false;

        playerMovement.enabled = false;

        SetBlanketInteractability(false);

        textBox.enabled = true;
        textBox.text = "Press F to pick up your wet blanket";

        while (grabTutorial){
            yield return null;
        }

        textBox.text = "Wet blanket has been picked up! You need to hide it before mom sees. Try pressing F on various things in the room to hide it.";

        inputActions.Player.Interact.performed -= context => grabTutorial = false;
        inputActions.Disable();

        playerMovement.enabled = true;

        SetBlanketInteractability(true);
    }

    private void SetBlanketInteractability(bool b)
    {
        foreach (BlanketCheck blanketCheck in blanketSpots)
        {
            blanketCheck.interactable = b;
        }
    }

    public void FindBlanket()
    {
        blanketCounter--;
        if (textDisplay != null) StopCoroutine(textDisplay);

        if (blanketCounter > 0)
        {
            
            textDisplay = StartCoroutine(DisplayTextTemp("Can't hide it here"));

            return;
        }

        SetBlanketInteractability(false);

        player.transform.position = playerBattleLocation;
        player.transform.rotation = Quaternion.Euler(playerBattleRotation);

        pPBlanket.transform.position = pPBlanketBattleLocation;
        pPBlanket.gameObject.SetActive(true);
        StartBattle();
    }

    public override void WinBattle()
    {
        base.WinBattle();

        sleepCheck.interactable = true;

        textBox.text = "That's enough. I'm going back to bed";
        textBox.enabled = true;
    }

    private IEnumerator DisplayTextTemp(string text)
    {
        textBox.enabled = true;
        textBox.text = text;

        yield return new WaitForSeconds(textDisplayTime);

        textBox.enabled = false;
        textDisplay = null;
    }

}