using UnityEngine;

public sealed class PlayerInputListener : MonoBehaviour
{
    public static PlayerInputListener instance => GetInstance();
    private static PlayerInputListener m_instance;
    private static bool isInitialized => m_instance != null;

    private const string NAME = "[INPUT LISTENER]";

    private static PlayerInputListener GetInstance()
    {
        if (!isInitialized)
            m_instance = CreateSingleton();
        return m_instance;
    }

    private static PlayerInputListener CreateSingleton()
    {
        PlayerInputListener createdManager = new GameObject(NAME).AddComponent<PlayerInputListener>();
        //createdManager.hideFlags = HideFlags.HideAndDontSave;
        DontDestroyOnLoad(createdManager.gameObject);
        return createdManager;
    }

    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    private void Update()
    {
        GetInputPC();
    }

    public static void GetInputPC()
    {        
        instance.Horizontal = Input.GetAxis("Horizontal");
        instance.Vertical = Input.GetAxis("Vertical");
    }
}
