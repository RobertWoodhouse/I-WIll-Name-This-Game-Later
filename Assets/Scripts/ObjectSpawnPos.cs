using UnityEngine;

public class ObjectSpawnPos : MonoBehaviour
{
    [SerializeField]
    private float[] spawnXPosRange = new[] { -1.94f, -1.212f, -0.484f, 0.244f, 0.972f };

    public float[] SpawnXPosRange { get => spawnXPosRange; set => spawnXPosRange = value; }
}
