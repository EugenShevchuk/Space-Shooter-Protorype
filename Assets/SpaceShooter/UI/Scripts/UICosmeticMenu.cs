using UnityEngine;
using UnityEngine.UI;
using SpaceShooter.Architecture;

namespace SpaceShooter {
    public class UICosmeticMenu : MonoBehaviour
    {
        [SerializeField] private GameObject[] shipPrefabs;
        private int prefabIndex = 0;
        [SerializeField] private Material[] shipMaterials;
        private int materialIndex = 0;

        public static GameObject ChosenPrefab;
        public static Material ChosenMaterial;

        [SerializeField] private float prefabRotationSpeed = 25f;
        [SerializeField] private Vector3 spawnPosition;
        [SerializeField] private float localScale = 6f;

        private GameObject currentPrefab;
        private Quaternion currentRotation;

        [SerializeField] private Text prefabText;
        [SerializeField] private Text materialText;

        private void OnEnable()
        {
            Game.GameInitializedEvent += OnGameInitialized;
        }

        private void OnDisable()
        {
            Game.GameInitializedEvent += OnGameInitialized;
        }

        private void OnGameInitialized()
        {
            currentRotation = Quaternion.Euler(7, 140, 0);
            SetPrefab();
        }

        private void FixedUpdate()
        {
            if (currentPrefab != null)
            {
                currentPrefab.transform.Rotate(0, prefabRotationSpeed * Time.deltaTime, 0);
                currentRotation = currentPrefab.transform.rotation;
            }
        }

        private void SetPrefab()
        {
            if (currentPrefab != null)
                Destroy(currentPrefab);

            currentPrefab = Instantiate(shipPrefabs[prefabIndex]);

            currentPrefab.layer = LayerMask.NameToLayer("Player");
            currentPrefab.transform.position = spawnPosition;
            currentPrefab.transform.localScale *= localScale;
            currentPrefab.transform.rotation = currentRotation;
        }

        private void SetMaterial()
        {
            // Костыль создающий массив дочерних элементов, после чего, с помощью цикла присваивающий каждому элементу материал.        
            MeshRenderer[] childRenderers = currentPrefab.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < childRenderers.Length; i++)
            {
                childRenderers[i].material = shipMaterials[materialIndex];
            }

            prefabText.text = shipPrefabs[prefabIndex].name;
            materialText.text = shipMaterials[materialIndex].name;
        }

        public void NextPrefabClicked()
        {
            prefabIndex++;
            if (prefabIndex > shipPrefabs.Length - 1)
                prefabIndex = 0;
            SetPrefab();
        }

        public void PreviousPrefabClicked()
        {
            prefabIndex--;
            if (prefabIndex < 0)
                prefabIndex = shipPrefabs.Length - 1;
            SetPrefab();
        }

        public void NextMaterialClicked()
        {
            materialIndex++;
            if (materialIndex > shipMaterials.Length - 1)
                materialIndex = 0;
            SetMaterial();
        }

        public void PreviousMaterialClicked()
        {
            materialIndex--;
            if (materialIndex < 0)
                materialIndex = shipMaterials.Length - 1;
            SetMaterial();
        }

        public void ApplyClicked()
        {
            ChosenPrefab = shipPrefabs[prefabIndex];
            ChosenMaterial = shipMaterials[materialIndex];
        }
    }
}