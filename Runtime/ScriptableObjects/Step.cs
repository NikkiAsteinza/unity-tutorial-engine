using UnityEngine;
using UnityEngine.InputSystem;

namespace TutorialEngine
{
    [CreateAssetMenu(fileName = "TutorialStep", menuName = "Tutorial/Step")]
    public class Step : ScriptableObject
    {
        [SerializeField] private InputActionReference inputActionReference = null;
        [SerializeField] private string stepName = "Tutorial step name";
        [SerializeField] private string stepDescription = "Tutorial step description";
        public bool isDone = false;
        public InputActionReference ActionReference => inputActionReference;
        public string Name => stepName;
        public string Description => stepDescription;
    }
}