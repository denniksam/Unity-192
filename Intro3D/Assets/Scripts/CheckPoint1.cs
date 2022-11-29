using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint1 : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image countdown;
    const float startTime = 5;   // 5 секунд на "життя" чекпоінта
    private float countdownTime;

    void Start()
    {
        countdownTime = startTime;   // початкова ініц. таймера
    }

    void Update()
    {
        countdownTime -= Time.deltaTime;   // зворотній відлік
        
        if (countdownTime < 0)             // час вичерпано
        {
            GameStat.PassCheckpoint1(false);
            this.gameObject.SetActive(false);
        }
        else
        {
            GameStat.Checkpoint1Fill =
            countdown.fillAmount =           // встановлюємо процент залишку
                countdownTime / startTime;   //  як заповнення image
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
        GameStat.PassCheckpoint1(true);
    }
}
