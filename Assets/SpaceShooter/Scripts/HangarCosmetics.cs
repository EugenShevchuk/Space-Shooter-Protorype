using UnityEngine;
using UnityEngine.UI;

public class HangarCosmetics : MonoBehaviour
{
    [SerializeField] private GameObject[] shipPrefabs;
    private int prefabIndex = 0;
    [SerializeField] private Material[] shipMaterials;
    private int materialIndex = 0;

    public static GameObject ChosenPrefab;
    public static Material ChosenMaterial;

    [SerializeField] private float prefabRotationSpeed = 25f;

    private GameObject currentPrefab;
    private Quaternion currentRotation;
    private float deltaTime;

    [SerializeField] private Text prefabText;
    [SerializeField] private Text materialText;

    private void Start()
    {
        deltaTime = Time.deltaTime;
        currentRotation = Quaternion.Euler(7, 140, 0);
        SetPrefabMaterial();        
    }

    private void FixedUpdate()
    {
        currentPrefab.transform.Rotate(0, prefabRotationSpeed * deltaTime, 0);
        currentRotation = currentPrefab.transform.rotation;        
    }
    // Метод спавнит префаб и устанавливает ему материал под соответствующими индексами.
    public void SetPrefabMaterial()
    {
        Vector3 spawnPosition = new Vector3(0, 55, 0);
        
        if (currentPrefab != null)            
            Destroy(currentPrefab);

        currentPrefab = Instantiate(shipPrefabs[prefabIndex]);
        
        currentPrefab.transform.position = spawnPosition;        
        currentPrefab.transform.localScale *= 5.5f;
        currentPrefab.transform.rotation = currentRotation;     

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
        SetPrefabMaterial();
    }

    public void PreviousPrefabClicked()
    {
        prefabIndex--;
        if (prefabIndex < 0)
            prefabIndex = shipPrefabs.Length - 1;
        SetPrefabMaterial();
    }

    public void NextMaterialClicked()
    {
        materialIndex++;
        if (materialIndex > shipMaterials.Length - 1)
            materialIndex = 0;
        SetPrefabMaterial();
    }

    public void PreviousMaterialClicked()
    {
        materialIndex--;
        if (materialIndex < 0)
            materialIndex = shipMaterials.Length - 1;
        SetPrefabMaterial();
    }

    public void ApplyClicked()
    {
        ChosenPrefab = shipPrefabs[prefabIndex];
        ChosenMaterial = shipMaterials[materialIndex];
    }
}
