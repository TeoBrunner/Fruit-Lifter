using UnityEngine;
using Zenject;

public class MovementController : MonoBehaviour
{
    [SerializeField] float speed = 1;
    private Joystick joystick;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    [Inject]
    private void Construct(Joystick joystick)
    {
        this.joystick = joystick;
    }

    private void FixedUpdate()
    {
        Vector3 newVelocity = new();
        newVelocity = transform.forward * joystick.Vertical + transform.right * joystick.Horizontal;
        newVelocity *= speed * Time.fixedDeltaTime;
        newVelocity.y = rb.velocity.y;
        rb.velocity = newVelocity;
    }
}
