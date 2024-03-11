using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "TutorialStep", menuName = "Tutorial/Step")]
public class TutorialStep : ScriptableObject
{
    [SerializeField] private InputActionReference inputActionReference = null;
    [SerializeField] private string stepName = "Tutorial step name";
    [SerializeField] private string stepDescription = "Tutorial step description";

    public InputActionReference ActionReference => inputActionReference;
    public string Name => stepName;
    public string Description => stepDescription;
}