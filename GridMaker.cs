using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    public GameObject prefab;
    public float x;
    public float z;
    void Start()
    {
        StartCoroutine(GenerateMap());
    }

    private IEnumerator GenerateMap()
    {
        float staticOffset_x = prefab.transform.localScale.x * 0.5f;
        float staticOffset_z = prefab.transform.localScale.z * 0.5f;

        float v = x * staticOffset_x;
        for (float i = v - staticOffset_x; i > -v; i -= staticOffset_x * 2)
        {
            float b = z * staticOffset_z;
            for (float j = b - staticOffset_z; j > -b; j -= staticOffset_z * 2)
            {
                GameObject go = Instantiate(prefab, new Vector3(i, 1, j), transform.rotation);
                go.transform.SetParent(transform);
                yield return null;
            }
        }
    }
}
