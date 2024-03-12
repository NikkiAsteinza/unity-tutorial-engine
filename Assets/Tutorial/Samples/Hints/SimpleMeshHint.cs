using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tutorial.Hints
{
    public class SimpleMeshHint : HintBase
    {
        [SerializeField] protected MeshRenderer meshRenderer;
        private Color initialColor;

        override protected void ActionCanceledHandler(InputAction.CallbackContext context)
        {
            SetHintMaterial(true);
        }

        override protected void ActionPerformedHandler(InputAction.CallbackContext context)
        {
            SetHintMaterial(false);
        }

        protected override IEnumerator HighLightCoroutine()
        {
            bool showingInitialColor = meshRenderer.material.color == initialColor;
            meshRenderer.material.color = showingInitialColor ? Color.red : initialColor;
            yield return new WaitForSeconds(1.0f);
        }

        override protected void Start()
        {
            base.Start();
            initialColor = meshRenderer.material.color;
        }

        private void SetHintMaterial(bool showHint)
        {
            meshRenderer.material.color = showHint ? Color.red : initialColor;
        }
    }
}