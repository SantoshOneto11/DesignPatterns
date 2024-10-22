using UnityEngine;

namespace MVP
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private ScoreView scoreView;

        private ScorePresentor _scorePresentor;
        private ScoreModel _scoreModel;

        private void Start()
        {
            _scoreModel = new ScoreModel();
            _scorePresentor = new ScorePresentor(_scoreModel, scoreView);
        }
    }
}
