using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : MonoBehaviour
{
    [SerializeField]                      // поля [SerializeField] та public
    private float ForceMagnitude = 10f;   // доступні для зміни через UnityEditor
                                          // причому Editor приорітетніше
    [SerializeField]
    private TMPro.TextMeshProUGUI CollisionsTMPro;

    private Rigidbody2D Rigidbody2D;
    private Vector2 ForceDirection;

    void Start()
    {
        Rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");  // "стрілки", ASDW, джойстик
        float inputY = Input.GetAxis("Vertical");    //

        ForceDirection = new Vector2(inputX * ForceMagnitude, inputY * ForceMagnitude);
        Rigidbody2D.AddForce(ForceDirection);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Обробник події CollisionEnter, яка виникає на початку виникнення
        // колізії - зіткнення колайдерів. 
        // other.gameObject - посилання на об'єкт, з яким відбулось зіткнення

        // Debug.Log("Collision: " + other.gameObject.name);
        CollisionsTMPro.text = (int.Parse(CollisionsTMPro.text) + 1).ToString();
        /* Д.З. Реалізувати підрахунок "балів" за зіткнення:
         * якщо рухомий об'єкт (биток) штовхає +1
         * якщо ішний об'єкт +2
         * зіткнення зі стіною -1
         * Відобразити бали та час гри на екрані
         */
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Обробник події TriggerEnter, яка виникає на початку перетину
        // колайдерів, принаймні один з яких є IsTrigger
        // Такі колайдери не обробляются як зіткнення (об'єкти не зміщуються)
        // а лише формують подію (і запускають обробник)
        // Подію отримують обидва учасники, навіть якщо другий колайдер
        // звичайний (а не IsTrigger)

        Debug.Log("Trigger: " + other.gameObject.name);

        other.gameObject.transform.position =
            new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 3.5f));
        /* Д.З. Створити та додати на поле ще ігові об'єкти
         * - з звичайним колайдером
         * - з тригер-колайдером
         * Забезпечити виведенні відомостей про зіткнення у консоль
         */
    }
}
