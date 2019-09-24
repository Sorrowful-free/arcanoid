using UnityEngine;

namespace GamePlayFramework
{
    public class Wall : MonoBehaviour
    {
        public void Initialize(Vector2 size, Vector2 position)
        {
            GetComponent<BoxCollider2D>().size = GetComponent<SpriteRenderer>().size = size;
            transform.position = position;
        }
    }
}