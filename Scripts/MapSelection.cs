using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapSelection : MonoBehaviour
{
    public Image[] mapImages;
    public Image arrow;
    public int mapSelection = 0;

    private bool mapConfirmed = false;

    //public GameUIManager scoreboardManager;

    void Start()
    {
        UpdateSelection();
    }

    void Update()
    {
        HandleMapInput();
        CheckConfirmed();
    }

    void HandleMapInput()
    {
        if (!mapConfirmed)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                mapSelection = Mathf.Max(0, mapSelection - 1);
                UpdateSelection();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                mapSelection = Mathf.Min(mapImages.Length - 1, mapSelection + 1);
                UpdateSelection();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {

                ConfirmSelection();

            }
        }
    }



    void ConfirmSelection()
    {

        mapConfirmed = true;

        if (mapImages[mapSelection].name == "Map1")
        {
            GameDataMap.Instance.map = 1;
        }else if(mapImages[mapSelection].name == "Map2")
        {
            GameDataMap.Instance.map = 2;
        }
        else {
            GameDataMap.Instance.map = 3;
        }
        Debug.Log("Map: " + GameDataMap.Instance.map );

    }

    void CheckConfirmed()
    {
        if (mapConfirmed)
        {

            SceneManager.LoadScene("MapRender");
        }
    }

    void UpdateSelection()
    {

        for (int i = 0; i < mapImages.Length; i++)
        {
            mapImages[i].color = (i == mapSelection) ? Color.gray : Color.white;
        }


        arrow.transform.position = mapImages[mapSelection].transform.position + new Vector3(0, 140, 0);


    }
}
