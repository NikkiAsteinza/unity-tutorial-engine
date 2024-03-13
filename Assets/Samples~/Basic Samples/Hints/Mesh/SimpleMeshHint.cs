using System.Collections;
using TutorialEngine.Hints;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class SimpleMeshHint : HintBase
{
    [SerializeField] protected MeshRenderer meshRenderer;
    private Color initialColor;

    override protected void ActionCanceledHandler(CallbackContext context)
    {
        SetPressedMaterial(false);
    }

    override protected void ActionPerformedHandler(CallbackContext context)
    {
        StopCoroutine(highlightCoroutine);
        SetPressedMaterial(true);
    }

    protected override IEnumerator HighLightCoroutine()
    {
        while (true)
        {
            bool showingInitialColor = 
                meshRenderer.material.color == initialColor;
            SetMaterialColor(showingInitialColor ? highlightColor : initialColor);
            yield return new WaitForSeconds(1.0f);
        }
    }

    override protected void Start()
    {
        base.Start();
        initialColor = meshRenderer.material.color;
    }

    private void SetPressedMaterial(bool isPressed)
    {
        SetMaterialColor(isPressed ? Color.red : initialColor);
    }

    private void SetMaterialColor(Color color)
    {
        meshRenderer.material.color = color;
    }
}