using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    [SerializeField] private GameStateController stateController;

    /// <summary>
    /// Мячик пересек триггер, обозначающий учпешное завершение уровня
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            stateController.isFinished = true;
        }
    }
}
