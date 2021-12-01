using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public Text bestScoreText;
    public int bestScore;
    public string bestPlayerName;
    public InputField input;

    public void Start()
    {
        GameManager.Instance.LoadHighScore();

        bestPlayerName = GameManager.Instance.bestPlayerName;
        bestScore = GameManager.Instance.bestScore;

        if (GameManager.Instance.bestScore != 0)
        {
            bestScoreText.text = "Best Score : " + bestPlayerName + " : " + bestScore;

            Debug.Log(Application.persistentDataPath);
        }

    }

    public void StartGame()
    {
        GameManager.Instance.currentPlayerName = input.text;
        Debug.Log("entered name: " + GameManager.Instance.currentPlayerName);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
