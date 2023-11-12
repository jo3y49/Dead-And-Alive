using UnityEngine;

public abstract class InteractableItem : MonoBehaviour {
    public bool interactable = true;

    public virtual void Interact(){}
}