using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public static string currentPlayerName;
    private static GameData _instance;

    public static GameData Instance{
        get { 
            if( _instance == null )
                _instance = new GameData();

            return _instance; 
        }
    }

    public static void LoadFromFile()
    {
        string saveFile = Application.persistentDataPath + "/highscore.json";
        string jsonData = File.ReadAllText(saveFile, System.Text.Encoding.UTF8);
        _instance = JsonUtility.FromJson<GameData>(jsonData);
    }

    public void SaveToFile()
    {
        string saveFile = Application.persistentDataPath + "/highscore.json";
        string jsonData = JsonUtility.ToJson(GameData.Instance);

        File.WriteAllText(saveFile, jsonData);
    }

    private GameData()
    {
        highScore = new List<GameScore>();
    }

    public void AddHighScore(string name, int score)
    {
        GameScore newScore = new GameScore(name,score);
        highScore.Add(newScore);
        highScore.Sort();

        if(highScore.Count > 5)
            highScore.Remove(highScore[5]);
    }

    public GameScore GetHightScore(int index)
    {
        return highScore[index];
    }

    public int DataCount()
    {
        return highScore.Count;
    }

    [SerializeField] private List<GameScore> highScore;
}

[System.Serializable]
public class GameScore : IComparable<GameScore>
{

    public GameScore(string name, int score)
    {
        this._name = name;
        this._score = score; 
    }
    [SerializeField] private string _name;
    [SerializeField] private int _score;

    public string name {get { return _name; } }
    public int score {get { return _score; } }

    public int CompareTo(GameScore other)
    {
        return other.score.CompareTo(score);
    }
}
