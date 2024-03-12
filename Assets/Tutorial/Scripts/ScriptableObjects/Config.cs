using UnityEditor;
using UnityEngine;

namespace Tutorial
{
    [CreateAssetMenu(fileName = "TutorialConfig", menuName = "Tutorial/Config")]
    public class Config : ScriptableObject
    {
        [SerializeField] internal Color highlightColor;
        [SerializeField] internal Color inputReceivedColor;
        [SerializeField] internal string tutorialTitle;
        [SerializeField] internal string tutorialDescription;
        [SerializeField] internal string tutorialEndsTitle;
        [SerializeField] internal string tutorialEndsDescription;
        [SerializeField] internal bool changeSceneAtTheEnd = false;

        [DrawIf("changeSceneAtTheEnd", true)]
        [SerializeField] internal SceneAsset targetSceneAsset;
        [DrawIf("changeSceneAtTheEnd", true)]
        [SerializeField] internal string tutorialDoneButtonText;
    }
}