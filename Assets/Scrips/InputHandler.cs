using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] TMPro.TMP_InputField nameInput;
    [SerializeField] string fileName;
    
    List<InputEntry> entries = new List<InputEntry>();

    private void Start()
    {
        entries = FileHandler.LoadFromJSON<InputEntry>(fileName);
        Debug.Log($"Entradas cargadas desde archivo: {entries.Count}");
        
        // Log de cada entrada cargada para debugging
        for (int i = 0; i < entries.Count; i++)
        {
            Debug.Log($"Entrada {i}: {entries[i].playerName} - {entries[i].score}");
        }
    }
    public void AddEntry()
    {
        string playerName = nameInput.text;
        int currentScore = ScoreManager.instance.GetScore();
        
        Debug.Log($"Agregando entrada: Nombre='{playerName}', Puntuación={currentScore}");
        
        entries.Add(new InputEntry(playerName, currentScore));
        nameInput.text = ""; // Limpiar el campo de entrada después de agregar la entrada
        
        Debug.Log($"Total de entradas antes de guardar: {entries.Count}");
        FileHandler.SaveToJSON<InputEntry>(entries, fileName); // Guardar las entradas en un archivo JSON
        Debug.Log("Entrada agregada: " + entries[entries.Count - 1].playerName + " con puntuación: " + entries[entries.Count - 1].score);
    }
}
