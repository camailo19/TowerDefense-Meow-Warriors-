using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelManager : Singleton<LevelManager>
{

    [SerializeField] private GameObject[] tiles;

    //  public TileData[][] mTiles = new TileData[10][17];

    public Dictionary<PositionPoint, ClickController> Tiles { get; set; }

    [SerializeField] private Transform map;

    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
    }

    public float TileSize
    {
        get { return tiles[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void CreateLevel()
    {
        Tiles = new Dictionary<PositionPoint, ClickController>();

        string[] mapData = ReadLevelText();

        int mapX = mapData[0].ToCharArray().Length;
        Debug.Log("hola es: " + mapX);
        int mapY = mapData.Length;
        Debug.Log("y ES : " + mapY);
        Vector3 maxTile = Vector3.zero;

        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

        for (int y = 0;y < mapY; y++)
        {
             
        char[] newTiles = mapData[y].ToCharArray();

            for (int x = 0; x < mapX; x++)
            {
                PlaceTile(newTiles[x].ToString(),x,y, worldStart);
            }
        }
        maxTile = Tiles[new PositionPoint(mapX - 1, mapY - 1)].transform.position;
    }

   

    private void PlaceTile(string tileType, int x,int y, Vector3 worldStart)
    { 
        int tileIndex = int.Parse(tileType);
        ClickController  newTile = Instantiate(tiles[tileIndex]).GetComponent<ClickController>();
        newTile.name = $"Tile {x} {y}";
        newTile.Setup(new PositionPoint(x, y), new Vector3(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y), 0),map);
    }

    private string[] ReadLevelText()
    {
        TextAsset binddata = Resources.Load("Level") as TextAsset;

        string data = binddata.text.Replace(Environment.NewLine, string.Empty);
        return data.Split('-');
    }







}
