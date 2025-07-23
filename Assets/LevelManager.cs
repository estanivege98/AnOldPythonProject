using TMPro.EditorUtilities;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance; // Instancia estática para acceso global
    [SerializeField] private UIManager uiManager; // Referencia directa al UIManager

    private void Awake()
    {
        if (LevelManager.instance == null)
        {
            instance = this; // Asigna la instancia estática a esta instancia del LevelManager
        }
        else Destroy(gameObject); // Si ya existe una instancia, destruye este objeto
    }

    void Start()
    {
        // Si no se asignó UIManager en el inspector, buscar uno en la escena
        if (uiManager == null)
        {
            uiManager = FindFirstObjectByType<UIManager>();
        }
    }

    public void GameOver()
    {
        Debug.Log("GameOver llamado");
        
        if (uiManager != null)
        {
            uiManager.ToggleDeathScreen(); // Muestra la pantalla de Game Over
            uiManager.HideScoreUI(); // Oculta la UI de puntuación
            Debug.Log("Death screen activada y Score UI ocultada");
        }
        else
        {
            Debug.LogError("UIManager no encontrado! Asigna la referencia en el LevelManager");
        }
    }
}
