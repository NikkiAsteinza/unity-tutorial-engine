using System;
using System.Collections.Generic;
using System.Linq;
using Tutorial.Hints;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Tutorial
{
    [System.Serializable]
    public class OnTutorialStepDone : UnityEvent<string, string>{}
    public class TutorialManager : MonoBehaviour
    {
        public UnityEvent onTutorialStarted;
        public OnTutorialStepDone onTutorialStepDone;
        public UnityEvent onTutorialFinished;

        public int TotalSteps = 0;
        public int DoneSteps = 0;
        
        [SerializeField] private TutorialGuide guide;
        [SerializeField] private TutorialCanvas canvas;
        [SerializeField] private List<ButtonHint> controllerHints;
    
        public static TutorialManager Instance { get; private set; }
   
        private struct Step {
            public TutorialStep tutorialStep;
            public bool done;
        }

        private Step[] steps;
        private int currentStepIndex = 0;

        public void AddController(ButtonHint hint)
        {
            int index = controllerHints.Count + 1;
            controllerHints[index] = hint ;
        }

        public void StartTutorial()
        {
            onTutorialStarted.Invoke();
        }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            controllerHints = new List<ButtonHint>();
            AddStepsFromGuide();
            StepInputSubscription(currentStepIndex);
        }

        private void StepInputSubscription(int stepIndex)
        {
            steps[stepIndex].tutorialStep.ActionReference.action.performed += StepInputPerformed;
        }

        private void StepInputPerformed(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        private void AddStepsFromGuide()
        {
            for ( int i = 0;  i < guide.Steps.Length; ++i)
            {
                Step step = new Step() { tutorialStep = guide.Steps[i], done = false};
                steps[i] = step;
            }
            TotalSteps = steps.Length;
        }

        internal void RemoveController(ButtonHint hint)
        {
            controllerHints.ToList().Remove(hint);
        }
        private void FinishTutorial()
        {
            onTutorialFinished.Invoke();
        }
    }
}