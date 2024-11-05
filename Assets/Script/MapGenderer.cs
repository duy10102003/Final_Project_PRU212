using UnityEngine.Tilemaps;
using UnityEngine;

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
    TileBase WallTile;
    [SerializeField]
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
        // Create a single wall tile around the perimeter of the map
        for (int x = 0; x < SizeX; x++)
        {
            wall.SetTile(new Vector3Int(x, 0, 0), WallTile); // Bottom wall
            wall.SetTile(new Vector3Int(x, SizeY - 1, 0), WallTile); // Top wall
        }

        for (int y = 0; y < SizeY; y++)
        {
            wall.SetTile(new Vector3Int(0, y, 0), WallTile); // Left wall
            wall.SetTile(new Vector3Int(SizeX - 1, y, 0), WallTile); // Right wall
        }
    }

    void DestructibleBuild()
    {
        for (int x = 1; x < SizeX - 1; x++)
        {
            for (int y = 1; y < SizeY - 1; y++)
            {
                // Skip the 2x2 areas in each corner
                if ((x <= 1 && y <= 2) ||            // Bottom-left corner
                    (x <= 1 && y >= SizeY - 3) ||    // Top-left corner
                    (x >= SizeX - 2 && y <= 2) ||    // Bottom-right corner
                    (x >= SizeX - 3 && y >= SizeY - 3)) // Top-right corner
                {
                    continue;
                }

                // Set a higher rate threshold to increase spawn chance (e.g., 60%)
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
                if ((x <= 1 && y <= 2) ||            // Bottom-left corner
                    (x <= 1 && y >= SizeY - 3) ||    // Top-left corner
                    (x >= SizeX - 3 && y <= 2) ||    // Bottom-right corner
                    (x >= SizeX - 2 && y >= SizeY - 3)) // Top-right corner
                {
                    continue;
                }

                int rate = Random.Range(1, 100);
                Vector3Int tilePosition = new Vector3Int(x, y, 0);

                // Place the indestructible tile in the indestructibleLayer
                if (rate > 40 && wall.GetTile(tilePosition) == null && destructable.GetTile(tilePosition) == null)
                {
                    indestructibleLayer.SetTile(tilePosition, InDestructible);
                }
            }
        }
    
}

}
