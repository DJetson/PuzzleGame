using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Scripts
{
    public class Gameboard : MonoBehaviour
    {
        public BackgroundManager BackgroundManager;
        public GlyphManager GlyphManager;
        public bool IsClearOnClickEnabled = false;

        public int BoardSize = 5;

        public Cell[] Cells;

        public Cell PrefabCell;

        // Use this for initialization
        void Start()
        {
            Cells = new Cell[BoardSize * BoardSize];

            for (int i = 0; i < BoardSize * BoardSize; i++)
            {
                Cells[i] = Instantiate<Cell>(PrefabCell, this.transform);
                Cells[i].Gameboard = this;
                Cells[i].BoardX = i % BoardSize;
                Cells[i].BoardY = i / BoardSize;
                Cells[i].BoardIndex = i;
                var transform = Cells[i].GetComponent<Transform>();
                if (transform == null)
                    Debug.LogError("Cell.Transform Component was null");
                else
                    transform.position = new Vector3((float)(1.5 * (i % BoardSize)), (float)(1.5 * (i / BoardSize)), Cells[i].transform.position.z);
                Cells[i].BackObject = BackgroundManager.GetBackground(BackgroundType.Red, Cells[i].transform);
            }
        }

        public void OnClickClearMatchButton()
        {
            if (IsClearOnClickEnabled)
                IsClearOnClickEnabled = false;
            else
                IsClearOnClickEnabled = true;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ClearMatch(Cell cell)
        {
            List<Cell> matchedCells = new List<Cell>();
            MapMatchingNeighbors(ref matchedCells, cell);

            UpdateMatchCells(matchedCells);
        }

        private void UpdateMatchCells(List<Cell> matchedCells)
        {
            foreach(var cell in matchedCells)
            {
                cell.BackObject.CurrentBackground = (BackgroundType)((((int)cell.BackObject.CurrentBackground) + 1) % 3);
                //cell.BackState = cell.BackState++;
                cell.FrontObject.CurrentGlyph = GlyphType.None;
            }
        }

        private void MapMatchingNeighbors(ref List<Cell> matchedCells, Cell cell)
        {
            GlyphType type = cell.FrontObject.CurrentGlyph;
            int background = (int)cell.BackObject.CurrentBackground;

            List<Cell> toCheck = new List<Cell>();
            Cell[] neighbors = new Cell[4];
            neighbors[0] = GetCellAt(cell.BoardX - 1, cell.BoardY);
            neighbors[1] = GetCellAt(cell.BoardX, cell.BoardY - 1);
            neighbors[2] = GetCellAt(cell.BoardX + 1, cell.BoardY);
            neighbors[3] = GetCellAt(cell.BoardX, cell.BoardY + 1);

            for (int i = 0; i < 4; i++)
            {
                if(neighbors[i] != null && neighbors[i].FrontObject != null && neighbors[i].FrontObject.CurrentGlyph == type && neighbors[i].BackObject.CurrentBackground == (BackgroundType)background && !matchedCells.Contains(neighbors[i]))
                {
                    toCheck.Add(neighbors[i]);
                }
            }

            matchedCells.Add(cell);

            foreach (var item in toCheck)
                MapMatchingNeighbors(ref matchedCells, item);

            return;
        }

        public Cell GetCellAt(int x, int y)
        {
            int index = (y * BoardSize) + x;

            if (index >= BoardSize * BoardSize || x > BoardSize - 1 || x < 0 || y > BoardSize - 1 || y < 0)
            {
                Debug.LogWarning(String.Format("GetCellAt({0}, {1}) failed. Index out of range.", x, y));
                return null;
            }

            return Cells[index];
        }
    }
}