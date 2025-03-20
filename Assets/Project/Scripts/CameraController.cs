using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
    [SerializeField] float sensitivity = 1;
    private SwipeZone swipeZone;
    private float yaw;
    private float pitch;

    [Inject]
    private void Construct(SwipeZone swipeZone)
    {
        this.swipeZone = swipeZone;
    }
    private void OnEnable()
    {
        swipeZone.Dragged += RotateCamera;
    }
    private void OnDisable()
    {
        swipeZone.Dragged -= RotateCamera;
    }
    private void RotateCamera(Vector2 dragDelta)
    {
        yaw -= dragDelta.x * sensitivity * Time.fixedDeltaTime;
        pitch += dragDelta.y * sensitivity * Time.fixedDeltaTime;

        pitch = Mathf.Clamp(pitch, -90, 90);

        Quaternion cameraRotation = Quaternion.Euler(pitch, yaw, 0);
        Quaternion parentRotation = Quaternion.Euler(0, yaw, 0);

        transform.rotation = cameraRotation;
        transform.parent.rotation = parentRotation;
    }
}
