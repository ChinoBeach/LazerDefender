using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] float fltSceneLoadDelay = 2f;
   public void LoadGame()
    {
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

