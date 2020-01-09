using System;

namespace DonEnglandArt.Asteroids
{
    public sealed class ScoreManager
    {
        private static readonly Lazy<ScoreManager>
            _lazy = new Lazy<ScoreManager>(()=> new ScoreManager());

        public static ScoreManager Instance => _lazy.Value;
        
        public int Score { get; private set; }

        private ScoreManager()
        {
            UpdateManager.Instance.Update += Tick;
            AsteroidManager.Instance.Scored += OnScore;
        }

        private void OnScore(int score)
        {
            Score += score;
        }

        private void Tick()
        {
        }
    }
}