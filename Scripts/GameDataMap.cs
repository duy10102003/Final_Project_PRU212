using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GameDataMap : MonoBehaviour
{
    public int map;
    public List<TileBase> destructibleTiles;
    public List<TileBase> indestructibleTiles;
    public List<TileBase> wallTiles;
    public List<TileBase> grassTiles;
    public static GameDataMap Instance;
    private void Awake()
    {
        // Kiểm tra xem Instance đã được thiết lập chưa
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ cho đối tượng không bị xóa khi chuyển cảnh
        }
        else
        {
            Destroy(gameObject); // Nếu đã có Instance, hủy đối tượng mới tạo
        }
    }
}

