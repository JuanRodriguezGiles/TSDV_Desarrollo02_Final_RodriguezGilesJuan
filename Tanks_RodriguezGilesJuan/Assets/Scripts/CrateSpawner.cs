using System.Collections.Generic;
using UnityEngine;
public class CrateSpawner : MonoBehaviour
{
    public float spawnTimer;
    public float spawnQuantity;
    public GameObject crate;
    GameObject _crateParent;
    Terrain _terrain;
    const int _minX = 5;
    const int _minZ = 5;
    int _maxX;
    int _maxZ;
    float _time;
    void Start()
    {
        _terrain = FindObjectOfType<Terrain>();
        _maxX = (int)_terrain.terrainData.bounds.max.x;
        _maxZ = (int)_terrain.terrainData.bounds.max.z;
        _crateParent = new GameObject("Crates");
    }
    void Update()
    {
        _time += Time.deltaTime;
        if (_time < spawnTimer) return;
        _time = 0;
        SpawnCrate();
    }
    void SpawnCrate()
    {
        for (int i = 0; i < spawnQuantity; i++)
        {
            int x = Random.Range(_minX, _maxX);
            int z = Random.Range(_minZ, _maxZ);
            float y = _terrain.terrainData.GetHeight(x, z) + 1;
            Vector3 position = new Vector3(x, y, z);

            GameObject go = Instantiate(crate, position, Quaternion.identity, _crateParent.transform);
        }
    }
}