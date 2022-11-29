using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint2Activator : MonoBehaviour
{
    // Порожній ГО з колайдером, що має активувати CheckPoint2
    private void OnTriggerEnter(Collider other)
    {
        CheckPoint2.isActivated = true;
    }
}
