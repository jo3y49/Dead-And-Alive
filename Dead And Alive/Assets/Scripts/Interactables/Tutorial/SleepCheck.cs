using UnityEngine;
using UnityEngine.SceneManagement;

public class SleepCheck : InteractableItem {
    public override void Interact()
    {
        SceneManager.LoadScene(0);
    }
}