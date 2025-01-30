using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private MeshRenderer meshRenderer;

    public float xyParallax;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        meshRenderer.material.mainTextureOffset = new Vector2(Camera.main.transform.position.x/(xyParallax*10f),
            Camera.main.transform.position.y/(xyParallax*10f));
    }
}
