using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tutorial.Hints
{
    public class ButtonHint
    {
        [SerializeField] protected InputActionReference ActionReference;
        private void Start()
        {
            ActionReference.action.performed += ShowHint;
            ActionReference.action.canceled +=  HideHint;
            TutorialManager.Instance.AddController(this);
        }

        private void OnDisable()
        {
            ActionReference.action.performed -= ShowHint;
            ActionReference.action.canceled -=  HideHint;
            TutorialManager.Instance.RemoveController(this);
        }
        
        protected virtual void HideHint(InputAction.CallbackContext context)
        {
            throw new NotImplementedException("Hide hint method needs to be overwritten in a child class");
        }

        protected virtual void ShowHint(InputAction.CallbackContext context)
        {
            throw new NotImplementedException("Hide hint method needs to be overwritten in a child class");

        }
    }
}