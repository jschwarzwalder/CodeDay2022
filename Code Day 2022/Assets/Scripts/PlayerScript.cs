using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Animator animator;

    [SerializeField] private float speed = 10f;
    private Vector2 movement;

    private void Awake()
    {
    }

    private void Update()
    {
        GetMovementInput();
        SetAnimation();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetMovementInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
    }

    private void SetAnimation()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        if (movement.x == 0 && movement.y == 0)
            animator.SetBool("IsMoving", false);
        else
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.y);
        }
    }

    private void Move()
        => rigidBody.velocity = new Vector2(movement.x * speed, movement.y * speed);
}