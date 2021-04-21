using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance

    {
        get
        {
            if (_instance == null)
                Debug.Log("Error instance GameManger is null.");

            return _instance;
        }
    }

    public Question[] questions;
    private List<Question> _unanswered;

    private Question _currentQuestion;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(this.gameObject);


        DontDestroyOnLoad(this.gameObject);

        LoadQuestions();
    }

    public void StartGame()
    {
        LoadQuestions();

        UIManager.Instance.textQuiz.enabled = true;
    }

    void LoadQuestions()
    {
        if (_unanswered == null || _unanswered.Count <= questions.Length)
            _unanswered = questions.ToList<Question>();
    }

    public void GetRandomQuestion()
    {
        if (_unanswered.Count > 1)
        {
            int var = Random.Range(0, _unanswered.Count);
            _currentQuestion = _unanswered[var];
            _unanswered.RemoveAt(var);
            UIManager.Instance.FormulateQuiz(_currentQuestion);
        }
        else if (_unanswered.Count == 1)
        {
            UIManager.Instance.DesableCards();
            _currentQuestion = _unanswered[0];
            _unanswered.RemoveAt(0);
            UIManager.Instance.FormulateQuiz(_currentQuestion);
        }
        else
        {
            UIManager.Instance.Win();
        }
    }

    public void StartQuestion(Button btn)
    {
        int var = Random.Range(0, _unanswered.Count);
        _currentQuestion = _unanswered[var];
        _unanswered.RemoveAt(var);
        UIManager.Instance.textQuiz.enabled = false;
        UIManager.Instance.FormulateQuiz(_currentQuestion);
        btn.interactable = false;
    }
}
