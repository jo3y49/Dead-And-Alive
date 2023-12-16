using UnityEngine;

public static class AudioManager {

    // private void Start() {
    //     AkSoundEngine.LoadBank(1022080539U);
    // }
    public static void PlaySound(GameObject gameObject, uint eventID)
    {
        AkSoundEngine.PostEvent(eventID, gameObject);
    }

    public static void PlaySound(GameObject gameObject, string eventName)
    {
        Debug.Log("Playing sound: " + eventName + " on " + gameObject.name);
        AkSoundEngine.PostEvent(eventName, gameObject);
    }
}