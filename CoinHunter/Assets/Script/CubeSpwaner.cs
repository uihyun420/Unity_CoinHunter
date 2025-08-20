using UnityEngine;

public class CubeSpwaner : MonoBehaviour
{
    public GameObject cubePrefab;

    public Vector3 spawnMin = new Vector3(-20, 1, 20);
    public Vector3 spawnMax = new Vector3(20, 1, 20);

    public int cubePerSpawn = 2;
    public float minInterval = 1f;
    public float maxInterval = 2f;

    private float interval;
    private float timer;

    private void OnEnable()
    {
        timer = 0;
        interval = Random.Range(minInterval, maxInterval);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            for (int i = 0; i < cubePerSpawn; i++)
            {
                Vector3 spawnPos = new Vector3
                (
                    Random.Range(spawnMin.x, spawnMax.x),
                    Random.Range(spawnMin.y, spawnMax.y),
                    Random.Range(spawnMin.z, spawnMax.z)
                );
                Instantiate(cubePrefab, spawnPos, Quaternion.identity);
            }
            timer = 0f;
            interval = Random.Range(minInterval, maxInterval);
        }
    }
}
