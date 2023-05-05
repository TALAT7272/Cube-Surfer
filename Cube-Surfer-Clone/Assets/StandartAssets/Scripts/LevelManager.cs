using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [Header("Levels")]
    [SerializeField] private Level[] levels;
    [SerializeField] private Level testLevel;
    public int levelIndex;

    private const string playerStr = "Player";

    private void Awake()
    {
        SetLevelIndex();
        LevelInit();
    }
    private void LevelInit()
    {
        Level levelObject = testLevel != null ? SpawnLevel(testLevel) : SpawnLevel(levels[levelIndex]);
    }
    private void SetLevelIndex()
    {
        levelIndex = PlayerPrefs.GetInt(playerStr);
        levelIndex = levelIndex == 4 ? 0 : levelIndex;
    }
    public int CurrentLevel() => levelIndex;
    private Level SpawnLevel(Level level) => Instantiate(level, level.transform.position, Quaternion.identity);
    public void NextLevelData() => PlayerPrefs.SetInt(playerStr, levelIndex + 1);
    public void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
