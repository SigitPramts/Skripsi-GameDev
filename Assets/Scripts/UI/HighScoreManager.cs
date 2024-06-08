using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class HighScoreManager : SingletonMonobehaviour<HighScoreManager>
{
    private HighScores highScores = new HighScores();

    protected override void Awake()
    {
        base.Awake();

        LoadScores();
    }

    private void LoadScores()
    {
        BinaryFormatter bf = new BinaryFormatter();

        if (File.Exists(Application.persistentDataPath + "/DungeonEscapeHighScores.dat"))
        {
            ClearScoreList();

            FileStream file = File.OpenRead(Application.persistentDataPath + "/DungeonEscapeHighScores.dat");

            highScores = (HighScores)bf.Deserialize(file);

            file.Close();
        }
    }

    private void ClearScoreList()
    {
        highScores.scoresList.Clear();
    }

    public void AddScore(Score score, int rank)
    {
        highScores.scoresList.Insert(rank - 1, score);

        // Maintain the max number of scores to save
        if (highScores.scoresList.Count > Settings.numberOfHighScoresToSave)
        {
            highScores.scoresList.RemoveAt(Settings.numberOfHighScoresToSave);
        }

        SaveScores();
    }

    private void SaveScores()
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/DungeonEscapeHighScores.dat");

        bf.Serialize(file, highScores);

        file.Close();
    }

    public HighScores GetHighScores()
    {
        return highScores;
    }

    public int GetRank(long playerScore)
    {
        // If there are no scores currently in the list - then this score must be ranked 1 - then return
        if (highScores.scoresList.Count == 0) return 1;

        int index = 0;

        // Loop through scores in list to find the rank of this score
        for (int i = 0; i < highScores.scoresList.Count; i++)
        {
            index++;

            if (playerScore >= highScores.scoresList[i].playerScore)
            {
                return index;
            }
        }

        if (highScores.scoresList.Count < Settings.numberOfHighScoresToSave)
            return (index + 1); 

        return 0;
    }
}
