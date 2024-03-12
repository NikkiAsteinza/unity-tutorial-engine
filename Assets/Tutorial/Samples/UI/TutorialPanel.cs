using TMPro;
using Tutorial;
using UnityEngine;
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
            Engine.Instance.Config.tutorialTitle,
            Engine.Instance.Config.tutorialDescription);

        Engine.Instance.onNextStep.AddListener(TutorialStepDoneHandler);
        Engine.Instance.onFinished.AddListener(TutorialEndHandler);
    }

    private void StartTutorial()
    {
        Debug.Log("Tutorial button click");
        Engine.Instance.StartTutorial();
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
            Engine.Instance.Config.tutorialEndsTitle,
            Engine.Instance.Config.tutorialEndsDescription);
    }
}