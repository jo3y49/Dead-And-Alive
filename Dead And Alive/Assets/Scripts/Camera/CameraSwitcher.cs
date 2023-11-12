using UnityEngine;

public class CameraSwitcher : MonoBehaviour {
    private static CameraSwitcher instance;
    [SerializeField] private GameObject mainCamera, battleCamera;

    private void Awake() {
        if (instance == null) instance = this;

        else Destroy(gameObject);
    }

    private void Start() {
        MainCamera();
    }

    public void MainCamera()
    {
        mainCamera.SetActive(true);
        battleCamera.SetActive(false);
    }

    public void BattleCamera()
    {
        battleCamera.SetActive(true);
        mainCamera.SetActive(false);
    }

    public static CameraSwitcher GetInstance()
    {
        return instance;
    }
}