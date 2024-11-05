using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameDataNgu : MonoBehaviour
{
    public int player1;
    public int player2;
    public static GameDataNgu Instance;
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
