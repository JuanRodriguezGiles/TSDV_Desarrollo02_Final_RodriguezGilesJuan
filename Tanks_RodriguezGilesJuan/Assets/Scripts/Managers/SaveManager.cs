using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
[Serializable]
public struct Position
{
    public float x;
    public float y;
    public float z;
}
public class SaveManager : MonoBehaviourSingletonPersistent<SaveManager>
{
    public GameObject[] crates;
    public List<Position> cratesTransforms;
    public bool loaded = false;
    public void Load()
    {
        if (!File.Exists("cratesPositions.dat")) return;
        FileStream fs;
        BinaryFormatter bf = new BinaryFormatter();
        fs = File.OpenRead("cratesPositions.dat");
        cratesTransforms = (List<Position>)bf.Deserialize(fs);
        fs.Close();

        loaded = true;
    }
    public void Save()
    {
        crates = GameObject.FindGameObjectsWithTag("Crate");
        foreach (var t in crates)
        {
            Position pos;
            pos.x = t.transform.position.x;
            pos.y = t.transform.position.y;
            pos.z = t.transform.position.z;
            cratesTransforms.Add(pos);
        }

        FileStream fs;
        BinaryFormatter bf = new BinaryFormatter();
        fs = File.OpenWrite("cratesPositions.dat");
        bf.Serialize(fs, cratesTransforms);
        fs.Close();
    }
}