using UnityEngine;

namespace MVP
{
    //Interface
    public interface IScorePresentor
    {
        public void OnAddScoreClicked();
    }

    //Child Class
    public class ScorePresentor : IScorePresentor
    {
        private ScoreModel _scoreModel;
        private ScoreView _scoreView;

        public ScorePresentor(ScoreModel scoreModel, ScoreView scoreView)
        {
            _scoreModel = scoreModel;
            _scoreView = scoreView;

            _scoreView.SetPresentor(this);
            _scoreView.UpdateScore(_scoreModel.Score);
        }

        public void OnAddScoreClicked()
        {
            _scoreModel.AddScore(10);
            _scoreView.UpdateScore(_scoreModel.Score);
        }
    }
}
