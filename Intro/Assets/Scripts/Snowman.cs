using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody2D.centerOfMass =   // зміщення центру мас об'єкта
            new Vector2(0, -2f);    // на 0.3 одиниці вниз від його центру
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
/* Зробити "постріл з гармати"
 * По натисненню на "A-S-D" ядро вилітає з гармати під кутом 45 градусів
 * Сила пострілу зростає у послідовності клавіш (A-S-D)
 * Зробити мішень, яка "розвалюється" через попадання
 */