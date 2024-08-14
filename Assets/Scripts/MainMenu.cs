using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highscoreText;

    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private Button startButton;

    [SerializeField] private Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(OnStartBtnPressed);
        quitButton.onClick.AddListener(OnQuitBtnPressed);

        GameData.LoadFromFile();

        if(GameData.Instance.DataCount() > 0){
            GameScore topScore = GameData.Instance.GetHightScore(0);
            highscoreText.text = $"HighScore -> {topScore.name} : {topScore.score}";
        }

    }

    void OnStartBtnPressed()
    {
        GameData.currentPlayerName = nameInputField.text;
        SceneManager.LoadScene("main");
    }

    void OnQuitBtnPressed()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
