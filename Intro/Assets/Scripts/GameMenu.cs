using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuContainer;

    [SerializeField]
    private TMPro.TextMeshProUGUI MenuButtonText;

    void Start()
    {
        if (MenuContainer.activeInHierarchy) Time.timeScale = 0;
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