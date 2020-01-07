using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoLevelScene()
    {
        SceneManager.LoadScene("Level");
    }

    public void GotoMenuScene()
    {
        SceneManager.LoadScene("LoginScreen");
    }
}
