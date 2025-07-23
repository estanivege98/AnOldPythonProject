using UnityEngine;

public class MenuAsteroid : MonoBehaviour
{
    public float rotationSpeed;
    public float movementSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
        transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
    }
}
