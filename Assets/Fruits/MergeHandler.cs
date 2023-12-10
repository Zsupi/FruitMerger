using System;
using System.Collections;
using Score;
using UnityEngine;
using UnityEngine.Serialization;

namespace Fruits
{
    public class MergeHandler : MonoBehaviour
    {
        private GameObject _current;
        public GameObject next;

        public int point = 1;

        private String name;

        void Start()
        {
            _current = gameObject;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {

            if (other.gameObject != null && other.gameObject.name == _current.name)
            {
                var otherId = other.gameObject.GetInstanceID();
                var currentId = _current.GetInstanceID();

                if (currentId < otherId)
                {
                    ScoreManager.instance.AddPoint(point);
                    Instantiate(next, transform.position, Quaternion.identity);
                    Destroy(other.gameObject);
                    Destroy(_current);
                }
            }
        }
    }
}
