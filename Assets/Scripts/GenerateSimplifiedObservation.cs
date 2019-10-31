using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GenerateSimplifiedObservation : MonoBehaviour
{
    private Camera cam;

    public int BlocksHorizontal;
    public int BlocksVertical;

    public RenderTexture renTexture;
    public float offsetX;
    public float offsetY;


    private Dictionary<string, Color> TagColorPair;
    private Texture2D tex;

    int imageCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        //renTexture = new RenderTexture(BlocksHorizontal, BlocksVertical, 0);
        cam = GetComponent<Camera>();
        TagColorPair = new Dictionary<string, Color>()
        {
            {"pacdot", new Color(1f, 0f, 0.3f) },
            {"pacman", Color.yellow },
            {"yellowghost", new Color(1f, 0.5f, 0.5f) },
            {"redghost", Color.red },
            {"pinkghost", Color.magenta },
            {"blueghost", Color.blue },
            {"wall", Color.cyan },
            {"Untagged", Color.black }
        };

        
    }


    void Update()
    {
        float screenPointX, screenPointY;
        tex = new Texture2D(BlocksHorizontal, BlocksVertical, TextureFormat.RGBA32, false);
        offsetX = (cam.pixelWidth / BlocksHorizontal) / 2f; //This is half a pixel
        offsetY = (cam.pixelHeight / BlocksVertical) / 2f; //This is half a pixel


        for (int i=0; i<BlocksHorizontal; i++)
        {
            for(int j=0; j<BlocksVertical; j++)
            {
                screenPointX = i * (cam.pixelWidth / BlocksHorizontal) + offsetX;
                screenPointY = j * (cam.pixelHeight / BlocksVertical) + offsetY;

                Ray ray = cam.ScreenPointToRay(new Vector3(screenPointX, screenPointY, 0));
                var hit = Physics2D.Raycast(ray.origin, ray.direction);
                Debug.DrawRay(ray.origin, ray.direction * 15f, Color.red);
                DetermineHit(hit, i, j);
            }
        }

        Graphics.Blit(tex, renTexture);
    }

    void DetermineHit(RaycastHit2D hit, int x, int y)
    {
        if(hit.transform != null)
        {
            string Tag = hit.transform.gameObject.tag;
            Color colorToDraw = Color.black;

            if (TagColorPair.ContainsKey(Tag))
                colorToDraw = TagColorPair[Tag];

            DrawToRendertexture(colorToDraw, x, y);
           } else
        {
            DrawToRendertexture(Color.green, x, y);

        }
    }

    void DrawToRendertexture(Color color, int pointX, int pointY)
    {

        tex.SetPixel(pointX, pointY, color);
        tex.Apply();
    }

    void UploadPNG()
    {


        byte[] bytes = tex.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/../testscreen-" + imageCount + ".png", bytes);
        imageCount++;
    }
}
