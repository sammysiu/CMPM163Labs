using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildCity : MonoBehaviour
{
    public GameObject[] buildings;
    public GameObject xstreets;
    public GameObject zstreets;
    public GameObject crossroad;
    public int mapWidth = 20;
    public int mapHeight = 20;
    int[,] mapgrid;
    public float perlinScaling = 10.0F;
    int buildingFootprint = 3;

    // Start is called before the first frame update
    void Start()
    {
        float seed = Random.Range(0,100);
        print("Seed : ");
        print(seed);
        print("\n");
        mapgrid = new int[mapWidth, mapHeight];

        // generate map data
        for(int h = 0; h < mapHeight; h++)
        {
            for(int w = 0; w < mapWidth; w++) {
                mapgrid[w,h] = (int) (Mathf.PerlinNoise(w/perlinScaling + seed, h/perlinScaling + seed) * 10);
            }
        }

        // build streets
        int x = 0;
        for(int n = 0; n <50; n++)
        {
            for(int h = 0; h < mapHeight; h++)
            {
                mapgrid[x,h] = -1;
            }
            x += Random.Range(10,25);
            if(x >= mapWidth) break;
        }

        int z = 0;
        for(int n = 0; n <10; n++)
        {
            for(int w = 0; w < mapWidth; w++)
            {
                if(mapgrid[w,z] == -1) // crossroads
                    mapgrid[w,z] = -3;
                else
                    mapgrid[w,z] = -2;
            }
            z += Random.Range(10,25);
            if(z >= mapHeight) break;
        }

        // generate city
        for(int h = 0; h < mapHeight; h++)
        {
            for(int w = 0; w < mapWidth; w++) {
                int result = mapgrid[w,h];
                Vector3 pos = new Vector3(w * buildingFootprint, 0, h * buildingFootprint);

                if(result < -2)
                    Instantiate(crossroad, pos, crossroad.transform.rotation);
                else if(result < -1) 
                    Instantiate(xstreets,pos,xstreets.transform.rotation);
                else if(result < 0) 
                    Instantiate(zstreets,pos,zstreets.transform.rotation);
                else if(result < 1)
                    Instantiate(buildings[0], pos, Quaternion.identity);
                else if(result < 2)
                    Instantiate(buildings[1], pos, Quaternion.identity);
                else if(result < 3)
                    Instantiate(buildings[2], pos, Quaternion.identity);
                else if(result < 4)
                    Instantiate(buildings[3], pos, Quaternion.identity);
                else if(result < 5)
                    Instantiate(buildings[4], pos, Quaternion.identity);
                else if(result < 6)
                    Instantiate(buildings[5], pos, Quaternion.identity);
                else if(result < 7) {
                    int rand = Random.Range(0,3);
                    switch (rand) {
                        case 0:
                            Instantiate(buildings[8], pos, Quaternion.identity);
                            break;
                        case 1:
                            Instantiate(buildings[9], pos, Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(buildings[10], pos, Quaternion.identity);
                            break;
                        case 3:
                            Instantiate(buildings[11], pos, Quaternion.identity);
                            break;
                        default:
                            Instantiate(buildings[8], pos, Quaternion.identity);
                            break;
                    } 
                }
                else if(result < 10)
                    Instantiate(buildings[6], pos, Quaternion.identity);
                else
                    Instantiate(buildings[7], pos, Quaternion.identity);
            }
        }
    }
}
