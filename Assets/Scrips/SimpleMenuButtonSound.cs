using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimpleMenuButtonSound : MonoBehaviour, IPointerEnterHandler
{
    private Button button;

    private void Start()
    {
        // Obtener el componente Button
        button = GetComponent<Button>();
        
        // Agregar sonido al evento OnClick del botón
        if (button != null)
        {
            button.onClick.AddListener(PlayClickSound);
        }
    }

    // Sonido cuando se hace hover sobre el botón
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (SoundFxManager.instance != null)
        {
            SoundFxManager.instance.PlayHoverSound();
        }
    }

    // Sonido cuando se hace click en el botón
    private void PlayClickSound()
    {
        if (SoundFxManager.instance != null)
        {
            SoundFxManager.instance.PlayClickUpSound(); // Usar click up como sonido de click general
        }
    }

    private void OnDestroy()
    {
        // Limpiar el listener cuando se destruye el objeto
        if (button != null)
        {
            button.onClick.RemoveListener(PlayClickSound);
        }
    }
}
