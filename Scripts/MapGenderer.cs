using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

public class MapGenderer : MonoBehaviour
{
    [SerializeField]
    public int SizeX;
    [SerializeField]
    public int SizeY;
    [SerializeField]
    TileBase Destructible;
    [SerializeField]
    TileBase InDestructible;
    [SerializeField]
    GameObject player;
    Tilemap wall;
    Tilemap destrucable;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<BombController>().destructibleTiles = destrucable;
        player.GetComponent<BombController>().explosionLayerMask = 1;
        GameObject map = new GameObject("MapGrid");
        map.transform.position = Vector3.zero;
        map.gameObject.AddComponent<Grid>();


        //TileMapGenderer wall = new TileMapGenderer();



        GameObject indestrucObject = new GameObject("IndestrucObject");
        wall = indestrucObject.AddComponent<Tilemap>();
        indestrucObject.transform.parent = map.transform;
        indestrucObject.AddComponent<TilemapRenderer>();
        indestrucObject.AddComponent<TilemapCollider2D>();
        indestrucObject.GetComponent<TilemapRenderer>().sortingOrder = 0;



        // TileMapGenderer destrucable = new TileMapGenderer();


        GameObject destrucObject = new GameObject("DestrucObject");
        destrucable = destrucObject.AddComponent<Tilemap>();
        destrucObject.transform.parent = map.transform;
        destrucObject.AddComponent<TilemapRenderer>();
        destrucObject.AddComponent<TilemapCollider2D>();
        destrucObject.GetComponent<TilemapRenderer>().sortingOrder = 1;

        WallBuild(wall, InDestructible);
        InDestrucableBuild(wall, InDestructible);
        DestrucableBuild(destrucable, Destructible);

        map.transform.position = new Vector3(0.5f, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void WallBuild(Tilemap tilemap, TileBase tile)
    {
        for (int x = 0; x < SizeX; x++)
        {
            for (int y = 0; y < SizeY; y++)
            {
                if (x == 0 || y == 0 || x == SizeX - 1 || y == SizeY - 1)
                {
                    Vector3Int tilePosition = new Vector3Int(x, y, 0);// o chua tile
                    tilemap.SetTile(tilePosition, tile); // dat tile
                    Debug.Log(x);
                }

            }
        }
    }
   
    void DestrucableBuild(Tilemap tilemap, TileBase tile)
    {
        for (int x = 1; x < SizeX - 1; x++)
        {
            for (int y = 1; y < SizeY - 1; y++)
            {
                if (x <= 2 && y <= 2)
                {
                    if (x==2 && y==2)
                    {
                        Vector3Int cellPosition = tilemap.LocalToCell(new Vector3(x,y,0));
                        player.transform.position = cellPosition;
                        
                    }
                    continue;
                }
                int rate = Random.Range(1, 100);
                if (rate < 40)
                {
                    Vector3Int tilePosition = new Vector3Int(x, y, 0);// o chua tile
                    tilemap.SetTile(tilePosition, tile); // dat tile

                }
                Debug.Log(rate);
            }
        }
    }
    void InDestrucableBuild(Tilemap tilemap, TileBase tile)
    {
        for (int x = 1; x < SizeX - 1; x++)
        {
            for (int y = 1; y < SizeY - 1; y++)
            {
                if (x <= 2 && y <= 2)
                { continue; }
                int rate = Random.Range(1, 100);
                if (rate > 80)
                {
                    Vector3Int tilePosition = new Vector3Int(x, y, 0);// o chua tile
                    tilemap.SetTile(tilePosition, tile); // dat tile
                }
                Debug.Log(rate);
            }
        }
    }
}
