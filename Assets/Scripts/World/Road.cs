using UnityEngine;
using System.Collections.Generic;

[ExecuteAlways]
public class Road : MonoBehaviour
{
    public GameObject roadPrefab;
    public Player player;          // drag your Player object in inspector

    private readonly List<Transform> tiles = new();
    private float tileWidth;
    private float offscreenX;

    void Start()
    {
        tileWidth = roadPrefab.GetComponent<SpriteRenderer>().bounds.size.x;

        float screenWidth = 2f * Camera.main.orthographicSize * Camera.main.aspect;
        int tileCount = Mathf.CeilToInt(screenWidth / tileWidth) + 2;
        float startX = -screenWidth / 2f;

        for (int i = 0; i < tileCount; i++)
        {
            GameObject tile = Instantiate(roadPrefab, transform);
            tile.transform.position = new Vector3(startX + i * tileWidth, 0f, 0f);
            tiles.Add(tile.transform);
        }

        offscreenX = -screenWidth / 2f - tileWidth;
    }

    void Update()
    {
        MoveTiles(player.MovementInput);
        RecycleTiles();
    }

    void MoveTiles(Vector3 vel)
    {
        foreach (Transform tile in tiles)
        {
            tile.position -= vel;
        }
    }

    void RecycleTiles()
    {

        if (tiles.Count <= 0) { return; }
        Transform rightMost = tiles[0];
        foreach (Transform t in tiles)
            if (t.position.x > rightMost.position.x)
                rightMost = t;

        foreach (Transform tile in tiles)
        {
            if (tile.position.x < offscreenX)
            {
                tile.position = new Vector3(
                    rightMost.position.x + tileWidth,
                    tile.position.y,
                    tile.position.z
                );
                rightMost = tile;
            }
        }
    }
}
