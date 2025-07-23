using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HighScoreUIMenu : MonoBehaviour
{
    [SerializeField] GameObject panelHighScore; // Referencia al panel de puntuación más alta
    [SerializeField] GameObject highscoreUIElementPrefab;
    [SerializeField] Transform elementWrapper; // Padre donde se instanciarán los elementos de puntuación más alta
    [SerializeField] string fileName; // Nombre del archivo donde se guardan los puntajes

    List<GameObject> uiElements = new List<GameObject>();
    public void ShowPanel()
    {
        panelHighScore.SetActive(true); // Muestra el panel de puntuación más alta
        LoadAndDisplayHighScores(); // Carga y muestra los puntajes al abrir el panel
    }

    public void HidePanel()
    {
        panelHighScore.SetActive(false); // Oculta el panel de puntuación más alta
    }

    private void LoadAndDisplayHighScores()
    {
        Debug.Log("Cargando high scores desde: " + fileName);
        
        // Cargar las entradas desde el archivo
        List<InputEntry> entries = FileHandler.LoadListFromJSON<InputEntry>(fileName);
        Debug.Log($"Entradas cargadas: {entries.Count}");
        
        // Convertir InputEntry a HighScoreElement y ordenar por puntuación descendente
        List<HighScoreElement> highScores = entries
            .Select(entry => new HighScoreElement(entry.playerName, entry.score))
            .OrderByDescending(element => element.score)
            .Take(10) // Solo los top 10
            .ToList();
            
        Debug.Log($"Top scores a mostrar: {highScores.Count}");
        
        // Actualizar la UI
        UpdateUI(highScores);
    }

    private void UpdateUI(List<HighScoreElement> list)
    {
        // Limpiar elementos UI existentes
        foreach (GameObject element in uiElements)
        {
            if (element != null)
            {
                element.SetActive(false);
            }
        }

        // Mostrar los nuevos elementos
        for (int i = 0; i < list.Count; i++)
        {
            HighScoreElement element = list[i];
            if (element.score > 0)
            {
                // Crear nuevo elemento UI si no existe
                if (i >= uiElements.Count)
                {
                    var inst = Instantiate(highscoreUIElementPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent(elementWrapper, false); // Establece el padre del nuevo elemento
                    uiElements.Add(inst);
                }
                
                // Activar y configurar el elemento
                uiElements[i].SetActive(true);
                var texts = uiElements[i].GetComponentsInChildren<Text>();
                
                if (texts.Length >= 2)
                {
                    texts[0].text = $"{i + 1}. {element.playerName}"; // Agregar posición
                    texts[1].text = element.score.ToString();
                }
                else
                {
                    Debug.LogError($"El prefab highscoreUIElementPrefab no tiene suficientes componentes Text. Encontrados: {texts.Length}");
                }
            }
        }
        
        Debug.Log($"UI actualizada con {list.Count} elementos de high score");
    }

    // Método público para refrescar los high scores desde otros scripts
    public void RefreshHighScores()
    {
        if (panelHighScore.activeSelf)
        {
            LoadAndDisplayHighScores();
        }
    }

    // Método para cambiar el archivo de high scores si es necesario
    public void SetFileName(string newFileName)
    {
        fileName = newFileName;
        Debug.Log($"Archivo de high scores cambiado a: {fileName}");
    }
}
