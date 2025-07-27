using UnityEngine;

public class SoundFxManager : MonoBehaviour
{
    public static SoundFxManager instance; // Instancia estática para acceso global
    [SerializeField] private AudioSource soundFxSource; // Fuente de audio para efectos de sonido
    
    [Header("Menu Sound Effects")]
    [SerializeField] private AudioClip clickDownSound; // Sonido al presionar el botón
    [SerializeField] private AudioClip clickUpSound; // Sonido al soltar el botón
    [SerializeField] private AudioClip hoverSound; // Sonido al pasar el cursor por encima
    [SerializeField] private float menuSoundVolume = 0.5f; // Volumen para sonidos del menú

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundFXClip(AudioClip clip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFxSource, spawnTransform.position, Quaternion.identity);
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipDuration = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipDuration); // Destruye el objeto de audio después de que termine de sonar
    }

    // Métodos específicos para sonidos del menú
    public void PlayClickDownSound()
    {
        if (clickDownSound != null)
        {
            PlaySoundFXClip(clickDownSound, transform, menuSoundVolume);
        }
    }

    public void PlayClickUpSound()
    {
        if (clickUpSound != null)
        {
            PlaySoundFXClip(clickUpSound, transform, menuSoundVolume);
        }
    }

    public void PlayHoverSound()
    {
        if (hoverSound != null)
        {
            PlaySoundFXClip(hoverSound, transform, menuSoundVolume);
        }
    }

    // Método alternativo para reproducir sonidos simples sin posición específica
    public void PlaySimpleSoundFX(AudioClip clip, float volume = 1f)
    {
        if (clip != null && soundFxSource != null)
        {
            soundFxSource.PlayOneShot(clip, volume);
        }
    }
}
