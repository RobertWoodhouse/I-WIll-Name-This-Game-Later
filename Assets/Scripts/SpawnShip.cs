using UnityEngine;

public class SpawnShip : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _ship;

    [SerializeField]
    private GameObject _shipSpawnPoint;

    private void Start() => SpawnObject();

    public void SpawnObject()
    {
        GameObject _shipClone = Instantiate(_ship[SelectShipController.SelectedShip], new Vector3(0f, 4f), Quaternion.identity);
        _shipClone.transform.position = new Vector3(_shipSpawnPoint.transform.localPosition.x, _shipSpawnPoint.transform.localPosition.y);
    }
}
