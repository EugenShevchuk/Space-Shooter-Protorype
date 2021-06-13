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
            this.currentRotation = Quaternion.Euler(7, 140, 0);
            SetPrefab();
        }

        private void FixedUpdate()
        {
            if (this.currentPrefab != null)
            {
                this.currentPrefab.transform.Rotate(0, this.prefabRotationSpeed * Time.deltaTime, 0);
                this.currentRotation = this.currentPrefab.transform.rotation;
            }
        }

        private void SetPrefab()
        {
            if (this.currentPrefab != null)
                Destroy(this.currentPrefab);

            this.currentPrefab = Instantiate(this.shipPrefabs[prefabIndex]);

            this.currentPrefab.layer = LayerMask.NameToLayer("Player");
            this.currentPrefab.transform.position = this.spawnPosition;
            this.currentPrefab.transform.localScale *= this.localScale;
            this.currentPrefab.transform.rotation = this.currentRotation;
        }

        private void SetMaterial()
        {                    
            MeshRenderer[] childRenderers = currentPrefab.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < childRenderers.Length; i++)
            {
                childRenderers[i].material = this.shipMaterials[this.materialIndex];
            }

            this.prefabText.text = this.shipPrefabs[this.prefabIndex].name;
            this.materialText.text = this.shipMaterials[this.materialIndex].name;
        }

        public void NextPrefabClicked()
        {
            this.prefabIndex++;
            if (this.prefabIndex > this.shipPrefabs.Length - 1)
                this.prefabIndex = 0;
            this.SetPrefab();
        }

        public void PreviousPrefabClicked()
        {
            this.prefabIndex--;
            if (this.prefabIndex < 0)
                this.prefabIndex = this.shipPrefabs.Length - 1;
            this.SetPrefab();
        }

        public void NextMaterialClicked()
        {
            this.materialIndex++;
            if (this.materialIndex > this.shipMaterials.Length - 1)
                this.materialIndex = 0;
            this.SetMaterial();
        }

        public void PreviousMaterialClicked()
        {
            this.materialIndex--;
            if (this.materialIndex < 0)
                this.materialIndex = this.shipMaterials.Length - 1;
            this.SetMaterial();
        }

        public void ApplyClicked()
        {
            ChosenPrefab = this.shipPrefabs[prefabIndex];
            ChosenMaterial = this.shipMaterials[materialIndex];
        }
    }
}