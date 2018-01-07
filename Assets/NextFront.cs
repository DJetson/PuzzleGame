using Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextFront : MonoBehaviour
{
    public Glyph[] NextGlyphs;

    public GlyphManager GlyphManager;

    public int ShowNextCount = 5;
    public int[] Upcoming = new int[20];
    private System.Random rng;
    // Use this for initialization
    void Start()
    {
        if (GlyphManager == null)
            Debug.LogError("No GlyphManager component found on NextFront");

        NextGlyphs = new Glyph[ShowNextCount];

        rng = new System.Random((int)DateTime.Now.Ticks);

        //for (int i = 0; i < 20; i++)
        //{
        //    Upcoming[i] = GetNextRandom();
        //}

        for (int i = 0; i < ShowNextCount; i++)
        {
            NextGlyphs[i] = GlyphManager.GetGlyph((GlyphType)rng.Next(0, 6), this.transform);
            var transform = NextGlyphs[i].GetComponent<Transform>();
            transform.position = new Vector3(transform.position.x + (1.5f * (ShowNextCount - (i + 1))), transform.position.y, transform.position.z);
        }
    }

    int GetNextRandom()
    {
        return rng.Next(0, 7);
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void SetNext(Cell cell)
    {
        //cell.FrontState = this.Upcoming[0];
        cell.FrontObject = GlyphManager.GetGlyph(NextGlyphs[0].CurrentGlyph, cell.transform);
        //for (int i = 1; i < 20; i++)
        //{
        //    Upcoming[i - 1] = Upcoming[i];
        //}
        Upcoming[19] = GetNextRandom();

        for (int i = 1; i < ShowNextCount; i++)
        {
            NextGlyphs[i - 1].CurrentGlyph = NextGlyphs[i].CurrentGlyph;
        }

        NextGlyphs[ShowNextCount - 1].CurrentGlyph = (GlyphType)rng.Next(0, 6);
        //for (int i = 0; i < ShowNextCount; i++)
        //{
        //    NextGlyphs[i].CurrentGlyph = (GlyphType)Upcoming[i];
        //}
    }
}
