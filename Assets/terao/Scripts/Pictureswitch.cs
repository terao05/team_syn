using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pictureswitch : MonoBehaviour
{
    public Texture[] artTextures;
    private int currentIndex = 0;
    private Renderer myRenderer;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        myRenderer.material.mainTexture = artTextures[currentIndex];
    }

    void OnMouseDown()
    {
        currentIndex = (currentIndex + 1) % artTextures.Length;
        myRenderer.material.mainTexture = artTextures[currentIndex];
    }
}