using UnityEngine;

namespace Quiz.Bundle
{
    [CreateAssetMenu(fileName = "New ColorBundle", menuName = "Color Bundle", order = 3)]
    public class ColorBundle : ScriptableObject
    {
        [SerializeField] private Color[] _color;

        public Color[] Color => _color;
    }
}