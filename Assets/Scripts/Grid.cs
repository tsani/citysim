using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

  public int width, height;
  public List<List<Tile>> tiles;
  public GameObject officePrefab;
  public GameObject housePrefab;
  public GameObject roadPrefab;
  public GameObject fourWayRoadPrefab;
  public GameObject tilePrefab;
  public GameObject grassPrefab;
  
	// Use this for initialization
	void Start () {
    tiles = new List<List<Tile>>();
    for(var i = 0; i < width; i++) {
      var next = new List<Tile>();
      for(var j = 0; j < height; j++) {
        next.Add(CreateTile(i, j));
      }
      tiles.Add(next);
    }
	}



  Tile CreateTile(int i, int j) {
    var obj = GameObject.Instantiate(tilePrefab, transform); 
    obj.transform.position = new Vector3(i * Constants.TILE_SIDE, 0, j * Constants.TILE_SIDE);
    var tile = obj.GetComponent<Tile>();
    tile.coords = new Coords {x = i, z = j};
    tile.ChangeModel(grassPrefab);
    tile.Clicked += OnTileClick;
    return tile;
  }

  void OnTileClick(Tile tile)
    {
      Debug.Log("OnTileClick");
      tile.ChangeModel(roadPrefab);
    }

  public Tile GetTile(Coords coords)
    {
      return tiles[coords.x][coords.z];
    }
  
  
	// Update is called once per frame
	void Update () {
		
	}
 
}
