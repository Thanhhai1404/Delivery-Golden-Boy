using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public string[] answers;
        public int correctIndex;
    }

    [Header("UI")]
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI questionCounterText;
    public Button[] answerButtons;

    [Header("Data")]
    public Question[] questions;

    [Header("Kết quả")]
    public GameObject resultPanel;
    public TextMeshProUGUI resultText;
    public AudioSource winSound;
    public AudioSource loseSound;

    private int currentQuestion = 0;
    private int correctCount = 0;

    void Start()
    {
        ShowQuestion();
    }

    void ShowQuestion()
    {
        
        questionText.text = questions[currentQuestion].questionText;
        questionCounterText.text = $"Câu {currentQuestion + 1} / {questions.Length}";

        
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i; 
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = questions[currentQuestion].answers[i];
            answerButtons[i].onClick.RemoveAllListeners(); 
            answerButtons[i].onClick.AddListener(() => OnAnswerClick(index));
        }
    }

    void OnAnswerClick(int index)
    {
        if (index == questions[currentQuestion].correctIndex)
        {
            correctCount++;
        }

        currentQuestion++;

        if (currentQuestion < questions.Length)
        {
            ShowQuestion();
        }
        else
        {
            ShowResult();
        }
    }

    void ShowResult()
    {
        resultPanel.SetActive(true);

        if (correctCount >= 8)
        {
            resultText.text = $"🎉 Chúc mừng! Bạn đã trả lời đúng {correctCount}/10 câu!";

            if (winSound != null)
            {
                winSound.Stop();  
                winSound.Play();
            }
        }
        else
        {
            resultText.text = $"😢 Rất tiếc, bạn chỉ đúng {correctCount}/10. Hãy học lại luật!";

            if (loseSound != null)
            {
                loseSound.Stop();
                loseSound.Play();
            }
        }

        Time.timeScale = 1f; 
    }


    public void CloseResultPanel()
    {
        resultPanel.SetActive(false);
        this.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

  

}
