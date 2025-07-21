using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 65f;
    public float suavizado = 6f; // Mayor valor = respuesta m�s r�pida, menor valor = m�s "resbaladizo"
    public float xRange;
    public float zRange;

    private Vector3 velocidadActual = Vector3.zero;

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // Movimiento basado en input
        Vector3 direccionDeseada = new Vector3(inputX, 0f, inputY).normalized;

        // Adaptar la direcci�n deseada por la rotaci�n -90�
        direccionDeseada = Quaternion.Euler(0, -90, 0) * direccionDeseada;

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

}
