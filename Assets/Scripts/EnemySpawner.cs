using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Material[] enemyMaterials;

    public float spawnRate = 2f;
    public float padding = 5f;

    private Borderline _borderline;

    private void Awake()
    {
        _borderline = GetComponent<Borderline>();

        Invoke(nameof(SpawnEnemy), spawnRate);
    }

    private void SpawnEnemy()
    {
        int prefabIndex = Random.Range(0, enemyPrefabs.Length);
        int materialIndex = Random.Range(0, enemyMaterials.Length);

        GameObject enemy = Instantiate(enemyPrefabs[prefabIndex]);

        // Костыль создающий массив дочерних элементов, после чего, с помощью цикла присваивающий каждому элементу материал.
        MeshRenderer[] childRenderers = enemy.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < childRenderers.Length; i++)
        {
            childRenderers[i].material = enemyMaterials[materialIndex];
        }

        // Включает скрипт Enemy и присваивает соответствующий тег.
        enemy.GetComponent<Enemy>().enabled = true;
        enemy.tag = "Enemy";

        // Позволяет задать случайную точку спавна по Х в пределах ширины экрана.
        // По Y позиция - самый верх+отступ.
        Vector3 position = Vector3.zero;        
        float minX = padding - _borderline.camWidth;
        float maxX = _borderline.camWidth - padding;

        position.x = Random.Range(minX, maxX);
        position.y = _borderline.camHeight + padding;

        enemy.transform.position = position;
        enemy.transform.rotation = Quaternion.Euler(90, 180, 0);

        Invoke(nameof(SpawnEnemy), spawnRate);
    }
}
