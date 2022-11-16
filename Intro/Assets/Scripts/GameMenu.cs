using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuContainer;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuContainer.activeInHierarchy)  // меню активне --> деактивуємо
            {
                MenuContainer.SetActive(false);
                Time.timeScale = 1;
            }
            else                                  // меню не активне --> активуємо
            {
                MenuContainer.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
