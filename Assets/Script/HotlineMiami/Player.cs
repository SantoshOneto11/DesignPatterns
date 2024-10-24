using UnityEngine;

namespace HotlineMiami
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        CharacterController _characterController;
        public static Player Instance { get; private set; }
        private Rigidbody2D rb;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            _characterController = GetComponent<CharacterController>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float xMove = Input.GetAxis("Horizontal");
            float yMove = Input.GetAxis("Vertical");

            _characterController.Move(new Vector3(xMove, yMove) * moveSpeed * Time.deltaTime);
        }
    }
}
