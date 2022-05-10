using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;


    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Wave")]
    [SerializeField] TextMeshProUGUI waveText;
    EnemySpawner enemyWave;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        enemyWave = FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }
    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
        waveText.text = enemyWave.GetCurrentWaveNumber().ToString();
    }
}
