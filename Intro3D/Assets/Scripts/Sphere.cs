using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Rigidbody rb;
    private Vector3 jump = Vector3.up * 100;
    private Vector3 forceDirection;
    private const float FORCE_APML = 2;

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
        // абсолютний простір
        // rb.AddForce(new Vector3(fx, 0, fy) * 2);    // fy на позиції Z

        // відносно камери
        forceDirection = cam.transform.forward;     // напрям погляду камери
        forceDirection.y = 0;     // прибираємо вертикальну складову
        forceDirection = forceDirection.normalized;  // довжина - 1

    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Destroy(other.gameObject);
    }
}
/* Д.З. Лабіринт: створити стіни лабіринту
 * підібрати розміри кулі для проходження усіх отворів
 */