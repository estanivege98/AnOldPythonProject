using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("Sound Settings")]
    [SerializeField] private bool useGlobalSounds = true; // Usar sonidos del SoundFxManager
    [SerializeField] private AudioClip customClickDownSound; // Sonido personalizado al presionar
    [SerializeField] private AudioClip customClickUpSound; // Sonido personalizado al soltar
    [SerializeField] private AudioClip customHoverSound; // Sonido personalizado al hover
    [SerializeField] private float customVolume = 0.5f; // Volumen personalizado

    private bool hasPlayedHoverSound = false; // Para evitar reproducir el hover múltiples veces

    // Se ejecuta cuando el cursor entra en el botón
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!hasPlayedHoverSound)
        {
            PlayHoverSound();
            hasPlayedHoverSound = true;
        }
    }

    // Se ejecuta cuando el cursor sale del botón
    public void OnPointerExit(PointerEventData eventData)
    {
        // Resetear el flag del hover para permitir el sonido la próxima vez que entre
        hasPlayedHoverSound = false;
    }

    // Se ejecuta cuando se presiona el botón (click down)
    public void OnPointerDown(PointerEventData eventData)
    {
        PlayClickDownSound();
    }

    // Se ejecuta cuando se suelta el botón (click up)
    public void OnPointerUp(PointerEventData eventData)
    {
        PlayClickUpSound();
    }

    private void PlayHoverSound()
    {
        if (useGlobalSounds && SoundFxManager.instance != null)
        {
            SoundFxManager.instance.PlayHoverSound();
        }
        else if (customHoverSound != null && SoundFxManager.instance != null)
        {
            SoundFxManager.instance.PlaySimpleSoundFX(customHoverSound, customVolume);
        }
    }

    private void PlayClickDownSound()
    {
        if (useGlobalSounds && SoundFxManager.instance != null)
        {
            SoundFxManager.instance.PlayClickDownSound();
        }
        else if (customClickDownSound != null && SoundFxManager.instance != null)
        {
            SoundFxManager.instance.PlaySimpleSoundFX(customClickDownSound, customVolume);
        }
    }

    private void PlayClickUpSound()
    {
        if (useGlobalSounds && SoundFxManager.instance != null)
        {
            SoundFxManager.instance.PlayClickUpSound();
        }
        else if (customClickUpSound != null && SoundFxManager.instance != null)
        {
            SoundFxManager.instance.PlaySimpleSoundFX(customClickUpSound, customVolume);
        }
    }

    // Método para resetear el hover sound cuando se desactiva el componente
    private void OnDisable()
    {
        hasPlayedHoverSound = false;
    }
}
