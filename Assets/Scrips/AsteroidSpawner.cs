using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Asteroid Settings")]
    public GameObject[] asteroidPrefabs; // Matriz de prefabs de asteroides
    
    [Header("Spawn Settings")]
    public int maxAsteroids = 10;
    public float spawnRadius = 20f;
    public float spawnInterval = 2f;
    
    private float lastSpawnTime;
    
    [Header("Fixed Position Settings")]
    public float xPos;
    public float yPos;
    public float zPos;
    public float zRangeMin = -5f;
    public float zRangeMax = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSpawnTime >= spawnInterval)
    {
        if (GameObject.FindGameObjectsWithTag("Asteroid").Length < maxAsteroids)
        {
            SpawnAsteroid();
            lastSpawnTime = Time.time;
        }
    }
    }
    
    // Método para obtener un prefab aleatorio de la matriz
    GameObject GetRandomAsteroidPrefab()
    {
        if (asteroidPrefabs.Length == 0)
        {
            Debug.LogWarning("No hay prefabs de asteroides asignados!");
            return null;
        }
        
        int randomIndex = Random.Range(0, asteroidPrefabs.Length);
        return asteroidPrefabs[randomIndex];
    }
    
    // Método para spawnear un asteroide
    void SpawnAsteroid()
    {
        GameObject prefab = GetRandomAsteroidPrefab();
        if (prefab != null)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Instantiate(prefab, spawnPosition, Random.rotation);
        }
    }
    
    // Método para obtener una posición aleatoria de spawn
    Vector3 GetRandomSpawnPosition()
    {
        // X e Y son fijas, solo Z varía en el rango especificado
        float x = xPos;
        float y = yPos;
        float z = Random.Range(zRangeMin, zRangeMax);
        return new Vector3(x, y, z);
    }
}
