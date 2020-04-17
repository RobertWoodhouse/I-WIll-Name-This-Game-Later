using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public float time = 5.0f, respawnTime = 5.0f;

    [SerializeField]
    private GameObject[] _obstacles;

    [SerializeField]
    private GameObject _obstacleSpawnPoint;

    void Start() => SpawnObject(_obstacleSpawnPoint);

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
        GameObject obstacleClone = Instantiate(_obstacles[Random.Range(0, _obstacles.Length)], new Vector3(0f, 4f), Quaternion.identity);
        int rangeIndex;

        if (transform.parent != null)
        {
            //rangeIndex = rand.Next(_obstacleClone.GetComponent<Obstacle>().spawnXPosRange.Length);
            rangeIndex = rand.Next(obstacleClone.GetComponentInParent<ObjectSpawnPos>().SpawnXPosRange.Length);

            //_obstacleClone.transform.position = new Vector3(_obstacleClone.GetComponent<Obstacle>().spawnXPosRange[rangeIndex], pos.transform.localPosition.y);
            obstacleClone.transform.position = new Vector3(obstacleClone.GetComponentInParent<ObjectSpawnPos>().SpawnXPosRange[rangeIndex], pos.transform.localPosition.y);
        }
        else
        {
            rangeIndex = rand.Next(obstacleClone.GetComponent<ObjectSpawnPos>().SpawnXPosRange.Length);
            obstacleClone.transform.position = new Vector3(obstacleClone.GetComponent<ObjectSpawnPos>().SpawnXPosRange[rangeIndex], pos.transform.localPosition.y);
        }
    }
}