using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControllerScript : MonoBehaviour
{
    public GameObject[] platformPrefab;
    public GameObject bonusPrefab;
    public GameObject obstaclePrefab;


    private List<GameObject> platforms;
    private int platformLength = 40;
    private System.Random random;
    private int[] rows = new int[3] { -2, 0, 2 };

    void Start()
    {
        random = new System.Random(15468);
        platforms = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject platform = Instantiate(platformPrefab[i]);
            platform.transform.position = new Vector3(0, 0, i) * platformLength;
            platforms.Add(platform);

            Vector3 platfomStart = new Vector3(0, 0, -10 + platformLength * i);
            int row = 0;
            platfomStart.y = 0.8f;
            for (int j = 0; j < 5; j++)
            {
                row = random.Next(0, 3);
                platfomStart.x = rows[row];
                platfomStart.z += 10;
                GameObject bonus = Instantiate(obstaclePrefab);
                bonus.transform.position = platfomStart;
                bonus.transform.SetParent(platform.transform);
            }

            row = random.Next(0, 3);
            platfomStart = new Vector3(0, 0, -20 + platformLength * i);
            platfomStart.x = rows[row];
            platfomStart.y = 1.5f;
            for (int j = 0; j < 3; j++)
            {
                platfomStart.z += 5;
                GameObject bonus = Instantiate(bonusPrefab);
                bonus.transform.position = platfomStart;
                bonus.transform.SetParent(platform.transform);
            }
        }
    }
    private void FixedUpdate()
    {
        foreach (GameObject platform in platforms)
        {
            platform.transform.position += new Vector3(0, 0, -4) * Time.fixedDeltaTime;
        }

        if (platforms[0].transform.position.z <= -platformLength + 5)
        {
            GameObject platform = platforms[0];
            platforms.RemoveAt(0);
            platform.transform.position = new Vector3(0, 0, platforms[3].transform.position.z + platformLength);
            platforms.Add(platform);
        }
    }


}
