using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates1 : MonoBehaviour
{
    private const float Timeout = 20;
    private float timeout;

    void Start()
    {
        timeout = Timeout;
    }

    void Update()
    {
        timeout -= Time.deltaTime;
        if(timeout < 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.transform.position = new Vector3(
                this.transform.position.x,
                this.transform.localScale.y * ( -1/2f + timeout / Timeout),
                this.transform.position.z);
        }
    }
}
/* Д.З. Налаштувати повільне зменшення Gates1
 * Реалізувати зникнення Gates1 у разі контакту Sphere з CheckPoint1
 */