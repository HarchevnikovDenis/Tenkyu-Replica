using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(FollowingCamera))]
public class GameStateController : MonoBehaviour
{
    [SerializeField] private BallController ballController;
    [SerializeField] private Text scoreText;
    [SerializeField] private LevelSpawner spawner;
    [SerializeField] private RampsRotator rotator;

    private new FollowingCamera camera;
    private Animator scoreTextAnimator;
    private int score;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            if(value < 0)
            {
                score = 0;
            }
            else
            {
                score = value;
            }

            if(score != 0)
            {
                scoreTextAnimator?.SetTrigger("ChangeScore");
            }
            scoreText.text = score.ToString();
        }
    }

    public bool isFinished { private get; set; }

    private void Awake()
    {
        camera = gameObject.GetComponent<FollowingCamera>();
        scoreTextAnimator = scoreText.gameObject.GetComponent<Animator>();
    }

    /// <summary>
    /// Мячик пересек нижнюю границу сцены
    /// </summary>
    public void ThePlayerFacesALosingTrigger()
    {
        if(isFinished)
        {
            // Игрок прошел уровень
            PlayerWon();
        }
        else
        {
            // Игрок проиграл
            PlayerLose();
        }
    }

    private void PlayerWon()
    {
        // Добавить счет
        Score++;
        // Сгенерировать заново трассу
        spawner.SpawnLevel();
        // Обновить переменную isFinished
        isFinished = false;
        ballController.MoveToLandingPoint();
    }

    private void PlayerLose()
    {
        // Остановить следование камеры
        camera.enabled = false;
        // Отключить возможность вращать рампы
        rotator.enabled = false;
    }
}
