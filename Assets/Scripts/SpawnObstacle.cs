using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public float time = 5.0f;
    public float respawnTime = 10.0f;

    private float[] _spawnXPosRange; // TODO add spawn range for specific obstacles

    [SerializeField]
    private GameObject[] _obstacles;

    [SerializeField]
    private GameObject _obstacleSpawnPoint;

    void Start()
    {
        _spawnXPosRange = new[] { -1.94f, -1.212f, -0.484f, 0.244f, 0.972f /*, 1.7f*/ };
        SpawnObject(_obstacleSpawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0f)
        {
            SpawnObject(_obstacleSpawnPoint);
            time = respawnTime;
        }
        else time -= Time.deltaTime;
    }

    public void SpawnObject(GameObject pos)
    {
        System.Random rand = new System.Random();
        int index = rand.Next(_spawnXPosRange.Length);
        Instantiate(_obstacles[Random.Range(0, _obstacles.Length)], new Vector3(_spawnXPosRange[index], pos.transform.localPosition.y), Quaternion.identity);
    }
}
