using UnityEngine;

public class BlanketCheck : InteractableItem {
    private TutorialManager tutorialManager;
    
    public override void Interact()
    {
        
        tutorialManager.FindBlanket();
        interactable = false;
    }

    public void SetTutorialManager(TutorialManager tutorialManager)
    {
        this.tutorialManager = tutorialManager;
    }
}