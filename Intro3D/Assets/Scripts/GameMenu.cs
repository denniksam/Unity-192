using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public static bool SoundsEnabled { get; private set; }
    public static float SoundsVolume { get; private set; }

    private const string preferencesFilename = "Assets/Files/prefer.txt";

    private static GameObject MenuContent;
    private static TMPro.TextMeshProUGUI MenuMessage;
    private static TMPro.TextMeshProUGUI MenuButtonTitle;
    private static TMPro.TextMeshProUGUI MenuStatistics;

    private AudioSource backgroundMusic;

    private bool musicEnabled;
    private float musicVolume;

    void Start()
    {
        MenuContent     = GameObject.Find(nameof(MenuContent));
        MenuMessage     = GameObject.Find(nameof(MenuMessage))
                            .GetComponent<TMPro.TextMeshProUGUI>();
        MenuButtonTitle = GameObject.Find(nameof(MenuButtonTitle))
                            .GetComponent<TMPro.TextMeshProUGUI>();
        MenuStatistics  = GameObject.Find(nameof(MenuStatistics))
                            .GetComponent<TMPro.TextMeshProUGUI>();

        backgroundMusic = this.GetComponent<AudioSource>();

        // Налаштування звуків/музики: намагаємось зчитати з файла
        // якщо успішно, то відображаємо на меню, а якщо ні, то беремо значення з меню
        var SoundsToggle = GameObject.Find("SoundsToggle")
                            .GetComponent<UnityEngine.UI.Toggle>();
        var SoundsSlider = GameObject.Find("SoundsVolume")
                            .GetComponent<UnityEngine.UI.Slider>();
        var MusicToggle = GameObject.Find("MusicToggle")
                            .GetComponent<UnityEngine.UI.Toggle>();
        var MusicSlider = GameObject.Find("MusicVolume")
                            .GetComponent<UnityEngine.UI.Slider>();
        if (this.LoadPreferences())
        {
            SoundsToggle.isOn  = SoundsEnabled;
            SoundsSlider.value = SoundsVolume;
            MusicToggle.isOn   = musicEnabled;
            MusicSlider.value  = musicVolume;
        }
        else
        {
            SoundsEnabled = SoundsToggle.isOn;
            SoundsVolume  = SoundsSlider.value;
            musicEnabled  = MusicToggle.isOn;
            musicVolume   = MusicSlider.value;
        }
        this.UpdateMusicState();

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

    private void OnDestroy()
    {
        SavePreferences();
    }

    #region Event handlers
    public void MenuButtonClick()
    {
        GameMenu.Hide();
    }
    public void MusicToggleChanged(bool isChecked)
    {
        musicEnabled = isChecked;
        UpdateMusicState();
    }
    public void MusicVolumeChanged(float value)
    {
        musicVolume = value;
        UpdateMusicState();
    }
    public void SoundsToggleChanged(bool isChecked)
    {
        GameMenu.SoundsEnabled = isChecked;
    }
    public void SoundsVolumeChanged(float value)
    {
        GameMenu.SoundsVolume = value;
    }
    #endregion

    private void UpdateMusicState()
    {
        backgroundMusic.volume = musicVolume;
        if (musicEnabled)
        {
            if(!backgroundMusic.isPlaying) backgroundMusic.Play();
        }
        else if (backgroundMusic.isPlaying) backgroundMusic.Stop();
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

    private void SavePreferences()
    {
        System.IO.File.WriteAllText(preferencesFilename,
            $"{musicEnabled};{musicVolume};{SoundsEnabled};{SoundsVolume}"
        );
    }
    private bool LoadPreferences()
    {
        if (System.IO.File.Exists(preferencesFilename))
        {
            try
            {
                string[] data = System.IO.File.ReadAllText(preferencesFilename).Split(";");
                musicEnabled  = Convert.ToBoolean(data[0]);
                musicVolume   = Convert.ToSingle(data[1]);
                SoundsEnabled = Convert.ToBoolean(data[2]);
                SoundsVolume  = Convert.ToSingle(data[3]);
                return true;
            }
            catch(Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }
        return false;
    }
}
/* Д.З. Звуки: реалізувати відновлення параметрів налаштувань звуків при старті гри,
 *  відобразити налаштування у меню.
 *  Додати звук зникнення чекпоїнту
 */
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
 *   
 * -------------------------------------------
 * Налаштування (Preferences/Settings)
 * Керування звуком:
 *  - фонова музика (неперервна) -- вкл/викл + керування гучністю
 *  - звукові ефекти -- вкл/викл + керування гучністю
 * Реалізувати збереження налаштувань за фактом їх зміни, 
 * відтворювати дані при старті гри (збереження у файл)
 */