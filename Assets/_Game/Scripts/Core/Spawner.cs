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

    public void SpawnCollectableInvert(bool isGood = false)
    {
        StartCoroutine(SpawnInvert(isGood));
    }

    private IEnumerator Spawn(bool isGood)
    {
        yield return new WaitForSeconds(spawnDelay);
        Debug.Log($"Type: {type} / {isGood}");

        if(isGood)
        {
            var spawnedObj = Instantiate(PathSpawners.Instance.m_spawnables[0], gameObject.transform);
        }
        else
        {
            var spawnedObj = Instantiate(PathSpawners.Instance.m_spawnables[1], gameObject.transform);
        }
    }

    private IEnumerator SpawnInvert(bool isGood)
    {
        yield return new WaitForSeconds(spawnDelay);
        Debug.Log($"Type: {type} / {isGood}");

        if (isGood)
        {
            var spawnedObj = Instantiate(PathSpawners.Instance.m_spawnables[2], gameObject.transform);
        }
        else
        {
            var spawnedObj = Instantiate(PathSpawners.Instance.m_spawnables[3], gameObject.transform);
        }
    }
}
