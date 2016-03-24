using UnityEngine;
using System.Collections;

public class Tile8 : MonoBehaviour {
    private Map Tile_number;

    void Awake()
    {
        Tile_number = GameObject.Find("MapTileManager").GetComponent<Map>();
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(Tile_number.Tile[8], transform.position, transform.rotation);
    }
}
