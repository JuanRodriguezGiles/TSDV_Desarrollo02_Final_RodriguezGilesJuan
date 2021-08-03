using System.Collections.Generic;
using System.Text;
using UnityEngine;
public class CrateSpawner : MonoBehaviour
{
    public float spawnTimer;
    public float spawnQuantity;
    public GameObject crate;
    GameObject _crateParent;
    Terrain _terrain;
    const int _minX = 40;
    const int _minZ = 40;
    int _maxX;
    int _maxZ;
    float _time;

    void Start()
    {
        _terrain = FindObjectOfType<Terrain>();
        _maxX = (int)_terrain.terrainData.bounds.max.x;
        _maxZ = (int)_terrain.terrainData.bounds.max.z;
        _crateParent = new GameObject("Crates");
        if (SaveManager.Instance.loaded) LoadCrates();
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
            int x = Random.Range(_minX, _maxX - 20);
            int z = Random.Range(_minZ, _maxZ - 20);
            float y = _terrain.SampleHeight(new Vector3(x, 0, z)) + 1;
            Vector3 position = new Vector3(x, y, z);

            GameObject go = Instantiate(crate, position, Quaternion.identity, _crateParent.transform);
        }
    }
    public void LoadCrates()
    {
        List<Position> crates = SaveManager.Instance.cratesTransforms;
        SaveManager.Instance.loaded = false;

        for (int i = 0; i < crates.Count; i++)
        {
            float x = crates[i].x;
            float y = crates[i].y;
            float z = crates[i].z;

            Vector3 position = new Vector3(x, y, z);

            GameObject go = Instantiate(crate, position, Quaternion.identity, _crateParent.transform);
        }
    }
}