using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject deathScreen; // Referencia a la pantalla de Game Over
    [SerializeField] GameObject scoreUI; // Referencia a la UI de puntuación
    [SerializeField] GameObject highScoreUI; // Pantalla de registro de puntuación más alta
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
            HideHighScoreUI(); // Asegúrate de ocultar la UI de puntuación más alta si está activa
            HideScoreUI(); // También oculta la UI de puntuación normal si está activa
            
            deathScreen.SetActive(true);
            Debug.Log("Death screen mostrada");
        }
        else
        {
            Debug.LogError("Death Screen no asignada en UIManager");
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

    public void ToggleHighScoreUI()
    {
        if (highScoreUI != null)
        {
            highScoreUI.SetActive(!highScoreUI.activeSelf); // Activa o desactiva la UI de puntuación más alta
            Debug.Log($"High Score UI activada: {highScoreUI.activeSelf}");
        }
        else
        {
            Debug.LogError("High Score UI no asignada en UIManager");
        }
    }
    public void ShowHighScoreUI()
    {
        if (highScoreUI != null)
        {
            highScoreUI.SetActive(true);
            Debug.Log("High Score UI mostrada");
        }
        else
        {
            Debug.LogError("High Score UI no asignada en UIManager");
        }
    }

    public void HideHighScoreUI()
    {
        if (highScoreUI != null)
        {
            highScoreUI.SetActive(false);
            Debug.Log("High Score UI ocultada");
        }
        else
        {
            Debug.LogError("High Score UI no asignada en UIManager");
        }
    }
}
