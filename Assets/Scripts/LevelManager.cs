using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] float fltSceneLoadDelay = 2f;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("GamePlayScene");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver",fltSceneLoadDelay));
    }

    IEnumerator WaitAndLoad(string strSceneName, float fltDelay)
    {
        yield return new WaitForSeconds(fltDelay);
        SceneManager.LoadScene(strSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
       Application.Quit();
    }
}

