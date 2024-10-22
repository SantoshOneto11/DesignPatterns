using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace MVP
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreTxt;
        [SerializeField] private Button button;

        private IScorePresentor scorePresentor;

        public void SetPresentor(IScorePresentor presentor)
        {
            scorePresentor = presentor;
            button.onClick.AddListener(OnButtonClicked);
        }

        public void UpdateScore(int score)
        {
            scoreTxt.text = score.ToString();
        }

        public void OnButtonClicked()
        {
            scorePresentor.OnAddScoreClicked();
        }
    }
}
