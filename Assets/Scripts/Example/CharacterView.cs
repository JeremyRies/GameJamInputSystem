using UnityEngine;

namespace Example
{
    public class CharacterView : MonoBehaviour
    {
        public Vector2 Position
        {
            set { transform.position = value; }
        }
    }
}