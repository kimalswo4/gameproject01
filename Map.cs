using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    public GameObject[] Tile;
	public int length,height; 
	public int[] Construcao;
    private int c = 0;
    
	private int[,] position; 
		

	void Start () {
		position = new int[length, height];
        //int [] change = new int[] {0,1,2,0,1,0,1,2,0,1};
        /*
		if ((length * height) > Construcao.Length) {
			Debug.Log (length * height);
		}*/
			for (int x = 0; x < length; x++) {
				
				for (int y = 0; y < height; y++) {
				
					position [x, y] = Construcao [x * height + y];

				}
			}
                 
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        Vector2 positionBidmesional = new Vector2(i-9.5f, j-4.5f);
                        if (position[i, j] < Tile.Length)
                        {                           
                            Instantiate(Tile[9], positionBidmesional, transform.rotation);
                            c++;
                        }
                        else
                        {
                            Debug.Log(" ");
                        }
                    }
                }
            
		
	}

    
}
