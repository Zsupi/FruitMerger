using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager instance;

        public Text scoreText;
        public Text highscoreText;
        private int _score = 0;
        private int _highscore = 0;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            _highscore = PlayerPrefs.GetInt("Highscore", 0);
            scoreText.text = "Score:\n<color=#feae34>" + _score + "</color>";
            highscoreText.text = "Highscore:\n<color=#feae34>" + _highscore + "</color>";
        }

        public void AddPoint(int point)
        {
            _score += point;
            scoreText.text = "Score:\n<color=#feae34>" + _score + "</color>";
            if (_highscore < _score)
            {
                _highscore = _score;
                PlayerPrefs.SetInt("Highscore", _highscore);
                highscoreText.text = "Highscore:\n<color=#feae34>" + _highscore + "</color>";
            }
        }
    }
}
