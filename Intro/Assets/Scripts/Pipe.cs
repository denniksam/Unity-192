using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    private float Speed = 1;

    private Vector2 moveDirection = Vector2.left;

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Translate(moveDirection * Speed * Time.deltaTime); // * 0.01f);
    }
    /* Д.З. Встановити порожній об'єкт за межами камери,
     * додати до нього колайдер та скрипт, що відстежує зіткнення (Log)
     * підібрати позицію таким чином, щоб колізія спрацьовувала тоді, 
     * коли труба виходить за межі видності.
     */
}
