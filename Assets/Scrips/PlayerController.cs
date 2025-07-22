using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 65f;
    public float suavizado = 6f; // Mayor valor = respuesta m�s r�pida, menor valor = m�s "resbaladizo"
    public float xRange;
    public float zRange;
    public float inclinacionMax = 30f; // Valor de inclinaci�n para el movimiento
    public GameObject explosionPrefab;

    private Vector3 velocidadActual = Vector3.zero;

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        float anguloZ = -inputX * inclinacionMax; // C�lculo del ��ngulo Z basado en inputX
        // Movimiento basado en input
        Vector3 direccionDeseada = new Vector3(inputX, 0f, inputY).normalized;

        // Adaptar la direcci�n deseada por la rotaci�n -90�
        direccionDeseada = Quaternion.Euler(0, -90, 0) * direccionDeseada;

        // Crear rotación deseada (asumiendo que no rota en X ni Y)
        Quaternion rotacionDeseada = Quaternion.Euler(0f, -90f, anguloZ); // -90 en Y mantiene la rotación base

        // Suavizar la rotación con Lerp o Slerp
        transform.rotation = Quaternion.Lerp(transform.rotation, rotacionDeseada, Time.deltaTime * 5f);

        // Interpolaci�n hacia la nueva direcci�n
        velocidadActual = Vector3.Lerp(velocidadActual, direccionDeseada * velocidad, Time.deltaTime * suavizado);

        // Aplicar movimiento
        transform.Translate(velocidadActual * Time.deltaTime, Space.World);

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }


        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        else if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }



    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("Jugador colisionó con un asteroide");
            // Instancia la explosión de colisión
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }
            // Destruye el jugador
            Destroy(gameObject);
        }
    }

}
