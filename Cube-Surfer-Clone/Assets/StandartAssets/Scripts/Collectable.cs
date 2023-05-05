using UnityEngine;

public class Collectable : MonoBehaviour
{
    private bool isStack;
    public bool IsStack { get => isStack; set => isStack = value; }

    private void Start()
    {
        isStack = true;
    }
}
