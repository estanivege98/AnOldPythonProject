using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            
            // Opcionalmente, también destruye el láser
            Destroy(collision.gameObject);
        }
        // Aquí puedes agregar más lógica para manejar colisiones con otros objetos
        else if (collision.gameObject.CompareTag("Player")){
            // Lógica para manejar colisión con el jugador
            Debug.Log("Asteroide colisionó con el jugador");
            // Por ejemplo, podrías destruir el asteroide o aplicar daño al jugador
            //Destroy();
        }

    }
}
