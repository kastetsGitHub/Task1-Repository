using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [Header("Move settings:")]
    [SerializeField] [Range(0, 100f)] private float _speed;

    [Header("Jump settings:")]
    [SerializeField] [Range(0, 5)] private float _distanceToGroundCheck;
    [SerializeField] private float _forceOfJump;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveForward() => transform.position += _speed * Time.deltaTime * transform.right;

    public void MoveBackward() => transform.position += _speed * Time.deltaTime * -transform.right;

    public void Jump()
    {
        if (IsGrounded())
        {
            _rigidbody.velocity = Vector2.up * _forceOfJump;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, _distanceToGroundCheck);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - _distanceToGroundCheck), Color.magenta);
    }
}
