using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    private float Speed = 1;

    private Vector2 moveDirection = Vector2.left;

    void Update()
    {
        this.transform.Translate(moveDirection * Speed * Time.deltaTime); // * 0.01f);
    }
}
