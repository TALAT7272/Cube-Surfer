using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStackController : Singleton<PlayerStackController>
{
    public List<Transform> cubes;

    private const string cubeStr = "Cube";
    private const string obstacleStr = "Obstacle";
    private const string untaggedStr = "StackCube";
    private const string diamondStr = "Diamond";
    private const string finishStr = "Finish";

    private int diamondCount;

    public void OnStackCube(Collider other)
    {
        if (other.CompareTag(cubeStr))
        {
            other.tag = untaggedStr;
            other.transform.SetParent(transform);
            other.transform.position = new Vector3(transform.position.x, -1.72f, transform.position.z);
            transform.position += Vector3.up;
            cubes.Add(other.transform);
        }
    }
    public void OnCollectableToCube(Collider other)
    {
        if (other.CompareTag(diamondStr))
        {
            diamondCount += 1;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag(finishStr))
        {
            Debug.Log("Finish");
            LevelManager.Instance.NextLevelData();
            LevelManager.Instance.RestartScene();
        }
    }
}
