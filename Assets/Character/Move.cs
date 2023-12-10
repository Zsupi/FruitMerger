using UnityEngine;

namespace Character
{
    public class Move : MonoBehaviour
    {
        private const string RunningProperty = "running";
        private static readonly int Running = Animator.StringToHash(RunningProperty);

        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        private SpriteRenderer _sprite;
        private Transform _transform;

        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _sprite = GetComponent<SpriteRenderer>();
            _transform = gameObject.transform;
        }

        void Update()
        {
            float dir = Input.GetAxisRaw("Horizontal");
            _rigidbody2D.velocity = new Vector2(dir * 7f, 0);
            _transform.position = new Vector2(_transform.position.x, 3.5f);
            Animation(dir);

        }

        private void Animation(float dir)
        {
            if (dir > 0f)
            {
                _animator.SetBool(Running, true);
                _sprite.flipX = false;
            }
            else if (dir < 0f)
            {
                _animator.SetBool(Running, true);
                _sprite.flipX = true;
            }
            else
            {
                _animator.SetBool(Running, false);
            }
        }
    }
}
