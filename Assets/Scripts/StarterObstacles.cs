using UnityEngine;

public class StarterObstacles : MonoBehaviour
{
    public static bool IsStarterDestroyed;

    void Start()
    {
        IsStarterDestroyed = false;
    }

    void Update()
    {
        SwitchOnObstacleSpawn();
    }

    public void SwitchOnObstacleSpawn(string objectTag)
    {
        var count = GameObject.FindGameObjectsWithTag(objectTag).Length;
        if (count <= 0) IsStarterDestroyed = true;
    }

    public void SwitchOnObstacleSpawn()
    {
        var count = GameObject.FindGameObjectsWithTag("StarterObstacles").Length + GameObject.FindGameObjectsWithTag("StarterExpPower").Length + GameObject.FindGameObjectsWithTag("StarterExpSpeed").Length;
        if (count <= 0) IsStarterDestroyed = true;
    }
}
