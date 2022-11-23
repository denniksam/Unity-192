using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 jump = Vector3.up * 100;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jump);
        }
        float fx = Input.GetAxis("Horizontal");
        float fy = Input.GetAxis("Vertical");       // Vertical -> Z
        rb.AddForce(new Vector3(fx, 0, fy) * 2);    // fy на позиції Z
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Destroy(other.gameObject);
    }
}
/* Д.З. Лабіринт: створити стіни лабіринту
 * підібрати розміри кулі для проходження усіх отворів
 */