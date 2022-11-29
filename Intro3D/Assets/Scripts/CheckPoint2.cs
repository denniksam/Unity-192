using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint2 : MonoBehaviour
{
    public static bool isActivated;

    [SerializeField]
    private UnityEngine.UI.Image countdown;
    private const float startTime = 25;   
    private float countdownTime;

    void Start()
    {
        CheckPoint2.isActivated = false;
        countdownTime = startTime;
    }

    void Update()
    {
        if (CheckPoint2.isActivated)
        {
            countdownTime -= Time.deltaTime;   // зворотній відлік

            if (countdownTime < 0)             // час вичерпано
            {
                GameStat.PassCheckpoint2(false);
                this.gameObject.SetActive(false);
            }
            else
            {
                GameStat.Checkpoint2Fill =
                countdown.fillAmount =           // встановлюємо процент залишку
                    countdownTime / startTime;   //  як заповнення image
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
        GameStat.PassCheckpoint2(true);
    }
}
/* Д.З. Відображення інформації (3D)
 * Реалізувати дію на чекпоїнті 2 (прибирати ворота 2)
 * Реалізувати чекпоїнт 3 (фініш):
 *  - активація при наближенні
 *  - зворотній відлік
 *  = але: при закінчені часу не прибирати (зі сцени), 
 *     а враховувати у скорінгу момент фінішу: більше балів при вчасному проходжені
 * * додати поле для відображення балів (score)
 * ** скласти та реалізувати алгоритм підрахунку балів з урахуванням
 *     часу проходження чекпоїнтів та гри в цілому.
 *  
 */