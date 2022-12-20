using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public List<GameObject> planes = new List<GameObject>();
    public int activeplanes = 5, backstep = 2;
    public GameObject prefab;

    Transform cube;
    void Start()
    {
        cube = gameObject.transform;
        for(int i = 0; i < activeplanes; i++)
        {
            GameObject listitem;
            float planesizeX = prefab.transform.localScale.x;
            listitem = Instantiate(prefab, new Vector3(cube.position.x-(planesizeX * (backstep - i)),0,0), Quaternion.identity);
            planes.Add(listitem);
        }
    }

    void Update()
    {
        float planesizeX = prefab.transform.localScale.x;

        if ((cube.position.x - planes[0].transform.position.x) > planesizeX * backstep)
        {
            Destroy(planes[0]);
            planes.RemoveAt(0);
            GameObject listitem;
            listitem = Instantiate(prefab, new Vector3(planes[planes.Count - 1].transform.position.x + planesizeX, 0, 0), Quaternion.identity);
            planes.Add(listitem);

        }
    }
}
