using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public static float PipeShift = 2;   // розмах випадкових відхилень труби

    [SerializeField]
    private float JumpMagnitude = 10f;

    private Rigidbody2D Rigidbody2D;
    private Vector2 jumpForce;
    private float holdTime;
    private GameStat gameStat;   // посилання на скрипт класу GameStat на холсті "GameStat"


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        gameStat =                        // Шукаємо в ієрархії об'єкт з іменем 
            GameObject.Find("GameStat")   // "GameStat" (це Canvas з ігровою статистикою)
            .GetComponent<GameStat>();    // у ньому - компонент GameStat (скрипт класу GameStat)

        jumpForce = Vector2.up * JumpMagnitude;
        holdTime = 0;
    }

    void Update()
    {
        float jump;

        if (GameMenu.ControlType == 0)                // Continual
        {
            jump = Input.GetAxis("Jump");
            jump *= Time.deltaTime * 100;
            Rigidbody2D.AddForce(jumpForce * jump);
        }
        else if (GameMenu.ControlType == 1)           // Discrete
        {
            jump = Input.GetKeyDown(KeyCode.Space) ? 20 : 0;
            jump *= Time.deltaTime * 100;
            Rigidbody2D.AddForce(jumpForce * jump);
        }
        else                                          // Mixed
        {
            jump = 1.5f;        
            if (Input.GetKey(KeyCode.Space))
            {
                if(holdTime == 0) holdTime = 1;
                if(holdTime > 0) holdTime -= Time.deltaTime;
            }
            else holdTime = 0;
            jump *= Time.deltaTime * 100;  // Корекція на швидкість кадрів
            if( holdTime > 0) Rigidbody2D.AddForce(jumpForce * jump);
        }
        if (jump > 0)   // на пригання витрачається енергія
        {
            // Debug.Log(jump);
            gameStat.GameEnergy -= jump / 5000;
        }
    }

    private void LateUpdate()
    {
        // обертання на кут швидкості - ефект нахилу у напрямку руху
        this.transform.rotation = Quaternion.Euler(0, 0, 3 * Rigidbody2D.velocity.y);
        
        if(Rigidbody2D.velocity.x != 0)  // якщо отримали імпульс по Х, то прибираємо його
        {
            Rigidbody2D.velocity = new Vector2(0, Rigidbody2D.velocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Energy"))    // вхоплення енергії
        {
            gameStat.GameScore += 1;

            if (gameStat.GameEnergy < 0.5f) gameStat.GameEnergy += 0.5f;
            else gameStat.GameEnergy = 1;

            GameObject.Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)  // вихід з перетину колайдерів
    {
        if (other.gameObject.CompareTag("Tube"))    // проходження труби
        {
            gameStat.GameScore += 1;
        }
    }
}
/* Д.З. Доробити проєкт 2Д, прикласти посилання на репозиторій/архів, у якому
 *      окрім проєкту є скріншоти/відеозаписи
 * - Декілька "життів", які витрачаються при програшах 
 *   = зіткнення з перешкодою
 *   = брак енергії (зменшувати енергію при зіткненнях з підлогою/стелею)
 * - Додати об'єкти, що дозволяють збільшувати "життя" (з малою імовірністю)
 * - На меню паузи додати відомості про рекорди (виводится поточний час - рекордний час)
 * ** Додати можливість зберігти гру та відновити її
 * ** Зберігати кілька рекордних місць, видавати повідомлення про рейтинг гравця
 */