using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// однин з Об'єктів-станів, який поширює/концентрує дані з ігрової статистики
public class GameStat : MonoBehaviour
{
    private float _gameTime;
    private int   _gameScore;
    private float _gameEnergy;    // energy level [0..1]

    [SerializeField]
    private TMPro.TextMeshProUGUI clock;   // посилання на годинник у GameStat
    [SerializeField]
    private TMPro.TextMeshProUGUI score;   // посилання на Score(Text) у GameStat
    [SerializeField]
    private UnityEngine.UI.Image energy;   // посилання на Image змінного наповнення

    public float GameTime { 
        get => _gameTime;
        set
        {
            _gameTime = value;
            UpdateUiTime();
        }
    }    
    public int GameScore
    {
        get => _gameScore;
        set
        {
            _gameScore = value;
            UpdateUiScore();
        }
    }
    public float GameEnergy
    {
        get => _gameEnergy;
        set
        {
            _gameEnergy = value;
            UpdateUiEnergy();
        }
    }


    void Start()
    {
        GameEnergy = energy.fillAmount;
    }
    void LateUpdate()
    {
        GameTime += Time.deltaTime;
    }
    private void UpdateUiTime()
    {
        int t = (int)_gameTime;
        int h = t / 3600;
        int m = (t % 3600) / 60;
        int s = t % 60;
        int d = (int)((_gameTime - t) * 10);

        clock.text = $"{h:00}:{m:00}:{s:00}.{d}";
    }
    private void UpdateUiScore()
    {
        score.text = $"{_gameScore:0000}";
    }
    private void UpdateUiEnergy()
    {
        if(_gameEnergy >= 0 && _gameEnergy <= 1)
        {
            energy.fillAmount = _gameEnergy;
        }
        else
        {
            Debug.LogError($"gameEnergy set error (out of range) {_gameEnergy}");
        }
    }
}
