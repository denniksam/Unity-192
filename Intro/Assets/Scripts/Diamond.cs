using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;  // змінна для посилання на компонент

    void Start()
    {
        Rigidbody2D = this.GetComponent<Rigidbody2D>();  // одержання посилання
    }

    void Update()
    {
        // Прикладання сили до тіла       // GetKeyDown - однократне спрацювання
        if (Input.GetKey(KeyCode.Space))  // GetKey - постійне сканування, 
        {                                 //  якщо затиснути - має ефект
            Rigidbody2D.AddForce(  // Додаємо імпульс сили до тіла
                Vector2.up * 10);  // спрямований вгору величиною 10 у.о.
            
            // Debug.Log("Force");    // Повідомлення у консоль
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Rigidbody2D.AddTorque(-50);
        }
    }

    // Update is called once per frame
    void UpdateRot()
    {
        this.  // оскільки скрипт знаходиться на GameObject-і, this - GameObject(Diamond)
            transform.  // доступ до компонента Transform
            Rotate(Vector3.forward, 1);  // обертання на 1 градус з кожним фреймом

    }
    /* Д.З. Встановити та налагодити Unity, VS (VS Code, Rider)
     * додати на сцену спрайт (довільної форми)
     * скласти скрипт, що його обертає у іншу сторону, ніж попередні об'єкти
     */
}
