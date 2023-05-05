using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float sensivitiy;
    [SerializeField] private float forwardSpeed;
    private float xClamp = 2.5f;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, 0.77f, transform.position.z);
        Debug.Log(transform.position);
    }

    private void Update()
    {
        PlayerMoving();
        PositionClamp();
    }
    private void PositionClamp()
    {
        float clamp = Mathf.Clamp(transform.position.x, -xClamp, xClamp);
        transform.position = new Vector3(clamp, transform.position.y, transform.position.z);
    }
    private void PlayerMoving()
    {
        var deltaMove = InputHandler.Instance.DeltaX;
        transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
        if (deltaMove == 0)
        {
            return;
        }

        transform.position += new Vector3(deltaMove * sensivitiy, 0, 0) * Time.deltaTime;
    }
}
