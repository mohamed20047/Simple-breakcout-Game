using UnityEngine;
using System.IO;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;

    public int highScore = 0;
    public string highScorePlayerName;
    public string currentPlayerName;

    private void Awake()
    {
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }
    public void UpdateHighScore(int score)
    {
        highScorePlayerName = currentPlayerName;
        highScore = score;
        SaveHighScore();
    }
    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string playerName;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.playerName = highScorePlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScorePlayerName = data.playerName;
        }
    }
}
