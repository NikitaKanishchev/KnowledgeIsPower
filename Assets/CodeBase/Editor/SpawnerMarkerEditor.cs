using CodeBase.Logic.EnemySpawners;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(SpawnMarker))]
    public class SpawnerMarkerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.NonSelected | GizmoType.Active | GizmoType.Pickable)]
        public static void RenderCustomGizmo(SpawnMarker spawner, GizmoType gizmoType)
        {
            CircleGizmo(spawner.transform, 0.5f, Color.red);
        }

        private static void CircleGizmo(Transform transform, float radius, Color color)
        {
            Gizmos.color = color;
            Vector3 pos = transform.position;
            Gizmos.DrawSphere(pos, radius);
        }
    }
}