using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturePainter : MonoBehaviour {
    [Range(0, 128)]
    public int textureWidth = 16;
    [Range(0, 128)]
    public int textureHeight = 16;

    public Color foregroundColor = Color.green;
    public Color backgroundColor = Color.yellow;

    private Texture2D texture2d;


	void Start ()
    {
        CreateTexture();
        FillTexture(backgroundColor);
	}

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            WhileMousePressed();
    }

    private void CreateTexture()
    {
        texture2d = new Texture2D(textureWidth, textureHeight);
        texture2d.filterMode = FilterMode.Point;
        this.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", texture2d);
    }

    private void FillTexture(Color color)
    {
        Color[] pixels = texture2d.GetPixels();
        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = color;
        }
        texture2d.SetPixels(pixels);
        texture2d.Apply();
    }

    Vector2Int uvtoPixelCoords(Vector2 uv)
    {
        int x = Mathf.FloorToInt(uv.x * textureWidth);
        int y = Mathf.FloorToInt(uv.y * textureHeight);
        return new Vector2Int(x, y);
    }

    private void Stroke(Vector2Int pixelCoord, Color color)
    {
        texture2d.SetPixel(pixelCoord.x, pixelCoord.y, color);
        texture2d.Apply();
    }

    private void WhileMousePressed()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            Stroke(uvtoPixelCoords(hitInfo.textureCoord), foregroundColor);
        }
    }
}
