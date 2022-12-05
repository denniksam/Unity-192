using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Rigidbody rb;
    private AudioSource hitWallSound;
    private AudioSource hitGateSound;

    private Vector3 jump = Vector3.up * 100;
    private Vector3 forceDirection;
    private const float FORCE_APML = 2;


    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        AudioSource[] audioSources =              // GetComponents - повертає масив
            this.GetComponents<AudioSource>();    // у порядку слідування у інспекторі
        hitWallSound = audioSources[0];
        hitGateSound = audioSources[1];
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
        // cam.transform.forward - нахилений вниз, це значить,
        // що зусилля будуть вперед-вдавлювати, назад-підкидати сферу
        forceDirection.y = 0;     // прибираємо вертикальну складову
        // але якщо просто зменшити (до 0) одну з компонент, то
        // вектор стане коротший. Якщо ним користатись, то зусилля
        // буде залежати від кута нахилу камери: якщо дивимось 
        // вниз, то керування майже відсутнє.
        // Нормалізація вектора - приведення його довжини до 1
        // зі збереженням напрямку
        forceDirection = forceDirection.normalized * fy;
        // fy - зусилля вниз-вгору - прикладається убік погляду камери

        // cam.transform.right не має вертикальної складової, оскільки
        // камера не нахиляється по осі Z. Корекції не потрібно.
        forceDirection += cam.transform.right * fx;
        // оскільки fx - має знак, не потрібно додавати left.

        rb.AddForce(forceDirection * FORCE_APML);
    }

    private void OnCollisionEnter(Collision other)
    {
        // Зіткнення зі стіною - програвання звуку зіткнення
        // Беремо налаштування звуків з меню гри
        if (GameMenu.SoundsEnabled)
        {
            AudioSource sound = other.gameObject.tag switch
            {
                "Wall" => hitWallSound,
                "Gate" => hitGateSound,
                _ => null
            };
            if (sound != null) {
                sound.volume = GameMenu.SoundsVolume;
                sound.Play();
            }
        }
    }
}
/* Д.З. Лабіринт: створити стіни лабіринту
 * підібрати розміри кулі для проходження усіх отворів
 */