using UnityEngine;
using UnityEngine.InputSystem;

namespace Tutorial.Hints
{
    public class SimpleMeshHint : MonoBehaviour
    {
        [SerializeField] protected MeshRenderer meshRenderer;

        protected virtual void HideHint(InputAction.CallbackContext context)
        {
            meshRenderer.material.color = Color.white;
        }

        protected virtual void ShowHint(InputAction.CallbackContext context)
        {
            meshRenderer.material.color = Color.red;
        }

        private void SetHintMaterial(bool showHint)
        {
            meshRenderer.material.color = showHint? Color.red : Color.white;
        }
    }
}