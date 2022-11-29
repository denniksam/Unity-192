using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smiley : MonoBehaviour
{
    [SerializeField]                      // Один зі способів змінити
    private GameObject Sphere;            // прив'язування об'єктів:
    private Vector3 shift;                // - створюємо новий об'єкт (порожній)
                                          // - забезпечуємо його слідування
    void Start()                          //    за початковим об'єктом
    {                                     // - змінюємо посилання з початкового
        shift =                           //    на новий об'єкт 
            this.transform.position       // 
            -                             // shift - зміщення нового та початкового 
            Sphere.transform.position;    //   об'єктів. На старті визначається
    }                                     //   зміщення, що задане у редакторі
                                          //   (на сцені)
                                          // 
    void Update()                         // 
    {                                     // 
        this.transform.position           // слідування - зміна позиції синхронно
            =                             //   з початковим об'єктом (Sphere)
            Sphere.transform.position     //   з урахуванням їх зміщення, 
            +                             //   визначеного на старті
            shift;                        // 
    }
}
