using UnityEngine;
using UnityEngine.InputSystem;

public class BoneDodger : MonoBehaviour
{
    [SerializeField]
    private float SPEED = 10;
    private float _points;
    private Vector3 _movement;
    private BattleManager _battleManager;
    private bool _topRestrict;
    private bool _bottomRestrict;
    private bool _leftRestrict;
    private bool _rightRestrict;
    private Vector3 _restrictedMovement;
    private float _startTime;
    [SerializeField]
    private float MAX_TIME = 10;

    public float Points { get => _points; set => _points = value; }

    void Start()
    {
        _startTime = Time.time;
        _restrictedMovement = Vector3.zero;
        _movement = Vector3.zero;
        _battleManager = (BattleManager)GameObject.Find("GameManager").GetComponent("BattleManager");
    }

    void FixedUpdate()
    {
        if (Time.time - _startTime > MAX_TIME)
        {
            _battleManager.CurrState = States.Player;
        }

        if (Mathf.Round(_movement.x) == Mathf.Round(_restrictedMovement.x))
        {
            transform.position = new(transform.position.x - (0.25F * _movement.x), transform.position.y, 0);
            _restrictedMovement.x = 0;
            _movement.x = 0;
        }
        if (Mathf.Round(_movement.y) == Mathf.Round(_restrictedMovement.y))
        {
            transform.position = new(transform.position.x, transform.position.y - (0.25F * _movement.y), 0);
            _restrictedMovement.y = 0;
            _movement.y = 0;
        }

        if (_movement != Vector3.zero)
        {
            Move();
        }
    }

    private void Move()
    {
        this.transform.Translate(_movement * SPEED * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bone")
        {
            _battleManager.CurrState = States.Player;
        } else
        {
            _restrictedMovement = _movement;
        }
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }
}
