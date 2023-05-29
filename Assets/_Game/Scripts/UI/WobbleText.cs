using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WobbleText : MonoBehaviour
{
    [SerializeField] public TMP_Text m_textComponent;
    [SerializeField] private float m_speed = 2f;
    [SerializeField] private float m_pos = 0.01f;
    [SerializeField] private float m_wave = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_textComponent.ForceMeshUpdate();
        var textInfo = m_textComponent.textInfo;
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible)
            {
                continue;

            }
            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;


            for (int j = 0; j < 4; ++j)
            {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * m_speed + orig.x * m_pos) * m_wave, 0);

            }
        }
        for (int i = 0; i < textInfo.meshInfo.Length; ++i)
        {

            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            m_textComponent.UpdateGeometry(meshInfo.mesh, i);

        }

    }

}