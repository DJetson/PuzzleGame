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
        //public GameObject BackObject;
        public Glyph FrontObject;
        public GameObject NextManager;
        public Background BackObject;
        public int BoardX;
        public int BoardY;
        public int BoardIndex;

        //private int _BackState;
        //public int BackState
        //{
        //    get { return _BackState; }
        //    set { _BackState = (value % 4) - 1; Back = _BackState; }
        //}

        //private int _FrontState;
        //public int FrontState
        //{
        //    get { return _FrontState; }
        //    set { _FrontState = (value % 7) - 1; Front = _FrontState; }
        //}

        //public int Front;
        //public int Back;

        //public Sprite[] Backgrounds = new Sprite[3];
        //public Sprite[] Foregrounds = new Sprite[6];

        //public Sprite RedBack;
        //public Sprite BlueBack;
        //public Sprite YellowBack;

        //public Sprite Background;

        //public Sprite SmallCircle;
        //public Sprite LargeCircle;
        //public Sprite Ring;
        //public Sprite SmallSquare;
        //public Sprite LargeSquare;
        //public Sprite SquareBorder;

        //public Sprite Foreground;

        private SpriteRenderer spriteRendererBack;
        //private SpriteRenderer spriteRendererFront;


        // Use this for initialization
        void Start()
        {
            //if (BackObject != null)
            //    spriteRendererBack = BackObject.GetComponent<SpriteRenderer>();
            //if (FrontObject != null)
            //    spriteRendererFront = FrontObject.GetComponent<SpriteRenderer>();

            //if (spriteRendererBack != null)
            //    spriteRendererBack.sprite = Background;

            //if (spriteRendererFront == null)
            //    spriteRendererFront.sprite = Foreground;

            //BackState = 1;
            //FrontState = 0;

            //var trigger = GetComponent<EventTrigger>();
            //EventTrigger.Entry entry = new EventTrigger.Entry();
            //entry.eventID = EventTriggerType.PointerClick;
            //entry.callback.AddListener((data) => { OnPointerClickDelegate((PointerEventData)data); });
            //trigger.triggers.Add(entry);
        }

        public void OnMouseDown()
        {
            if (!Gameboard.IsClearOnClickEnabled)
            {
                SetCellFront();
            }
            else
            {
                Gameboard.ClearMatch(this);
                Gameboard.IsClearOnClickEnabled = false;
            }
        }

        //public void OnPointerClickDelegate(PointerEventData data)
        //{
        //    SetCellFront();
        //}

        // Update is called once per frame
        void Update()
        {
            UpdateStates();

            UpdateVisual();

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

        private void UpdateStates()
        {
            //if (BackObject.CurrentBackground = BackgroundType.None)
            //    Background = null;
            //else
                //Background = Backgrounds[BackState];

            //if (FrontState == -1)
            //    Foreground = null;
            //else
            //    Foreground = Foregrounds[FrontState];
        }

        private void UpdateVisual()
        {
            //if (spriteRendererBack != null)
            //    spriteRendererBack.sprite = Background;

            //if (spriteRendererFront != null)
            //    spriteRendererFront.sprite = Foreground;
        }

        public void SetCellFront()
        {
            var nextScript = NextManager.GetComponent<NextFront>();

            if (nextScript != null)
                nextScript.SetNext(this);
        }
    }
}