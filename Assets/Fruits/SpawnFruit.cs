using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Fruits
{
    public class SpawnFruit : MonoBehaviour
    {
        public List<GameObject> fruits;
        public int maxSpawnableFruitIdx = 3;
        public GameObject player;

        public float timeThreshold = 0.5f;

        private float _lastActionTime;
        private Fruit _nextFruit;
        private bool _spawnable = false;

        void Start()
        {
            _lastActionTime = Time.time;
            _nextFruit = Spawn();
        }

        void Update()
        {
            if (Time.time - _lastActionTime > timeThreshold)
            {
                if (_spawnable)
                {
                    _nextFruit = Spawn();
                    _spawnable = false;
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine(_nextFruit.Fall());
                    _spawnable = true;
                    _lastActionTime = Time.time;
                }
                _nextFruit.UpdatePosition(CalcPosition());
            }
        }

        private Fruit Spawn()
        {
            var randomIdx = Random.Range(0, maxSpawnableFruitIdx);
            var position = CalcPosition();
            var fruit = Instantiate(fruits[randomIdx], position, Quaternion.identity);
            return new Fruit(fruit);
        }

        private Vector2 CalcPosition()
        {
            var position = new Vector2(player.transform.position.x, transform.position.y);
            return position;
        }
    }
}
