using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerStages : MonoBehaviour
{
    [HideInInspector] private int _stage;
    public int Stage { get => _stage; }

    [SerializeField] private GameObject[] _prefabFormPlayer;
    [SerializeField] private Canvas MenuWin;
    private GameObject _cloneFormPlayer1;
    private GameObject _cloneFormPlayer2;

    private int _killedEnemyStage1;
    private int _killedEnemyStage2;
    private int _killedEnemyStage3;

    private void Start()
    {
        _stage = 1;
        UpdateStages();
    }


    public void UpdateStages()
    {
        switch (_stage)
        {          
            case 1:
                _cloneFormPlayer1 = Instantiate(_prefabFormPlayer[0],transform);
                break;
            case 2:
                _cloneFormPlayer2 = Instantiate(_prefabFormPlayer[1],transform);
                Destroy(_cloneFormPlayer1);
                break;
            case 3:
                Instantiate(_prefabFormPlayer[2],transform);
                Destroy(_cloneFormPlayer2);
                break;
        }           
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyAI EnemyStage1))
        {
            Destroy(collision.gameObject);
            _killedEnemyStage1++;
            if (_killedEnemyStage1 == 10)
            {
                _stage = 2;
                UpdateStages();
            }
        }

        if (_stage >= 2 && collision.gameObject.TryGetComponent(out EnemyAI EnemyStage2))
        {
            Destroy(collision.gameObject);
            _killedEnemyStage2++;
            if (_killedEnemyStage2 == 10)
            {
                _stage = 3;
                UpdateStages();
            }
        }

        if (_stage >= 3 && collision.gameObject.TryGetComponent(out EnemyAI EnemyStage3))
        {
            Destroy(collision.gameObject);
            _killedEnemyStage3++;
            if (_killedEnemyStage3 == 10)
            {
                MenuWin.enabled = true;
                Destroy(gameObject);
            }
            
        } 
    }
}
