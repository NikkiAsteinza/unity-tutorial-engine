using System.Collections.Generic;
using UnityEngine;
namespace Tutorial
{
    [CreateAssetMenu(fileName = "TutorialGuide", menuName = "Tutorial/Guide")]
    public class Guide : ScriptableObject
    {
        [SerializeField] List<Step> steps;

        public List<Step> Steps => steps;
    }
}