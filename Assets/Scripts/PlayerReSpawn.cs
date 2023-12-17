using UnityEngine;

public class PlayerReRespawn : MonoBehaviour
{
    [SerializeField] public Vector3 SpawnPoint;
    public void ReSpawn()
    {
        transform.position = SpawnPoint;
    }
}
