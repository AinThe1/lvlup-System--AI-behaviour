using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    private PlayerStages _player;
    private EnemyAI[] _enemyAI;
    [SerializeField] private Canvas _menuDie;
    private void Start()
    {
        _player = GetComponent<PlayerStages>();
        _enemyAI = FindObjectsOfType<EnemyAI>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyAI EnemyStage2))
        {
            if (_player.Stage < EnemyStage2.Stage)
            {
                Destroy(gameObject);
                _menuDie.enabled = true;
            }                   
        }      
    }

    private void OnDestroy()
    {       
        foreach(EnemyAI enemyAI in _enemyAI) 
            Destroy(enemyAI);
    }
}
