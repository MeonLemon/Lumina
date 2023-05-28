using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public NodeType type;
    public float spawnDelay = 1.5f;

    public void SpawnCollectable(bool isGood = false)
    {
        StartCoroutine(Spawn(isGood));
    }

    private IEnumerator Spawn(bool isGood)
    {
        yield return new WaitForSeconds(spawnDelay);
        Debug.Log($"Type: {type} / {isGood}");

        if(isGood)
        {
            var spawnedObj = Instantiate(PathSpawners.Instance.m_spawnables[0], gameObject.transform);
        }
    }
}
