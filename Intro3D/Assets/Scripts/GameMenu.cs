using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    private static GameObject MenuContent;
    private static TMPro.TextMeshProUGUI MenuMessage;
    private static TMPro.TextMeshProUGUI MenuButtonTitle;
    private static TMPro.TextMeshProUGUI MenuStatistics;

    void Start()
    {
        MenuContent     = GameObject.Find(nameof(MenuContent));
        MenuMessage     = GameObject.Find(nameof(MenuMessage))
                            .GetComponent<TMPro.TextMeshProUGUI>();
        MenuButtonTitle = GameObject.Find(nameof(MenuButtonTitle))
                            .GetComponent<TMPro.TextMeshProUGUI>();
        MenuStatistics  = GameObject.Find(nameof(MenuStatistics))
                            .GetComponent<TMPro.TextMeshProUGUI>();

        if (MenuContent.activeInHierarchy) 
            GameMenu.Show(MenuMessage.text, MenuButtonTitle.text);
    }

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (MenuContent.activeInHierarchy) GameMenu.Hide();
            else GameMenu.Show();
        }
    }

    public void MenuButtonClick()
    {
        GameMenu.Hide();
    }

    public static void Show(                   // GameMenu.Show()
        string messageText = "Game paused",    // GameMenu.Show("Checkpoint Gone")
        string buttonText = "Resume")          // GameMenu.Show("Game Over", "restart")
    {
        MenuContent.SetActive(true);

        // Messaging
        MenuMessage.text = messageText;
        MenuButtonTitle.text = buttonText;

        // Statistics
        MenuStatistics.text = $"Game Statistics:\n Time in game: {GameStat.GameTime:F1} s ";

        Time.timeScale = 0f;
    }
    public static void Hide()    // GameMenu.Hide()
    {
        MenuContent.SetActive(false);
        Time.timeScale = 1f;
    }
}
/* Меню гри (меню паузи)
 * Т.З. Меню відображається за допогою ESC
 * прибирається а) повторним натиском ESC б) кнопкою на меню
 * При відображенні меню надає інформацію про:
 * - ігрову статистику
 * - повідомлення
 * - має змогу змінити надпис кнопки
 * - містить елементи керування.
 * = а також зупиняє хід часу та керованість персонажем
 * Реалізувати можливість виклику меню з інших скриптів, при цьому
 *  передати відомості для повідомлення та надпис кнопки
 * Незалежно від виклику на меню має відображатись ігрова статистика:
 *  час гри
 *  статус чекпоїнтів
 *  накопичені бали
 *  відомості про кращі результати (рекорди)
 * Очікуваний вигляд:
 *  Game Statistics:
 *   Time in game:  31.2 s
 *   Checkpoint1:   passed @ 3.1 s
 *   Checkpoint2:   failed
 *   Checkpoint3:   in progress
 *   Total score:   100500 (**3rd best place)
 */