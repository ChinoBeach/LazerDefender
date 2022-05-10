using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int intScore;
    static ScoreKeeper instance;
    void Awake()
    {
        ManageSingleton();
    }
    void ManageSingleton()
    {

        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        return intScore;
    }

    public void ModifyScore(int intValue)
    {
        intScore += intValue;
        Mathf.Clamp(intScore, 0, int.MaxValue);
        Debug.Log(intScore);
    }

    public void ResetScore()
    {
        intScore = 0;
    }
}
