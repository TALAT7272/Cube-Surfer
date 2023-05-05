using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text levelText;
    private const string levelStr = "Level ";

    private void Start()
    {
        SetLevelText();
    }

    public void SetLevelText()
    {
        int levelIndex = LevelManager.Instance.CurrentLevel() + 1;
        levelText.text = levelStr + (levelIndex);
    }
}
