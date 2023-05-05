using UnityEngine;

public class InputHandler : Singleton<InputHandler>
{
    private float _lastFrameFingerPositionX;
    private float deltaX;

    public float DeltaX { get => deltaX; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //  ilk doknuş
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            // dokunulduğunda
            deltaX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // eli bırakınca
            deltaX = 0f;
        }
    }
}
