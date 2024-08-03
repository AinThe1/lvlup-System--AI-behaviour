using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int _speedMove;
    [SerializeField] private Joystick _joystick;
    private Rigidbody _rb; 
    private Vector2 _directionMove;
    
    private void Start() => _rb = GetComponent<Rigidbody>();

    private void FixedUpdate() => Move();

    private void Move()
    {
        _directionMove = _joystick.Direction;
        
        if(_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {
            _directionMove.x = Input.GetAxisRaw("Horizontal");
            _directionMove.y = Input.GetAxisRaw("Vertical");
        }

        _rb.velocity = new Vector3(_directionMove.x, 0, _directionMove.y).normalized * _speedMove * Time.deltaTime;
    }
}
