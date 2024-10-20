using UnityEngine;

namespace ModTheCube {
    public class Cube : MonoBehaviour
    {
        public MeshRenderer Renderer;
        public float rotationSpeed = 10.0f;
        public float rotationAngle = 5.0f;
        public float scale = 1.3f;
        public Color color = Color.red;
        public int maxPosition = 6;
        private Material material;
        private float moveSpeed = 5f;

        void Start()
        {
            var xPos = Random.Range(0, maxPosition);
            var yPos = Random.Range(0, maxPosition);
            var zPos = Random.Range(0, maxPosition);
            transform.position = new Vector3(xPos, yPos, zPos);
            material = Renderer.material;
            InvokeRepeating(nameof(ChangeDirection), 2f, 5f);
            InvokeRepeating(nameof(ChangeColor), 0f, 3f);
            InvokeRepeating(nameof(ChangeScale), 0f, 1f);
        }

        private void ChangeDirection()
        {
            moveSpeed = -moveSpeed;
        }
        private void ChangeColor()
        {
            Color randomColor = Random.ColorHSV();
            color = randomColor;
        }
        private void ChangeScale()
        {
            scale = Random.Range(1, 5);
        }

        void Update()
        {
            transform.Rotate(rotationSpeed * Time.deltaTime, rotationAngle, -rotationAngle);
            material.color = color;
            transform.localScale = Vector3.one * scale;
            transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));
        }
    }
}
