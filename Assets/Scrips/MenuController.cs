using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [Header("Menu Settings")]
    public string mainGame;

    public void QuitButton()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    public void StartGame()
    {
        Debug.Log("Iniciando el juego...");
        SceneManager.LoadScene(mainGame);
    }
}
