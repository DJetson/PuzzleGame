using Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace Scripts
{
    public class Cell : MonoBehaviour
    {
        public Gameboard Gameboard;
        public Glyph FrontObject;
        public GameObject NextManager;
        public Background BackObject;
        public int BoardX;
        public int BoardY;
        public int BoardIndex;

        private SpriteRenderer spriteRendererBack;


        // Use this for initialization
        void Start()
        {
            
        }

        public void OnMouseDown()
        {
            if (!Gameboard.IsClearOnClickEnabled)
            {
                if (FrontObject != null && FrontObject.CurrentGlyph != GlyphType.None)
                    return;
                SetCellFront();
            }
            else
            {
                if (FrontObject == null || FrontObject.CurrentGlyph == GlyphType.None)
                    return;

                Gameboard.ClearMatch(this);
                Gameboard.IsClearOnClickEnabled = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            for (var i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
                    // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
                    if (hitInfo)
                    {
                        Debug.Log(hitInfo.transform.gameObject.name);

                        if (hitInfo.transform.gameObject.name == "Cell")
                            SetCellFront();
                    }
                }
            }
        }

        public void SetCellFront()
        {
            var nextScript = NextManager.GetComponent<NextFront>();

            if (nextScript != null)
                nextScript.SetNext(this);
        }
    }
}