using UnityEngine;

public class PlayerTriggerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerStackController.Instance.OnStackCube(other);
        PlayerStackController.Instance.OnCollectableToCube(other);
    }
}
