using UnityEngine;
using UnityEngine.UI;

namespace App.SaveSystem
{
    /// <summary>
    /// スコアの可算や表示、最大値の更新を担うクラス
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        public Text maxScoreText;
        public Text scoreText;

        private int maxScore;
        private int score;

        private void Start()
        {
            SavedDataStore.onLoadEvent.AddListener(() =>
            {
                maxScore = SavedDataStore.SaveData.MaxScore;
                UpdateScoreTexts();
            }); // ロード時に保存していたデータを表示
            UpdateScoreTexts();
        }

        private void UpdateScoreTexts()
        {
            maxScoreText.text = maxScore.ToString();
            scoreText.text = score.ToString();
        }

        public void AddScore() // only button
        {
            score++;
            if (score > maxScore) // scoreがmaxScoreを超えるごとにmaxScoreを更新
            {
                maxScore = score;
                SavedDataStore.SaveData.MaxScore = maxScore;
            }
            UpdateScoreTexts();
        }

        public void ClearScore() // only button
        {
            maxScore = 0;
            score = 0;
            UpdateScoreTexts();
        }
    }
}