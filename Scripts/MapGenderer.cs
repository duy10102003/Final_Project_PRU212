
﻿
//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEditor;
//using UnityEngine;
//using UnityEngine.Tilemaps;
//using UnityEngine.WSA;

//public class MapGenderer : MonoBehaviour
//{
//    [SerializeField]
//    public int SizeX;
//    [SerializeField]
//    public int SizeY;
//    TileBase Destructible;
//    TileBase InDestructible;
//    [SerializeField]
//    GameObject player;
//    Tilemap wall;
//    Tilemap destrucable;
//    // Start is called before the first frame update
//    void Start()
//    {
//        if(GameDataMap.Instance.map == 1)
//        {
//            Destructible = GameDataMap.Instance.destructibleTiles[0];
//            InDestructible = GameDataMap.Instance.indestructibleTiles[0];
//        }else if(GameDataMap.Instance.map == 2)
//        { 
//            Destructible = GameDataMap.Instance.destructibleTiles[1];
//            InDestructible = GameDataMap.Instance.indestructibleTiles[1];
//        }
//        else
//        {
//            Destructible = GameDataMap.Instance.destructibleTiles[2];
//            InDestructible = GameDataMap.Instance.indestructibleTiles[2];
//        }


//        player.GetComponent<BombController>().destructibleTiles = destrucable;
//        player.GetComponent<BombController>().explosionLayerMask = 1;
//        GameObject map = new GameObject("MapGrid");
//        map.transform.position = Vector3.zero;
//        map.gameObject.AddComponent<Grid>();


//        //TileMapGenderer wall = new TileMapGenderer();



//        GameObject indestrucObject = new GameObject("IndestrucObject");
//        wall = indestrucObject.AddComponent<Tilemap>();
//        indestrucObject.transform.parent = map.transform;
//        indestrucObject.AddComponent<TilemapRenderer>();
//        indestrucObject.AddComponent<TilemapCollider2D>();
//        indestrucObject.GetComponent<TilemapRenderer>().sortingOrder = 0;



//        // TileMapGenderer destrucable = new TileMapGenderer();


//        GameObject destrucObject = new GameObject("DestrucObject");
//        destrucable = destrucObject.AddComponent<Tilemap>();
//        destrucObject.transform.parent = map.transform;
//        destrucObject.AddComponent<TilemapRenderer>();
//        destrucObject.AddComponent<TilemapCollider2D>();
//        destrucObject.GetComponent<TilemapRenderer>().sortingOrder = 1;

//        WallBuild(wall, InDestructible);
//        InDestrucableBuild(wall, InDestructible);
//        DestrucableBuild(destrucable, Destructible);

//        map.transform.position = new Vector3(0.5f, 0.5f, 0);
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//    void WallBuild(Tilemap tilemap, TileBase tile)
//    {
//        for (int x = 0; x < SizeX; x++)
//        {
//            for (int y = 0; y < SizeY; y++)
//            {
//                if (x == 0 || y == 0 || x == SizeX - 1 || y == SizeY - 1)
//                {
//                    Vector3Int tilePosition = new Vector3Int(x, y, 0);// o chua tile
//                    tilemap.SetTile(tilePosition, tile); // dat tile
//                    Debug.Log(x);
//                }

//            }
//        }
//    }

//    void DestrucableBuild(Tilemap tilemap, TileBase tile)
//    {
//        for (int x = 1; x < SizeX - 1; x++)
//        {
//            for (int y = 1; y < SizeY - 1; y++)
//            {
//                if (x <= 2 && y <= 2)
//                {
//                    if (x == 2 && y == 2)
//                    {
//                        Vector3Int cellPosition = tilemap.LocalToCell(new Vector3(x, y, 0));
//                        player.transform.position = cellPosition;

//                    }
//                    continue;
//                }
//                int rate = Random.Range(1, 100);
//                if (rate < 40)
//                {
//                    Vector3Int tilePosition = new Vector3Int(x, y, 0);// o chua tile
//                    tilemap.SetTile(tilePosition, tile); // dat tile

//                }
//                Debug.Log(rate);
//            }
//        }
//    }
//    void InDestrucableBuild(Tilemap tilemap, TileBase tile)
//    {
//        for (int x = 1; x < SizeX - 1; x++)
//        {
//            for (int y = 1; y < SizeY - 1; y++)
//            {
//                if (x <= 2 && y <= 2)
//                { continue; }
//                int rate = Random.Range(1, 100);
//                if (rate > 80)
//                {
//                    Vector3Int tilePosition = new Vector3Int(x, y, 0);// o chua tile
//                    tilemap.SetTile(tilePosition, tile); // dat tile
//                }
//                Debug.Log(rate);
//            }
//        }
//    }
//}
using UnityEngine.Tilemaps;
using UnityEngine;
using System.Collections.Generic;

public class MapGenderer : MonoBehaviour
{
    [SerializeField]
    public int SizeX;
    [SerializeField]
    public int SizeY;

   
    TileBase Destructible;
   
    TileBase InDestructible;
   
    TileBase WallTile;
    
    TileBase Grass;

    [SerializeField]
    GameObject player;

    Tilemap wall;
    Tilemap destructable;
    Tilemap grassLayer;
    Tilemap indestructibleLayer;

    private static MapGenderer instance;




    void Start()
    {
        if (GameDataMap.Instance.map == 1)
        {
            Destructible = GameDataMap.Instance.destructibleTiles[0];
            InDestructible = GameDataMap.Instance.indestructibleTiles[0];
            WallTile = GameDataMap.Instance.wallTiles[0];
            Grass = GameDataMap.Instance.grassTiles[0];

        }
        else if (GameDataMap.Instance.map == 2)
        {
            Destructible = GameDataMap.Instance.destructibleTiles[1];
            InDestructible = GameDataMap.Instance.indestructibleTiles[1];
            WallTile = GameDataMap.Instance.wallTiles[1];
            Grass = GameDataMap.Instance.grassTiles[1];
        }
        else
        {
            Destructible = GameDataMap.Instance.destructibleTiles[2];
            InDestructible = GameDataMap.Instance.indestructibleTiles[2];
            WallTile = GameDataMap.Instance.wallTiles[2];
            Grass = GameDataMap.Instance.grassTiles[2];
        }


        GameObject existingMapGrid = GameObject.Find("MapGrid");
        if (existingMapGrid != null)
        {
            Destroy(existingMapGrid);
        }


        player.GetComponent<BombController>().destructibleTiles = destructable;
        player.GetComponent<BombController>().explosionLayerMask = 1;


        GameObject map = new GameObject("MapGrid");
        map.transform.position = Vector3.zero;
        map.gameObject.AddComponent<Grid>();


        // Grass Layer
        GameObject grassObject = new GameObject("GrassLayer");
        grassLayer = grassObject.AddComponent<Tilemap>();
        grassObject.transform.parent = map.transform;
        grassObject.AddComponent<TilemapRenderer>();
        grassObject.GetComponent<TilemapRenderer>().sortingOrder = -1; // Background layer

        // Wall Layer
        GameObject wallObject = new GameObject("WallLayer");
        wall = wallObject.AddComponent<Tilemap>();
        wallObject.transform.parent = map.transform;
        wallObject.AddComponent<TilemapRenderer>();
        wallObject.AddComponent<TilemapCollider2D>();
        wallObject.GetComponent<TilemapRenderer>().sortingOrder = 0;

        // Destructible Layer
        GameObject destructObject = new GameObject("DestructibleLayer");
        destructable = destructObject.AddComponent<Tilemap>();
        destructObject.transform.parent = map.transform;
        destructObject.AddComponent<TilemapRenderer>();
        destructObject.AddComponent<TilemapCollider2D>();
        destructObject.GetComponent<TilemapRenderer>().sortingOrder = 1;



        // Indestructible Layer
        GameObject indestructObject = new GameObject("IndestructibleLayer");
        indestructibleLayer = indestructObject.AddComponent<Tilemap>();
        indestructObject.transform.parent = map.transform;
        indestructObject.AddComponent<TilemapRenderer>();
        indestructObject.AddComponent<TilemapCollider2D>();
        indestructObject.GetComponent<TilemapRenderer>().sortingOrder = 2;

        GrassFill();
        WallBuild();
        DestructibleBuild();
        IndestructibleBuild();

        GameObject[] list = GameObject.FindGameObjectsWithTag("Player");
        foreach(var i in list)
        {
            i.gameObject.GetComponent<BombController>().destructibleTiles = destructable;
        }
        map.transform.position = new Vector3(0.5f, 0.5f, 0);
    }


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

    }

    void GrassFill()
    {
        for (int x = 0; x < SizeX; x++)
        {
            for (int y = 0; y < SizeY; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                grassLayer.SetTile(tilePosition, Grass);
            }
        }
    }

    void WallBuild()
    {
        for (int x = 0; x < SizeX; x++)
        {
            wall.SetTile(new Vector3Int(x, 0, 0), WallTile);
            wall.SetTile(new Vector3Int(x, SizeY - 1, 0), WallTile); 
        }

        for (int y = 0; y < SizeY; y++)
        {
            wall.SetTile(new Vector3Int(0, y, 0), WallTile); 
            wall.SetTile(new Vector3Int(SizeX - 1, y, 0), WallTile); 
        }
    }

    void DestructibleBuild()
    {



        for (int x = 1; x < SizeX - 1; x++)
        {
            for (int y = 1; y < SizeY - 1; y++)
            {

                
                if ((x <= 1 && y <= 2) ||            
                    (x <= 1 && y >= SizeY - 3) ||    
                    (x >= SizeX - 2 && y <= 2) ||    
                    (x >= SizeX - 3 && y >= SizeY - 3)) 
                {
                    continue;
                }

                int rate = Random.Range(1, 100);
                if (rate < 60 && wall.GetTile(new Vector3Int(x, y, 0)) == null)
                {
                    Vector3Int tilePosition = new Vector3Int(x, y, 0);
                    destructable.SetTile(tilePosition, Destructible);
                }
            }
        }
    }

    void IndestructibleBuild()

    {
        for (int x = 1; x < SizeX - 1; x++)
        {
            for (int y = 1; y < SizeY - 1; y++)
            {

                if ((x <= 1 && y <= 2) ||            
                    (x <= 1 && y >= SizeY - 3) ||    
                    (x >= SizeX - 3 && y <= 2) ||    
                    (x >= SizeX - 2 && y >= SizeY - 3)) 
                {
                    continue;
                }

                int rate = Random.Range(1, 100);
                Vector3Int tilePosition = new Vector3Int(x, y, 0);

                if (rate > 40 && wall.GetTile(tilePosition) == null && destructable.GetTile(tilePosition) == null)
                {
                    indestructibleLayer.SetTile(tilePosition, InDestructible);
                }
            }
        }

    }

}
