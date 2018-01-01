using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject prefab;
    public int numberOfObjects;
    public float radius;
    public float heightTimesRadius;

    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), heightTimesRadius, Mathf.Sin(angle)) * radius;
            Instantiate(prefab, pos, Quaternion.identity);
        }
    }
}
