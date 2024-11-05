using UnityEngine;
using System.Collections.Generic;

public class PlayerSpawner : MonoBehaviour
{
    public static PlayerSpawner Instance { get; private set; }

    [SerializeField]
    private GameObject[] prefabs; // Các prefab cho các nhân vật khác nhau
    [SerializeField]
    private int maxCount; // Số lượng player tối đa (pool size)
    [SerializeField]
    private Vector3[] spawnPositions; // Các vị trí spawn cho Player 1 và Player 2

    private List<GameObject> playerPool;
    private bool enableExtend = true; // Cho phép mở rộng pool nếu cần
    private GameObject player1Instance;
    private GameObject player2Instance;
    [SerializeField]
    public GameObject gameData;
    private void Awake()
    {
        // Thiết lập singleton
        if (Instance != null && Instance != this)
        {
            Debug.Log("An instance of PlayerSpawner already exists. Destroying this instance.");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        playerPool = new List<GameObject>();
        PlayerSpawner.Instance.SpawnPlayerWithSelection(1, GameDataNgu.Instance.player1);
        PlayerSpawner.Instance.SpawnPlayerWithSelection(2, GameDataNgu.Instance.player2);
        if (prefabs.Length < 2 || spawnPositions.Length < 2)
        {
            Debug.LogError("Yêu cầu ít nhất 2 prefab và 2 vị trí spawn.");
            return;
        }

        for (int i = 0; i < maxCount; i++)
        {
            GameObject newPlayer = Instantiate(prefabs[i % prefabs.Length]);
            newPlayer.SetActive(false);
            playerPool.Add(newPlayer);
        }
    }

    public void SpawnPlayerWithSelection(int playerIndex, int characterIndex)
    {
        GameObject selectedPrefab = prefabs[characterIndex];

        if (playerIndex == 1)
        {
            
            player1Instance = Instantiate(selectedPrefab, spawnPositions[0], Quaternion.identity);
            player1Instance.SetActive(true);
            Debug.Log("Player 1 đã chọn " + selectedPrefab.name);
            
        }
        else if (playerIndex == 2)
        {
            player2Instance = Instantiate(selectedPrefab, spawnPositions[1], Quaternion.identity);
            player2Instance.SetActive(true);
            Debug.Log("Player 2 đã chọn " + selectedPrefab.name);
        }
    }

    private GameObject GetFreePlayer()
    {
        foreach (var player in playerPool)
        {
            if (!player.activeSelf)
            {
                return player;
            }
        }

        if (enableExtend)
        {
            return AddNewPlayer();
        }
        return null;
    }

    private GameObject AddNewPlayer()
    {
        GameObject newPlayer = Instantiate(prefabs[playerPool.Count % prefabs.Length]);
        newPlayer.SetActive(false);
        playerPool.Add(newPlayer);
        return newPlayer;
    }
}
