using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    // state
    public static int ControlType;        // Continual(0)-Discrete(1)-Mixed(2)
    public static float GameDifficulty;   // 0..1 value

    // vars
    [SerializeField]
    private GameObject MenuContainer;
    [SerializeField]
    private TMPro.TextMeshProUGUI MenuButtonText;
    [SerializeField]
    private TMPro.TextMeshProUGUI MessageText;

    private GameStat gameStat;   // посилання на скрипт класу GameStat на холсті "GameStat"

    void Start()
    {
        ControlType = 0;
        GameDifficulty = .5f;
        gameStat =                        // Шукаємо в ієрархії об'єкт з іменем 
            GameObject.Find("GameStat")   // "GameStat" (це Canvas з ігровою статистикою)
            .GetComponent<GameStat>();    // у ньому - компонент GameStat (скрипт класу GameStat)

        ShowMenu(MenuContainer.activeInHierarchy, "Start");
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMenu( !MenuContainer.activeInHierarchy, 
                message: "Paused on time: " + 
                gameStat.GameTime   // посилання на час у об'єкті-стані GameStat
            );
        }
    }

    private void ShowMenu(bool isVisible = true, string buttonText = "Resume", string message="")
    {
        if (isVisible)  // показуємо меню, зупиняємо час
        {
            MenuContainer.SetActive(true);
            Time.timeScale = 0;
            MenuButtonText.text = buttonText;
            MessageText.text = message;
        }
        else  // прибираємо меню
        {
            MenuContainer.SetActive(false);
            Time.timeScale = 1;
        }
    }

    // ----------------- обробники подій UI  ---------------------------
    public void MenuButtonClick()
    {
        ShowMenu(false);
    }
    public void ControlTypeChanged(int index)  // Dropdown
    {
        // Debug.Log(index);
        GameMenu.ControlType = index;
    }
    public void DifficultyChanged(float value)
    {
        // Debug.Log(value);
        GameMenu.GameDifficulty = value;
    }
}
/* Time.timeScale - змінює хід часу.  
 *  1 - нормальний хід
 *  0 - зупинка часу (всі фізичні процеси та Time.deltaTime множаться на 0)
 *  0..1 - "повільне програвання"
 *  >1 - прискорене програвання
 *  
 *  !! 0 - не зупиняє скриптинг, всі Update виконуються, якщо у них
 *         є геометричні перетворення, які не залежать від Time.deltaTime,
 *         то вони продовжують виконуватись
 */