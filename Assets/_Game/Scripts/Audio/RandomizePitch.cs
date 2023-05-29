using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizePitch : MonoBehaviour
{
    [SerializeField] private AudioSource[] m_audioSources;
    [SerializeField] private float m_min, m_max;

    public void Randomize()
    {
        foreach (AudioSource a in m_audioSources)
        {
            a.pitch = Random.Range(m_min, m_max);
        }
    }
}