using UnityEngine;
using System.Collections;

public class Tile4 : MonoBehaviour {
    private Map Tile_number;

    void Awake()
    {
        Tile_number = GameObject.Find("MapTileManager").GetComponent<Map>();
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(Tile_number.Tile[4], transform.position, transform.rotation);
    }
}
