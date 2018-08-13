using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
  public event Action<Tile> Clicked;
  public event Action<Tile> ModelChanged;
  public Coords coords;
  public Grid grid;

	// Use this for initialization
  public void ChangeModel(GameObject model) {
    if(this.gameObject.transform.childCount > 0)
      Destroy(this.gameObject.transform.GetChild(0).gameObject);
    var obj = GameObject.Instantiate(model, transform);

    var colliderProxy = obj.GetComponent<ColliderProxy>();
    if(colliderProxy != null) {
      Debug.Log("collider proxy not null");
      colliderProxy.Clicked += OnModelClicked;
    }

    if(null != ModelChanged)
      ModelChanged(this);
  }

  void OnModelClicked() {
    Debug.Log("my model got clicked");
    if(null != Clicked)
      Clicked(this);
  }
	
	// Update is called once per frame
	void Awake () {
    grid = GetComponentInParent<Grid>();
		
	}
  
 
  public List<Tuple<Tile, Direction>> GetNeighbours () {
    var neighbs = new List<Tuple<Tile, Direction>>();
    //z+1, z-1, x+1, x-1

   // var xs = new int[]{0, 0, -1, 1};
   // var zs = new int[]{1, -1, 0, 0};

    foreach(Direction d in new Direction[]{Direction.n, Direction.e, Direction.s, Direction.w}) 
    {
      neighbs.Add(Tuple.Create(grid.GetTile(d.ToCoords() + this.coords), d));
    }
    return neighbs;

  

  }
}
