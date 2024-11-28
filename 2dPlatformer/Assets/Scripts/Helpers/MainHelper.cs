using JetBrains.Annotations;
using UnityEngine;

namespace Helpers
{
    public static class MainHelper
    {
        public static bool IsSeeGameObject<T>(Transform transform, float distance, LayerMask layerMask, [CanBeNull] out T gameObject)
        {
            gameObject = default;
            var direction = GetDirection(transform);
            var hit = Physics2D.Raycast(transform.position, direction, distance, layerMask);
            return hit.collider && hit.collider.gameObject.TryGetComponent(out gameObject);
        }
        
        private static Vector2 GetDirection(Transform transform)
        {
            return transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        }
    }
}