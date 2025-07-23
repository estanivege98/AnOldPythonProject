using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class HighScoreManager : MonoBehaviour
{
    List<HighScoreElement> highScoreList = new List<HighScoreElement>();
    [SerializeField] int maxHighScores = 10; // Número máximo de puntuaciones más altas a almacenar
    [SerializeField] string fileName; // Nombre del archivo para guardar las puntuaciones más altas

    private void Start()
    {
        LoadHighScores(); // Cargar puntuaciones más altas al iniciar

    }

    private void LoadHighScores()
    {
        highScoreList = FileHandler.LoadListFromJSON<HighScoreElement>(fileName);
        while(highScoreList.Count > maxHighScores)
        {
            highScoreList.RemoveAt(highScoreList.Count - 1); // Eliminar puntuaciones más bajas si excede el máximo
        }
    }

    private void SaveHighScores()
    {
        FileHandler.SaveToJSON<HighScoreElement>(highScoreList, fileName);
    }

    public void AddHighScoreIfPossible(HighScoreElement element)
    {
        for (int i = 0; i < highScoreList.Count; i++)
        {
            if (i >= highScoreList.Count || element.score > highScoreList[i].score)
            {
                highScoreList.Insert(i, element); // Insertar el nuevo elemento en la posición correcta
                if (highScoreList.Count > maxHighScores)
                {
                    highScoreList.RemoveAt(highScoreList.Count - 1); // Eliminar el último elemento si excede el máximo
                }
                SaveHighScores(); // Guardar las puntuaciones más altas actualizadas
                return;
            }
        }
    }

}
