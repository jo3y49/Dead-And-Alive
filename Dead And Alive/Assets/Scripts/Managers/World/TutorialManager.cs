using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialManager : WorldManager {
    [SerializeField] private PPBlanket pPBlanket;
    [SerializeField] private List<BlanketCheck> blanketSpots;

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

        tutorial = StartCoroutine(WaitForGrab());
    }

    private IEnumerator WaitForGrab()
    {
        if (!grabTutorial) StopCoroutine(tutorial);

        inputActions.Enable();
        inputActions.Player.Interact.performed += context => grabTutorial = false;

        playerMovement.enabled = false;

        SetBlanketInteractability(false);

        while (grabTutorial){
            yield return null;
        }

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

        if (blanketCounter > 0)
        {
            Debug.Log("Can't hide it here");
            return;
        }

        SetBlanketInteractability(false);

        player.transform.position = playerBattleLocation;
        player.transform.rotation = Quaternion.Euler(playerBattleRotation);

        pPBlanket.transform.position = pPBlanketBattleLocation;
        pPBlanket.gameObject.SetActive(true);
        StartBattle();
    }

    private IEnumerator DisplayTextTemp(string text)
    {
        textBox.enabled = true;
        textBox.text = text;

        yield return new WaitForSeconds(textDisplayTime);

        textBox.enabled = false;
    }

}