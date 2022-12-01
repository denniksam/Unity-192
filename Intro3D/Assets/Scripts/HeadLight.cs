using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Керування ліхтарем підсвітлення руху персонажа
 */
public class HeadLight : MonoBehaviour
{
    [SerializeField]
    private GameObject Sphere;   // відстежуємо позицію сфери
    [SerializeField]
    private Camera Cam;          // відстежуємо кут повороту камери

    private Vector3 shift;       // зміщення ліхтаря відносно сфери

    void Start()
    {
        shift = this.transform.position     // початкове зміщення об'єктів 
            - Sphere.transform.position;    // визначається зі сцени
    }

    void LateUpdate()
    {
        this.transform.position =           // стеження - рух разом зі сферою
            Sphere.transform.position       // зі збереженням відносного положення,
            + shift;                        // заданого shift
    }
}
/* Освітлення:
 * - додати джерело спрямованого світла, змінити нахил, щоб не збігався з
 *     наявним джерелом
 * - додати джерело конусного світла, реалізувати у вигляді "вуличного ліхтаря"
 * - додати джерело точкового світла, реалізувати у вигляді світної кулі
 *    (матеріалу кулі забезпечити емісію)
 * - додати матеріал Skybox, змінити текстуру неба   
 * - встановити ліхтар для песонажа, забезпечити його рух разом з персонажем,
 *     а обертання - разом з камерою
 */