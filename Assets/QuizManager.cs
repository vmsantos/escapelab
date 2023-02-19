using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class AnswerOption
{
    public string answerText;
    public bool isCorrect;

    public AnswerOption(string answerText, bool isCorrect)
    {
        this.answerText = answerText;
        this.isCorrect = isCorrect;
    }
}

public class QuizManager : MonoBehaviour
{
    public List<Question> questions = new List<Question>();
    public Text questionText;
    public Button option1Button;
    public Button option2Button;
    public Button option3Button;
    public Button option4Button;
    public Text errorMessageText;


    private int currentQuestionIndex = 0;

    void Start()
    {
        string filePath = Application.dataPath + "/questions.csv";

        if (!File.Exists(filePath))
        {
            Debug.LogError("Arquivo não encontrado: " + filePath);
            return;
        }

        string[] lines = File.ReadAllLines(filePath);

        for (int i = 0; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(',');

            string questionText = values[0];

            List<AnswerOption> answerOptions = new List<AnswerOption>
            {
                new AnswerOption(values[1], false),
                new AnswerOption(values[2], false),
                new AnswerOption(values[3], false),
                new AnswerOption(values[4], false)
            };

            int answerIndex;
            if (int.TryParse(values[5], out answerIndex))
            {
                answerIndex--;
            }
            else
            {
                Debug.LogError("O valor do índice da resposta não está no formato correto: " + values[5]);
            }

            option1Button.onClick.AddListener(() => OnAnswerOptionClicked(0));
            option2Button.onClick.AddListener(() => OnAnswerOptionClicked(1));
            option3Button.onClick.AddListener(() => OnAnswerOptionClicked(2));
            option4Button.onClick.AddListener(() => OnAnswerOptionClicked(3));

            answerOptions[answerIndex].isCorrect = true;

            questions.Add(new Question(questionText, answerOptions));
        }

        ShowQuestion(questions[currentQuestionIndex]);
    }

    public void ShowQuestion(Question question)
    {
        questionText.text = question.questionText;

        option1Button.GetComponentInChildren<Text>().text = question.answerOptions[0].answerText;
        option2Button.GetComponentInChildren<Text>().text = question.answerOptions[1].answerText;
        option3Button.GetComponentInChildren<Text>().text = question.answerOptions[2].answerText;
        option4Button.GetComponentInChildren<Text>().text = question.answerOptions[3].answerText;
    }

    public bool CheckAnswer(AnswerOption selectedAnswer, Question question)
    {
        foreach (AnswerOption answerOption in question.answerOptions)
        {
            if (answerOption.isCorrect && answerOption == selectedAnswer)
            {
                return true;
            }
        }

        return false;
    }

    public void NextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Count)
        {
            ShowQuestion(questions[currentQuestionIndex]);
        }
        else
        {
            SceneManager.LoadScene("Lab");
        }
    }

    public class Question
    {
        public string questionText;
        public List<AnswerOption> answerOptions = new List<AnswerOption>();

        public Question(string questionText, List<AnswerOption> answerOptions)
        {
            this.questionText = questionText;
            this.answerOptions = answerOptions;
        }
    }

    public Text messageText; // reference to the text component for displaying messages

    public void OnAnswerOptionClicked(int index)
    {
        AnswerOption selectedAnswer = questions[currentQuestionIndex].answerOptions[index];
        bool isCorrect = CheckAnswer(selectedAnswer, questions[currentQuestionIndex]);
        if (isCorrect)
        {
            // Resposta correta
            NextQuestion();
        }
        else
        {
            // Resposta incorreta
            StartCoroutine(ShowErrorMessage());
        }
    }

    IEnumerator ShowErrorMessage()
    {
        // Mostra a mensagem de erro
        errorMessageText.gameObject.SetActive(true);

        // Espera 2 segundos
        yield return new WaitForSeconds(2);

        // Esconde a mensagem de erro
        errorMessageText.gameObject.SetActive(false);
    }

}