using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScreen : MonoBehaviour
{
    private GameObject SpawnPoint;

    void Start()
    {
        SpawnPoint = GameObject.Find("SpawnPoint");  // Пошук за іменем у ієрархії
    }

    void Update()
    {
        
    }

    // на об'єкті OutOfScreen має бути кінематичне тв.тіло та колайдер-тригер
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Destroy(other.gameObject);
    }
}
/* Проблема: наявність декількох симетричних колайдерів призводить до того, 
 * що подій генерується декілька і дія виконується кількаразово
 * Варіанти рішення:
 *  - (1) створити окремий колайдер, який гарантовано буде один, дати
 *     йому окремий тег та моніторити його
 *  - (2) відстежувати позицію об'єкта, якщо вона вже віддалена, то дія
 *     застосовувалась попередньо
 *     
    (1) if (other.gameObject.CompareTag("Tube"))
        {
            // Tube - ієрархічно підлеглий до Pipe, треба переносити батьківський об'єкт
            other.gameObject.transform.parent.position =   // посилання на батька - 
                SpawnPoint.transform.position;             // через transform.parent
        }   

    (2) if( (other.gameObject.transform.position // різниця
                - this.transform.position       //  векторів-позицій
            ).magnitude < 18 )                  // довжина вектора
        {
            other.gameObject.transform.Translate(Vector2.right * 18);
        }
 */

/* Перенесення чи Знищення/створення
 * При перенесенні
 *  + економія ресурсів - швидше
 *  + візуальний контроль - видно скільки об'єктів, як вони розташовані
 *  - необхідність переорганізовувати при зміні ігрового поля
 *  - важко керувати відстанню програмно
 *  - якщо об'єкт треба "reset", то це має викликати інший скрипт
 *  
 * При знищенні/створенні
 *  + перестворюються скрипти, об'єкти ініціалізуються
 *  
 *  
 *  Префаб - "збережений" об'єкт з усіма компонентами (у т.ч. скриптами, колайдерами,
 *   тегами і т.і.)
 */