using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject deathScreen; // Referencia a la pantalla de Game Over
    [SerializeField] GameObject scoreUI; // Referencia a la UI de puntuación
    
    public void ToggleDeathScreen()
    {
        if (deathScreen != null)
        {
            deathScreen.SetActive(!deathScreen.activeSelf); // Activa o desactiva la pantalla de Game Over
            Debug.Log($"Death screen activada: {deathScreen.activeSelf}");
        }
        else
        {
            Debug.LogError("Death Screen no asignada en UIManager");
        }
    }
    
    public void ShowDeathScreen()
    {
        if (deathScreen != null)
        {
            deathScreen.SetActive(true);
            Debug.Log("Death screen mostrada");
        }
    }
    
    public void HideDeathScreen()
    {
        if (deathScreen != null)
        {
            deathScreen.SetActive(false);
            Debug.Log("Death screen ocultada");
        }
    }
    
    public void HideScoreUI()
    {
        if (scoreUI != null)
        {
            scoreUI.SetActive(false); // Oculta la UI de puntuación
            Debug.Log("Score UI ocultada");
        }
        else
        {
            Debug.LogError("Score UI no asignada en UIManager");
        }
    }
    
    public void ShowScoreUI()
    {
        if (scoreUI != null)
        {
            scoreUI.SetActive(true);
            Debug.Log("Score UI mostrada");
        }
    }
}
