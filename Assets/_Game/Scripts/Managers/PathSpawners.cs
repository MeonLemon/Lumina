using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawners : Singleton<PathSpawners>
{
    public Spawner[] m_spawners;
    public Spawner[] m_invertSpawner;

    public GameObject[] m_spawnables;
    public float spawnDelay = 1.5f;
    public bool isSpawning;
    public bool isInvert;

    private void Update()
    {
        if(!isInvert)
        {
            if (GameManager.Instance.gameState == GameState.Start)
            {
                if (isSpawning) return;
                int randomVal = Random.Range(1, 4);
                foreach (Spawner s in m_spawners)
                {
                    Debug.Log($"Random Value: {randomVal}");

                    if ((int)s.type == randomVal)
                    {
                        StartCoroutine(IsSpawning());
                        s.SpawnCollectable(true);
                    }
                    else
                    {
                        StartCoroutine(IsSpawning());
                        s.SpawnCollectable(false);
                    }

                }
            }
        }
        else
        {
            if (GameManager.Instance.gameState == GameState.Start)
            {
                if (isSpawning) return;
                int randomVal = Random.Range(1, 4);
                foreach (Spawner s in m_invertSpawner)
                {
                    Debug.Log($"Random Value: {randomVal}");

                    if ((int)s.type == randomVal)
                    {
                        StartCoroutine(IsSpawning());
                        s.SpawnCollectable(true);
                    }
                    else
                    {
                        StartCoroutine(IsSpawning());
                        s.SpawnCollectable(false);
                    }

                }
            }
        }
        
    }

    private IEnumerator IsSpawning()
    {
        isSpawning = true;
        yield return new WaitForSeconds(spawnDelay);
        isSpawning = false;
    }
}
