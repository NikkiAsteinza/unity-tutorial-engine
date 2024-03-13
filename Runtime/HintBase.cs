using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TutorialEngine.Hints
{
    public class HintBase :  MonoBehaviour
    {
        [SerializeField] protected InputActionReference actionReference;

        public InputActionReference ActionReference => actionReference;
        
        protected IEnumerator highlightCoroutine = null;
        protected Color highlightColor;

        internal void StartHighlighting(Color color)
        {
            highlightColor = color;
            StartCoroutine(highlightCoroutine);
        }

        protected virtual void Start()
        {
            highlightCoroutine = HighLightCoroutine();
            actionReference.action.performed += ActionPerformedHandler;
            actionReference.action.canceled +=  ActionCanceledHandler;
            Engine.Instance.AddController(this);
        }

        protected virtual void OnDisable()
        {
            actionReference.action.performed -= ActionPerformedHandler;
            actionReference.action.canceled -=  ActionCanceledHandler;
            Engine.Instance.RemoveController(this);
        }

        protected virtual void ActionPerformedHandler(InputAction.CallbackContext context)
        {
            throw new NotImplementedException("Hide hint method needs to be overwritten in a child class");
        }

        protected virtual IEnumerator HighLightCoroutine()
        {
            throw new NotImplementedException("HighlightCoroutine needs to be overwritten in a child class");
        }
        protected virtual void ActionCanceledHandler(InputAction.CallbackContext context)
        {
            throw new NotImplementedException("Hide hint method needs to be overwritten in a child class");
        }
    }
}