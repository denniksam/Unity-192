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

    private void OnTriggerExit2D(Collider2D other)  // вихід з перетину колайдерів
    {
        if (other.gameObject.CompareTag("Tube"))    // проходження труби
        {
            gameStat.GameScore += 1;
        }
    }
}
/* Д.З. Додати у повідомлення, яке відображається у меню паузи:
 *  - кількість накопичених балів (score)
 *  - рівень залишкової енергії 
 */