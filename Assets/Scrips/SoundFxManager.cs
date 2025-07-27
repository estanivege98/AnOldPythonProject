using UnityEngine;

public class SoundFxManager : MonoBehaviour
{
    public static SoundFxManager instance; // Instancia estática para acceso global
    [SerializeField] private AudioSource soundFxSource; // Fuente de audio para efectos de sonido

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
}
