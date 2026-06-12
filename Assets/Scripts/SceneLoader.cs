using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName = "GameScene";

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
