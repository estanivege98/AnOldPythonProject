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
        Quaternion rotacion = spawnPoint.rotation * Quaternion.Euler(90, 0, 0);
        GameObject laser = Instantiate(laserPrefab, spawnPoint.position, rotacion);
        Rigidbody rb = laser.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(spawnPoint.forward * 1000f); // Ajusta la fuerza según sea necesario
        }
        Destroy(laser, 2f); // Destruye el láser después de 2 segundos
        Debug.Log("Disparo realizado");
    }
}
