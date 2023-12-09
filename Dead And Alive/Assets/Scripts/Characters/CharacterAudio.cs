using UnityEngine;

public class CharacterAudio : MonoBehaviour {

    // private void Start() {
    //     AkSoundEngine.LoadBank(1022080539U);
    // }
    public virtual void PlaySound(uint eventID)
    {
        AkSoundEngine.PostEvent(eventID, gameObject);
    }

    public virtual void PlaySound(string eventName)
    {
        AkSoundEngine.PostEvent(eventName, gameObject);
    }
}