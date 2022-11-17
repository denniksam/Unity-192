using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject Pipe;            // посилання для префабу

    private float pipeSpawnTime = 3;    // Час між трубами (3 секунди)
    private float pipeDeltaTime = 3;    // Додаток, що зменшує складність
    private float pipeTime;             // зворотний відлік

    void Start()
    {
        pipeTime = 0;
    }
    void LateUpdate()
    {
        pipeTime -= Time.deltaTime;
        if(pipeTime < 0)
        {
            pipeTime = pipeSpawnTime + pipeDeltaTime * (1 - GameMenu.GameDifficulty);
            // Debug.Log(pipeTime);
            SpawnPipe();
        }
    }
    void SpawnPipe()
    {
        GameObject.Instantiate(Pipe, 
            this.transform.position 
                + Vector3.up * Random.Range(-Bird.PipeShift, Bird.PipeShift),
            Quaternion.identity);
    }
}
/* Д.З. Скласти скрипт (частину) для детектування зіткнення труби та птаха
 * при зіткненні знищувати всі наявні труби,
 *   перемістити птаха у вихідну позицію,
 *   почати новий цикл генерації труб
 *   (!не перезапускати сцену, має залишатися ігрова статистика)
 */