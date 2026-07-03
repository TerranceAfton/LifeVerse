using UnityEngine;

namespace LifeVerse.Camera
{
    [CreateAssetMenu(
        menuName = "LifeVerse/Camera Settings")]
    public class CameraSettings : ScriptableObject
    {
        [Header("Movement")]

        public float MoveSpeed = 12f;

        public float RotationSpeed = 120f;

        public float ZoomSpeed = 8f;

        [Header("Zoom")]

        public float MinHeight = 5f;

        public float MaxHeight = 35f;

        [Header("Smoothing")]

        public float SmoothTime = 0.12f;
    }
}