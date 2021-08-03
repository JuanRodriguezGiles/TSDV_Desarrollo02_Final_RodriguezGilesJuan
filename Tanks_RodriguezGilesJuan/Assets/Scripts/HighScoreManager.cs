using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class HighScoreManager : MonoBehaviourSingletonPersistent<HighScoreManager>
{
    public List<int> highScores = new List<int>(5);

    void OnEnable()
    {
        GameManager.onGameOver += UpdateHighScores;

        if (!File.Exists("playerHighScores.dat")) return;
        FileStream fs;
        BinaryFormatter bf = new BinaryFormatter();
        fs = File.OpenRead("playerHighScores.dat");
        highScores = (List<int>)bf.Deserialize(fs);
        fs.Close();
    }
    void OnDisable()
    {
        GameManager.onGameOver -= UpdateHighScores;
    }
    void OnApplicationQuit()
    {
        FileStream fs;
        BinaryFormatter bf = new BinaryFormatter();
        fs = File.OpenWrite("playerHighScores.dat");
        bf.Serialize(fs, highScores);
        fs.Close();
    }
    void UpdateHighScores()
    {
        int score = GameManager.Instance.stats.score;
        if (highScores.Count < 5)
        {
            highScores.Add(score);
            highScores.Sort();
        }
        else
        {
            for (int i = 0; i < highScores.Count; i++)
            {
                if (score <= highScores[i]) continue;
                if (i - 1 >= 0)
                    highScores[i - 1] = highScores[i];
                highScores[i] = score;
            }
            highScores.Sort();
        }
    }
}