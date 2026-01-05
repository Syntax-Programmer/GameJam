using System;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class WorldGen2D : MonoBehaviour
{

    [SerializeField] private int width = 128;
    [SerializeField] private int height = 128;
    private long seed = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

    [SerializeField] private float scale = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PerlinGen(); 
    }

    private void PerlinGen()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xCoord = (float)(x + seed) / scale;
                float yCoord = (float)(y + seed) / scale;

                float noise = Mathf.PerlinNoise(xCoord, yCoord);

                Color color = new Color(noise, noise, noise);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();

        GetComponent<Renderer>().material.mainTexture = texture;
    }

}
