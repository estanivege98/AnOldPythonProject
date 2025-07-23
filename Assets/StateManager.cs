using UnityEngine;
using UnityEngine.SceneManagement;
public class StateManager : MonoBehaviour
{
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeSceneByName(string sceneName)
    {
        if (sceneName != null && sceneName != "")
        {
            SceneManager.LoadScene(sceneName);
        }
        
        
    }
}
