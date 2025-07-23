using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Referencia al componente Text para mostrar la puntuación
    public Text highScoreText; // Referencia al componente Text para mostrar la puntuación más alta
    public static ScoreManager instance; // Instancia estática para acceso global
    int score = 0; // Puntuación actual del jugador
    int highScore = 0; // Puntuación más alta guardada

    public void Awake()
    {
        instance = this; // Asigna la instancia estática a esta instancia del ScoreManager
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        scoreText.text = "Score: " + score.ToString(); 
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    // Update is called once per frame
    public void AddScore(int points)
    {
        score += 1; // Incrementa la puntuación actual
        scoreText.text = "Score: " + score.ToString(); // Actualiza el texto de la puntuación

        // Verifica si la puntuación actual es mayor que la puntuación más alta
        if (score > highScore)
        {
            highScore = score; // Actualiza la puntuación más alta
            highScoreText.text = "High Score: " + highScore.ToString(); // Actualiza el texto de la puntuación más alta
            PlayerPrefs.SetInt("HighScore", highScore); // Guarda la nueva puntuación más alta
        }
    }
}
