using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Referencia al componente Text para mostrar la puntuación
    public Text highScoreText; // Referencia al componente Text para mostrar la puntuación más alta
    public static ScoreManager instance; // Instancia estática para acceso global
    [SerializeField] string fileName; // Nombre del archivo donde se guardan los puntajes
    
    int score = 0; // Puntuación actual del jugador
    int highScore = 0; // Puntuación más alta guardada

    public void Awake()
    {
        instance = this; // Asigna la instancia estática a esta instancia del ScoreManager
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadHighScoreFromFile();
        UpdateScoreDisplay();
        UpdateHighScoreDisplay();
    }

    private void LoadHighScoreFromFile()
    {
        // Cargar las entradas desde el archivo JSON
        List<InputEntry> entries = FileHandler.LoadListFromJSON<InputEntry>(fileName);
        
        if (entries.Count > 0)
        {
            // Obtener el puntaje más alto del archivo
            highScore = entries.Max(entry => entry.score);
            Debug.Log($"High score cargado desde archivo: {highScore}");
        }
        else
        {
            highScore = 0;
            Debug.Log("No se encontraron entradas en el archivo, high score establecido a 0");
        }
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    private void UpdateHighScoreDisplay()
    {
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    // Update is called once per frame
    public void AddScore(int points)
    {
        score += 1; // Incrementa la puntuación actual
        UpdateScoreDisplay(); // Actualiza el texto de la puntuación

        // Verifica si la puntuación actual es mayor que la puntuación más alta
        if (score > highScore)
        {
            highScore = score; // Actualiza la puntuación más alta
            UpdateHighScoreDisplay(); // Actualiza el texto de la puntuación más alta
            Debug.Log($"Nuevo high score alcanzado: {highScore}");
        }
    }

    public int GetScore()
    {
        return score; // Devuelve la puntuación actual
    }
    
    public int GetHighScore()
    {
        return highScore; // Devuelve la puntuación más alta
    }

    // Método para refrescar el high score desde el archivo (útil después de agregar nuevas entradas)
    public void RefreshHighScore()
    {
        LoadHighScoreFromFile();
        UpdateHighScoreDisplay();
    }

    // Método para resetear el score actual (útil al reiniciar el juego)
    public void ResetScore()
    {
        score = 0;
        UpdateScoreDisplay();
        Debug.Log("Score reseteado a 0");
    }

    // Método para establecer el nombre del archivo si es necesario
    public void SetFileName(string newFileName)
    {
        fileName = newFileName;
        Debug.Log($"Archivo de scores cambiado a: {fileName}");
        RefreshHighScore(); // Recargar el high score del nuevo archivo
    }
}
