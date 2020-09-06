using UnityEngine;

public class LevelFailed : MonoBehaviour
{
    [SerializeField] private GameStateController stateController;
    
    /// <summary>
    /// Мячик пересек нижнюю границу, теперь нужно проверить завершил ли он уровень
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            stateController?.ThePlayerFacesALosingTrigger();
        }
    }
}
