using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public enum GlyphType { None = -1, SmallCircle = 0, LargeCircle = 1, Ring = 2, SmallSquare = 3, LargeSquare = 4, SquareBorder = 5 };

    public class GlyphManager : MonoBehaviour
    {

        public Glyph GlyphPrefab;

        private Sprite[] GlyphSprites;

        public Sprite SmallCircle;
        public Sprite LargeCircle;
        public Sprite Ring;
        public Sprite SmallSquare;
        public Sprite LargeSquare;
        public Sprite SquareBorder;

        // Use this for initialization
        void Start()
        {
            GlyphSprites = new Sprite[] { SmallCircle, LargeCircle, Ring, SmallSquare, LargeSquare, SquareBorder };
        }

        // Update is called once per frame
        void Update()
        {

        }

        public Glyph GetGlyph(GlyphType type, Transform parent)
        {
            var glyph = Instantiate<Glyph>(GlyphPrefab, parent);
            glyph.CurrentGlyph = type;

            return glyph;
        }

        public void UpdateGlyph(Glyph glyph)
        {
            if (glyph.CurrentGlyph == GlyphType.None)
                glyph.SpriteRenderer.sprite = null;
            else
                glyph.SpriteRenderer.sprite = GlyphSprites[(int)glyph.CurrentGlyph];
        }
    }
}