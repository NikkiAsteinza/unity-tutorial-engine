using System;
using System.Collections.Generic;
using System.Linq;
using TutorialEngine.Hints;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace TutorialEngine
{
    [Serializable]
    public class OnNextStep : UnityEvent<string, string>{}
    public class Engine : MonoBehaviour
    {
        [HideInInspector] public OnNextStep onNextStep;
        [HideInInspector] public UnityEvent onFinished;
    
        [SerializeField] private Config config;
        [SerializeField] private Guide guide;
        [SerializeField] private List<HintBase> controllerHints;

        public Config Config => config;
    
        [ReadOnly] public int TotalSteps = 0;
        [ReadOnly] public int DoneSteps = 0;

        public static Engine Instance { get; private set; }

        private int currentStepIndex = 0;
        private Step currentStep = null;

        public void StartTutorial()
        {
            UpdateCurrentStep(currentStepIndex);
        }

        public void AddController(HintBase hint)
        {
            controllerHints.Add(hint);
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
            controllerHints = new List<HintBase>();
        }

        private void SetNextStep()
        {
            UpdateCurrentStep(currentStepIndex+1);
        }

        private void UpdateCurrentStep(int stepIndex)
        {
            Step step = guide.Steps.ToArray()[stepIndex];
            step.ActionReference.action.performed += StepInputPerformed;

            currentStep = step;
            currentStepIndex = stepIndex;
            onNextStep.Invoke(currentStep.Name, currentStep.Description);

            HighlightHints();
        }

        private void HighlightHints()
        {
            controllerHints.ForEach(hint =>
            {
                if(hint.ActionReference == currentStep.ActionReference)
                    hint.StartHighlighting(config.HighlightColor);
            });
        }

        private void StepInputPerformed(InputAction.CallbackContext context)
        {
            currentStep.isDone = true;
            DoneSteps++;
            currentStep.ActionReference.action.performed -= StepInputPerformed;

            if (currentStepIndex + 1 >= guide.Steps.Count)
            {
                onFinished.Invoke();
            }
            else
            {
                SetNextStep();
            }
        }

        internal void RemoveController(HintBase hint)
        {
            controllerHints.ToList().Remove(hint);
        }
    }
}