using UnityEngine;

public class LaserShot : MonoBehaviour
{
    [Header("Disparo")]
    public GameObject laserPrefab;
    public Transform spawnPoint;
    public float fireRate = 50f; // Tiempo entre disparos
    public float timestampshoot = 0.2f; // Marca de tiempo del último disparo

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
        Quaternion rotacion = spawnPoint.rotation * Quaternion.Euler(90, 0, 0);
        GameObject laser = Instantiate(laserPrefab, spawnPoint.position, rotacion);
        
        // Debug para verificar la dirección
        Debug.Log($"Láser disparado en dirección: {laser.transform.up}");
        
        Destroy(laser, 3f);
        Debug.Log("Disparo realizado");
    }
}
