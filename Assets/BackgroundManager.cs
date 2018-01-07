using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public enum BackgroundType { None = -1, Red = 0, Blue = 1, Yellow = 2 };

    public class BackgroundManager : MonoBehaviour
    {

        public Background BackgroundPrefab;

        private Sprite[] BackgroundSprites;

        public Sprite Red;
        public Sprite Blue;
        public Sprite Yellow;

        // Use this for initialization
        void Start()
        {
            BackgroundSprites = new Sprite[] { Red, Blue, Yellow };
        }

        // Update is called once per frame
        void Update()
        {

        }

        public Background GetBackground(BackgroundType type, Transform parent)
        {
            var background = Instantiate<Background>(BackgroundPrefab, parent);
            background.CurrentBackground = type;

            return background;
        }

        public void UpdateBackground(Background background)
        {
            if (background.CurrentBackground == BackgroundType.None)
                background.SpriteRenderer.sprite = null;
            else
                background.SpriteRenderer.sprite = BackgroundSprites[(int)background.CurrentBackground];
        }
    }
}