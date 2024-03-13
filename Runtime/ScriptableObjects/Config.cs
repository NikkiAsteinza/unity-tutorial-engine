using UnityEditor;
using UnityEngine;

namespace TutorialEngine
{
    [CreateAssetMenu(fileName = "TutorialConfig", menuName = "Tutorial/Config")]
    public class Config : ScriptableObject
    {
        [SerializeField] private Color highlightColor;
        [SerializeField] private Color pressedColor;
        [SerializeField] private string title;
        [SerializeField] private string description;
        [SerializeField] private string endTitle;
        [SerializeField] private string endDescription;
        [SerializeField] private bool finalButtonToChangeScene = false;

        [DrawIf("changeSceneAtTheEnd", true)]
        [SerializeField] private SceneAsset targetSceneAsset;
        [DrawIf("changeSceneAtTheEnd", true)]
        [SerializeField] private string finalButtonText;

        public Color HighlightColor => highlightColor;
        public Color PressedColor => pressedColor;

        public string Title => title;
        public string Description => description;
        public string EndTitle=> endTitle;
        public string EndDescription => endDescription;
        public bool changeScene => finalButtonToChangeScene;

        public string TargetSceneName => targetSceneAsset.name;
        public string FinalButtonText => finalButtonText;
    }
}