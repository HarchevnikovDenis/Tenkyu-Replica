using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private Transform ball;
    [SerializeField] private Transform level;
    [SerializeField] private Vector3 offsetToSpawnLevel;

    /// <summary>
    /// Создагние следующего уровня
    /// </summary>
    public void SpawnLevel()
    {
        level.position = ball.position + offsetToSpawnLevel;
        level.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    }
}
