using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    [SerializeField] Transform _cube;
    [SerializeField] Chunk[] _chunkPrefabs;
    [SerializeField] Chunk _firstChunk;

    private List<Chunk> spawnedChunks = new List<Chunk>();

    private void Start()
    {
        spawnedChunks.Add(_firstChunk);
        SpawnChunk();
        SpawnChunk();


    }
    private void Update()
    {
        //Debug.Log(_cube.position.x);
        //Debug.Log(_cube.position.x);
        //Debug.Log(spawnedChunks[spawnedChunks.Count - 1].get_end().position);
        if(_cube.position.x > spawnedChunks[spawnedChunks.Count - 2].get_begin().position.x)
        {
            SpawnChunk();
        }

        if (spawnedChunks.Count > 4)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }

        if (_cube.position.y < -10)
        {
            _cube.position = spawnedChunks[0].get_end().position;

            //_rigidbody.transform.position = new Vector3(0, 1, 2);
        }
    }
    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(_chunkPrefabs[Random.Range(0, _chunkPrefabs.Length)]);
        //Debug.Log(newChunk.get_end().position);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].get_end().position - newChunk.get_begin().localPosition;
        GameObject mesh = newChunk.get_meshCollider();
        MeshCollider collider = mesh.AddComponent(typeof(MeshCollider)) as MeshCollider;
        spawnedChunks.Add(newChunk);
    }

    public Vector3 GetFirstChunckEndPos()
    {
        return spawnedChunks[0].get_end().position;
    }

}
