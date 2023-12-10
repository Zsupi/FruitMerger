using System;
using System.Collections;
using UnityEngine;

namespace Fruits
{
    public class Fruit
    {
        private readonly GameObject _gameObject;
        private readonly String _originalName;
        private Status _status;

        public Fruit(GameObject gameObject)
        {
            _gameObject = gameObject;
            _status = Status.IDLE;
            _originalName = new String(_gameObject.name);
            _gameObject.name = "NewFruit";
            _gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        public IEnumerator Fall()
        {
            _gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            _status = Status.FALLING;
            yield return new WaitForSeconds(0.5f);
            _gameObject.name = _originalName;
        }

        public void UpdatePosition(Vector2 newPos)
        {
            if (_status == Status.IDLE)
            {
                _gameObject.transform.position = newPos;
            }
        }

    }
}