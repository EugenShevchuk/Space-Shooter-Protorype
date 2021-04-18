using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject defaultPrefab;

    private GameObject playerPrefab = HangarCosmetics.ChosenPrefab;
    private Material playerMaterial = HangarCosmetics.ChosenMaterial;

    private GameObject player;

    private void Start()
    {
        InitializePlayer();
    }

    private void InitializePlayer()
    {
        if (playerPrefab != null)
        {
            player = Instantiate(playerPrefab);
            // Костыль создающий массив дочерних элементов, после чего, с помощью цикла присваивающий каждому элементу материал.
            MeshRenderer[] childRenderers = player.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < childRenderers.Length; i++)
            {
                childRenderers[i].material = playerMaterial;
            }
        }
        else
        {
            player = Instantiate(defaultPrefab);
        }

        player.GetComponent<PlayerBehaviour>().enabled = true;
        player.GetComponent<OpenFire>().enabled = true;
        player.transform.Find("Shield").gameObject.SetActive(true);
        player.tag = "Player";
        player.layer = LayerMask.NameToLayer("Player");
    }
}
