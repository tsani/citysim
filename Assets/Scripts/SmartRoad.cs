using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Coords{
  public int x, z;
  public static Coords operator+ (Coords x, Coords z) =>
    new Coords {x = x.x + z.x, z = x.z + z.z};
}

public enum Direction{n, e, s, w} 
public static class DirectionExt{

  public static Coords ToCoords(this Direction d)
    {
      switch (d)
      {
      case Direction.n:
        return new Coords {x = 0, z = 1};
      case Direction.e:
        return new Coords {x = 1, z = 0};
      case Direction.s:
        return new Coords {x = 0, z = -1};
      case Direction.w:
        return new Coords {x = -1, z = 0};
      }
      throw new Exception("uhhhhh impossible");
    }
}
public class SmartRoad : MonoBehaviour {

  public Tile tile;
  Dictionary<Direction, Tile> roadNeighbours;
  Grid grid;
	// Use this for initialization
	void Start () {
    roadNeighbours = new Dictionary<Direction, Tile>();
    grid = GetComponentInParent<Grid>();
    tile = GetComponentInParent<Tile>();
    
    IsRoadTile();
    var t = UpdateRoadGraphic();
    GameObject.Instantiate(t.Item1, transform);
   
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
  void IsRoadTile(){
    foreach(Tuple<Tile, Direction> t in this.tile.GetNeighbours())
    {

      var smartRoad = t.Item1.GetComponentInChildren<SmartRoad>();
      if(smartRoad != null)
      {roadNeighbours.Add(t.Item2, t.Item1);
        
        }

    }

  }

  Tuple<GameObject, float> UpdateRoadGraphic()


    {if(roadNeighbours.Count == 4)
        return Tuple.Create(grid.fourWayRoadPrefab, 0f);
      throw new Exception("ugh");
    }
        
}
