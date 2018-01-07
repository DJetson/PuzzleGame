using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Glyph : MonoBehaviour
    {
        private GlyphType _CurrentGlyph = GlyphType.None;
        public GlyphType CurrentGlyph = GlyphType.None;
        public GlyphManager GlyphManager;
        public SpriteRenderer SpriteRenderer;

        // Use this for initialization
        void Start()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();

            if (SpriteRenderer == null)
                Debug.LogError("No SpriteRenderer found on Glyph object");

            if(GlyphManager == null)
                Debug.LogError("No GlyphManager found on Glyph object");
        }

        // Update is called once per frame
        void Update()
        {
            if(CurrentGlyph != _CurrentGlyph)
            {
                _CurrentGlyph = CurrentGlyph;
                GlyphManager.UpdateGlyph(this);
            }
        }
    }
}
