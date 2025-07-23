using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    public float speed;
    public float rotationSpeed = 10f; // Velocidad de rotación del asteroide
                                      // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject collisionExplosion;
    void Start()
    {
        // Inicializa la velocidad del asteroide
        speed = Random.Range(5f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        // Mueve el asteroide hacia abajo en coordenadas globales (sin afectar la rotación visual)
        transform.position += Vector3.right * speed * Time.deltaTime;

        // Rota el asteroide en su propio eje para efecto visual
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
    }
        
    
    // Detecta colisiones con otros objetos
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Asteroide colisionó con: {collision.gameObject.name} - Tag: {collision.gameObject.tag}");

        // Verifica si el objeto que colisionó tiene el tag "Laser"
        if (collision.gameObject.CompareTag("Laser"))
        {
            Debug.Log("Asteroide detectó colisión con Laser");
            // Destruye el asteroide
            Destroy(gameObject);
            // Instancia la explosión de colisión
            if (collisionExplosion != null)
            {
                Instantiate(collisionExplosion, transform.position, Quaternion.identity);
            }
            // Opcionalmente, también destruye el láser
            Destroy(collision.gameObject);
        }
        // Aquí puedes agregar más lógica para manejar colisiones con otros objetos
        /*
        else if (collision.gameObject.CompareTag("Player"))
        {
            // Lógica para manejar colisión con el jugador
            Debug.Log("Asteroide colisionó con el jugador");

            // Por ejemplo, podrías destruir el asteroide o aplicar daño al jugador
            // 
            Destroy(collision.gameObject);
        }
        */
    }
}
