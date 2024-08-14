using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestScorePanel : MonoBehaviour
{

    [SerializeField] private TMP_Text highscoreText;

    private void OnEnable()
    {
        string highscoreLists = "";
        int dataCount = GameData.Instance.DataCount();
        for(int i=0; i<dataCount; i++)
        {
            GameScore gameScore = GameData.Instance.GetHightScore(i);
            highscoreLists += $"{gameScore.name} : {gameScore.score} \n";
        }
        highscoreText.text = highscoreLists;
    }
    
}
