using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    public GameObject collisionExplosion;
    public float m_speed = 20f;
    public float destroyDistance = 100f; // Distancia máxima antes de autodestruirse

    void Update()
    {
        // Mover siempre hacia arriba (eje Y)
        transform.position += transform.up * m_speed * Time.deltaTime;

        // Si sale de los límites del mapa, se destruye
        if (Mathf.Abs(transform.position.x) > destroyDistance || Mathf.Abs(transform.position.z) > destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Si colisiona con un asteroide (tag "Asteroid"), destruye ambos
        if (other.CompareTag("Asteroid"))
        {
            if (collisionExplosion != null)
            {
                GameObject explosion = Instantiate(collisionExplosion, transform.position, transform.rotation);
                Destroy(explosion, 2f);
            }
            Destroy(other.gameObject); // Destruye el asteroide
            Destroy(gameObject); // Destruye el láser
        }
    }
}
