using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ShootBehaviour : MonoBehaviour
{
    public GameObject collisionExplosion;
    public float m_speed = 10f; // Reducir velocidad
    public float destroyDistance = 100f;
    
    private Rigidbody rb;

    void Start()
    {
        // Obtener el Rigidbody al inicio
        rb = GetComponent<Rigidbody>();
        
        // Verificar componentes necesarios
        if (rb == null)
        {
            Debug.LogWarning($"El láser {gameObject.name} necesita un Rigidbody para detectar colisiones!");
        }
        
        if (GetComponent<Collider>() == null)
        {
            Debug.LogWarning($"El láser {gameObject.name} necesita un Collider para detectar colisiones!");
        }
        
        // Configurar el Rigidbody para movimiento estable
        if (rb != null)
        {
            rb.useGravity = false;
            rb.freezeRotation = true; // Evita que gire
            rb.linearDamping = 0f; // Sin resistencia al aire
            rb.angularDamping = 0f;
            
            // Mover usando velocidad en lugar de fuerza
            rb.linearVelocity = transform.up * m_speed;
        }
    }

    void Update()
    {
        // Si no tiene Rigidbody, usar transform (fallback)
        if (rb == null)
        {
            transform.position += transform.up * m_speed * Time.deltaTime;
        }

        // Si sale de los límites del mapa, se destruye
        if (Mathf.Abs(transform.position.x) > destroyDistance || Mathf.Abs(transform.position.z) > destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Láser colisionó con: {collision.gameObject.name} - Tag: {collision.gameObject.tag}");

        // Si colisiona con un asteroide (tag "Asteroid"), destruye ambos
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            if (collisionExplosion != null)
            {
                GameObject explosion = Instantiate(collisionExplosion, transform.position, transform.rotation);
                Destroy(explosion, 2f);
            }
            Debug.Log("Asteroide destruido por el disparo");
            Destroy(collision.gameObject); // Destruye el asteroide
            Destroy(gameObject); // Destruye el láser
            ScoreManager.instance.AddScore(1); // Añade puntuación
        }
    }
    
    // Alternativa con triggers (descomenta si cambias el collider a trigger)
    /*
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Láser trigger con: {other.gameObject.name} - Tag: {other.gameObject.tag}");
        
        if (other.CompareTag("Asteroid"))
        {
            if (collisionExplosion != null)
            {
                GameObject explosion = Instantiate(collisionExplosion, transform.position, transform.rotation);
                Destroy(explosion, 2f);
            }
            Debug.Log("Asteroide destruido por el disparo");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    */
}
