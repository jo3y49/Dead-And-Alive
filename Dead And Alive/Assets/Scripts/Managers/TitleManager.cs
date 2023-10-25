using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    private readonly int firstScene = 1;
    public void StartGame()
    {
        SceneManager.LoadScene(firstScene);
    }
}