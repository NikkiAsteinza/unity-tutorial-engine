using TMPro;
using TutorialEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialPanel : MonoBehaviour
{
    [SerializeField] TMP_Text title;
    [SerializeField] TMP_Text description;
    [SerializeField] Button button;

    public void UpdateStepInfo(string Title, string Description)
    {
        title.text = Title;
        description.text = Description;
    }

    private void Start()
    {
        button.onClick.AddListener(StartTutorial);
        UpdateStepInfo(
            Engine.Instance.Config.Title,
            Engine.Instance.Config.Description);

        Engine.Instance.onNextStep.AddListener(TutorialStepDoneHandler);
        Engine.Instance.onFinished.AddListener(TutorialEndHandler);
    }

    private void StartTutorial()
    {
        Debug.Log("Tutorial button click");
        Engine.Instance.StartTutorial();
        button.onClick.RemoveListener(StartTutorial);
        button.gameObject.SetActive(false);
    }

    private void TutorialStepDoneHandler(
        string nextStepName, string nextStepDescription)
    {
        UpdateStepInfo(nextStepName, nextStepDescription);
    }

    private void TutorialEndHandler()
    {
        UpdateStepInfo(
            Engine.Instance.Config.EndTitle,
            Engine.Instance.Config.EndDescription);

        if (Engine.Instance.Config.finalButtonToChangeScene)
        {
            button.onClick.AddListener(ChangeScene);
            TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
            buttonText.text = Engine.Instance.Config.FinalButtonText;
            button.gameObject.SetActive(true);
        }
    }

    private void ChangeScene()
    {
        if (Engine.Instance.Config.finalButtonToChangeScene)
        {
            SceneManager.LoadSceneAsync(
                Engine.Instance.Config.TargetSceneName);
        }
    }
}