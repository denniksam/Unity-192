using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    private GameObject MenuContent;

    void Start()
    {
        MenuContent = GameObject.Find(nameof(MenuContent));
        if (MenuContent.activeInHierarchy) Time.timeScale = 0f;
    }

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = MenuContent.activeInHierarchy ? 1.0f : 0.0f;
            MenuContent.SetActive( !MenuContent.activeInHierarchy);
        }
    }

    public void MenuButtonClick()
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
 */