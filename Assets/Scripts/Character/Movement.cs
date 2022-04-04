using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private Rigidbody2D _rb;
    public Animator animator;
    [SerializeField] AnimatedCharacterSelection _animatedCharacterSelection;

    [SerializeField] private float _speed = 5f;
    [SerializeField] private Vector2 _movement;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _movement.x = Input.GetAxis("Horizontal");
        _movement.y = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(_movement.x+_movement.y));

        if(_movement.x>0)
        {
            _animatedCharacterSelection.ToggleXDirection(1);
        }
        else if(_movement.x < 0)
        {
            _animatedCharacterSelection.ToggleXDirection(-1);
        }

    }
    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * _speed * Time.fixedDeltaTime);
    }
}
