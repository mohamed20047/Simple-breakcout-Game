using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUiHandler : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TMP_InputField nameField;

    private void Start()
    {
        highScoreText.text = highScoreText.text + HighScoreManager.Instance.highScore;  
    }
    public void NewStart()
    {
        HighScoreManager.Instance.currentPlayerName = nameField.text;
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }
}
