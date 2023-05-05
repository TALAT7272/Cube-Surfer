using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private BoxCollider boxCollider;
    private const string stackCube = "StackCube";
    private const string untagged = "Untagged";
    private const string playerStr = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(stackCube))
        {
            boxCollider.isTrigger = false;
            var otherIndex = PlayerStackController.Instance.cubes.IndexOf(other.transform);
            var listCount = PlayerStackController.Instance.cubes.Count;

            if (otherIndex == -1)
            {
                return;
            }
            for (int i = listCount - 1; i > otherIndex; i--)
            {
                PlayerStackController.Instance.cubes[i].SetParent(null);
                PlayerStackController.Instance.cubes.Remove(PlayerStackController.Instance.cubes[i]);
            }
        }
        else if (other.CompareTag(playerStr))
        {
            LevelManager.Instance.RestartScene();
        }
    }
}
