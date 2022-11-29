using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStat : MonoBehaviour
{
    #region Clock / GameTime
    private static TMPro.TextMeshProUGUI Clock;

    private static float _gameTime;
    public static float GameTime
    {
        get => _gameTime;
        set
        {
            _gameTime = value;
            UpdateTime();
        }
    }

    private static void UpdateTime()
    {
        int t = (int)_gameTime;
        GameStat.Clock.text = $"{t / 3600 % 24:00}:{t / 60 % 60:00}:{t % 60:00}.{(int)((_gameTime - t) * 10):0}";
    }
    #endregion

    #region Checkpoint1
    private static UnityEngine.UI.Image ImageCheckpoint1;
    private static float _checkpoint1Fill;
    public static float Checkpoint1Fill
    {
        get => _checkpoint1Fill;
        set
        {
            _checkpoint1Fill = value;
            UpdateCheckpoint1();
        }
    }
    private static void UpdateCheckpoint1()
    {
        if (Checkpoint1Fill >= 0 && Checkpoint1Fill <= 1)
        {
            ImageCheckpoint1.fillAmount = Checkpoint1Fill;
            ImageCheckpoint1.color = new Color(
                1 - Checkpoint1Fill,   // R
                Checkpoint1Fill,       // G
                0.1f                   // B
            );
        }
        else
            Debug.LogError("UpdateCheckpoint1: fillAmount = " + Checkpoint1Fill);
    }
    // зафіксувати проходження \ пропуск чекпоїнта
    public static void PassCheckpoint1(bool status)
    {
        Checkpoint1Fill = 0.96f;
        ImageCheckpoint1.color = status ? Color.green : Color.red;
    }
    #endregion

    #region Checkpoint2
    private static UnityEngine.UI.Image ImageCheckpoint2;
    private static float _checkpoint2Fill;
    public static float Checkpoint2Fill
    {
        get => _checkpoint2Fill;
        set
        {
            _checkpoint2Fill = value;
            UpdateCheckpoint2();
        }
    }
    private static void UpdateCheckpoint2()
    {
        if (Checkpoint2Fill >= 0 && Checkpoint2Fill <= 1)
        {
            ImageCheckpoint2.fillAmount = Checkpoint2Fill;
            ImageCheckpoint2.color = new Color(
                1 - Checkpoint2Fill,   // R
                Checkpoint2Fill,       // G
                0.1f                   // B
            );
        }
        else
            Debug.LogError("UpdateCheckpoint2: fillAmount = " + Checkpoint2Fill);
    }
    // зафіксувати проходження \ пропуск чекпоїнта
    public static void PassCheckpoint2(bool status)
    {
        Checkpoint2Fill = 0.96f;
        ImageCheckpoint2.color = status ? Color.green : Color.red;
    }
    #endregion

    void Start()
    {
        GameStat.Clock = 
            GameObject.Find("Clock")
            .GetComponent<TMPro.TextMeshProUGUI>();

        // Debug.Log(nameof(GameStat.ImageCheckpoint1));
        GameStat.ImageCheckpoint1 =
            GameObject.Find(nameof(GameStat.ImageCheckpoint1))
            .GetComponent<UnityEngine.UI.Image>();

        GameStat.ImageCheckpoint2 =
           GameObject.Find(nameof(GameStat.ImageCheckpoint2))
           .GetComponent<UnityEngine.UI.Image>();
    }

    void LateUpdate()
    {
        GameStat.GameTime += Time.deltaTime;
    }

}
/* GameStat - один з об'єктів-станів, що дозволяє обмінюватись інформацією
 * з різними скриптами (у т.ч. зберігати чи відновлювати ігровий стан)
 * 
 * Ефект MVP: присвоєння на кшталт GameStat.GameTime = 10 має призвести до
 *   відображення часу на "екрані"
 */