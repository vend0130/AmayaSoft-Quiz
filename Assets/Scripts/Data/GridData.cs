using UnityEngine;
using System;

namespace Quiz.Data
{
    [Serializable]
    public class GridData
    {
        [SerializeField] private int _level;
        [SerializeField] private int _rows;
        [SerializeField] private int _columns;

        public int Level => _level;
        public int Rows => _rows;
        public int Colums => _columns;

        public int CountCells => _rows * _columns;
    }
}