using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{

    public class Background : MonoBehaviour
    {

        private BackgroundType _CurrentBackground = BackgroundType.None;
        public BackgroundType CurrentBackground = BackgroundType.None;
        public BackgroundManager BackgroundManager;
        public SpriteRenderer SpriteRenderer;

        // Use this for initialization
        void Start()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();

            if (SpriteRenderer == null)
                Debug.LogError("No SpriteRenderer found on Background object");

            if (BackgroundManager == null)
                Debug.LogError("No BackgroundManager found on Background object");
        }

        // Update is called once per frame
        void Update()
        {
            if (CurrentBackground != _CurrentBackground)
            {
                _CurrentBackground = CurrentBackground;
                BackgroundManager.UpdateBackground(this);
            }
        }
    }
}