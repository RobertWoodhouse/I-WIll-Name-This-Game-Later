using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public float time = 5.0f, respawnTime = 5.0f;

    //private float[] _spawnXPosRange = new[] { -1.94f, -1.212f, -0.484f, 0.244f, 0.972f }; // TODO add spawn range for specific obstacles

    [SerializeField]
    private GameObject[] _obstacles;

    [SerializeField]
    private GameObject _obstacleSpawnPoint;

    void Start()
    {
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
        GameObject _obstacleClone = Instantiate(_obstacles[Random.Range(0, _obstacles.Length)], new Vector3(0f, 4f), Quaternion.identity);
        int rangeIndex = rand.Next(_obstacleClone.GetComponent<Obstacle>().spawnXPosRange.Length);
        print("Spawn range = " + _obstacleClone.GetComponent<Obstacle>().spawnXPosRange.Length + " for " + _obstacleClone.GetComponent<Obstacle>().name);
        _obstacleClone.transform.position = new Vector3(_obstacleClone.GetComponent<Obstacle>().spawnXPosRange[rangeIndex], pos.transform.localPosition.y);
    }
}