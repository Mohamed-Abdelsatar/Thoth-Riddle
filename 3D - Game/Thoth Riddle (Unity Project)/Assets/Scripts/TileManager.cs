using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform playerTranform;
    private GameObject BaseGround;
    private float spawnZ = 80.0f;
    private float tileLength = 80.0f;
    private int amnTileOnScreen = 3;
    private float safeZone = 80.0f;
    private List<GameObject> activeTiles;
    private int lastPrefabsIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();

        playerTranform = GameObject.FindGameObjectWithTag("Player").transform;

        BaseGround = GameObject.FindGameObjectWithTag("BaseGround");


        for (int i = 0; i < amnTileOnScreen; i++)
        {
            if (i < 1)
                SpawnTile(0);
            else
                SpawnTile();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTranform.position.z - safeZone  > (spawnZ - amnTileOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
            Destroy(BaseGround);
        }
        
    }
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if(prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomPrefabsIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;   
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private int RandomPrefabsIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;
        int randomIndex = lastPrefabsIndex;

        while (randomIndex == lastPrefabsIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabsIndex = randomIndex;
        return randomIndex;

    }



}
