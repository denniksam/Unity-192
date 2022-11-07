using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
