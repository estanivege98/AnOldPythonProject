using UnityEngine;

public class LaserShot : MonoBehaviour
{
    [Header("Disparo")]
    public GameObject laserPrefab;
    public Transform spawnPoint;
    public float fireRate = 50f; // Tiempo entre disparos
    public float timestampshoot = 0.2f; // Marca de tiempo del último disparo
    [SerializeField] AudioClip laserSound; // Sonido del láser
    private float nextFireTime = 0f;

    void Update(){
        bool shoot = Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space);

        if (shoot && Time.time >= nextFireTime)
        {
            laserShoot();
            nextFireTime = Time.time + timestampshoot;
        }
    }

    void laserShoot()
    {
        // Usar la rotación del spawnPoint directamente
        // Si el láser va en dirección incorrecta, ajusta la rotación del spawnPoint en Unity
        SoundFxManager.instance.PlaySoundFXClip(laserSound, transform, 0.3f);
        Quaternion rotacion = spawnPoint.rotation * Quaternion.Euler(90, 0, 0);
        GameObject laser = Instantiate(laserPrefab, spawnPoint.position, rotacion);
        
        
        Destroy(laser, 3f);
        
    }
}
