using UnityEngine;

namespace SpaceShooter
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject[] enemyPrefabs;
        public Material[] enemyMaterials;

        public float spawnRate = 2f;
        public float padding = 5f;

        private Borderline borderline;

        private void Awake()
        {
            this.borderline = GetComponent<Borderline>();

            this.Invoke(nameof(this.SpawnEnemy), this.spawnRate);
        }

        private void SpawnEnemy()
        {
            int prefabIndex = Random.Range(0, this.enemyPrefabs.Length);
            int materialIndex = Random.Range(0, this.enemyMaterials.Length);

            var enemy = Instantiate(this.enemyPrefabs[prefabIndex]);
                        
            MeshRenderer[] childRenderers = enemy.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < childRenderers.Length; i++)
            {
                childRenderers[i].material = this.enemyMaterials[materialIndex];
            }

            enemy.layer = LayerMask.NameToLayer("Enemy");

            Vector3 position = Vector3.zero;
            float minX = this.padding - this.borderline.CamWidth;
            float maxX = this.borderline.CamWidth - this.padding;

            position.x = Random.Range(minX, maxX);
            position.y = this.borderline.CamHeight + this.padding;

            enemy.transform.position = position;
            enemy.transform.rotation = Quaternion.Euler(90, 180, 0);

            this.Invoke(nameof(this.SpawnEnemy), this.spawnRate);
        }
    }
}