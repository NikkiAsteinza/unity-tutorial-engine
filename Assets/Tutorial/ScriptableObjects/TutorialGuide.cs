using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "TutorialGuide_", menuName = "Tutorial/Guide")]
public class TutorialGuide : ScriptableObject
{
    [SerializeField] TutorialStep[] steps;

    public TutorialStep[] Steps => steps;
}
