using JetBrains.Annotations;
using UnityEngine;

namespace Helpers
{
    public class CharacterHelper
    {
        public bool IsSeeGameObject<T>(Transform transform, float distance, LayerMask layerMask, [CanBeNull] out T gameObject)
        {
            gameObject = default;
            var direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
            var hit = Physics2D.Raycast(transform.position, direction, distance, layerMask);
            return hit.collider && hit.collider.gameObject.TryGetComponent(out gameObject);
        }
    }
}