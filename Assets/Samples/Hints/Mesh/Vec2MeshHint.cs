using System.Collections;
using TutorialEngine.Hints;
using UnityEngine;
using UnityEngine.InputSystem;

public class Vec2MeshHint : HintBase
{
    [SerializeField] private MeshRenderer up;
    [SerializeField] private MeshRenderer down;
    [SerializeField] private MeshRenderer left;
    [SerializeField] private MeshRenderer rigth;

    private Color initialColor = Color.white;

    protected override void ActionPerformedHandler(InputAction.CallbackContext context)
    {
        StopCoroutine(highlightCoroutine);
        Vector2 inputValue = context.ReadValue<Vector2>();
        ManageVerticalAxis(inputValue, true);
        ManageHorizontalAxis(inputValue, true);
    }

    protected override void ActionCanceledHandler(InputAction.CallbackContext context)
    {
        Vector2 inputValue = context.ReadValue<Vector2>();
        ManageVerticalAxis(inputValue, false);
        ManageHorizontalAxis(inputValue, false);
    }

    protected override IEnumerator HighLightCoroutine()
    {
        while (true)
        {
            up.material.color = up.material.color == initialColor ? highlightColor : initialColor;
            down.material.color = down.material.color == initialColor ? highlightColor : initialColor;
            left.material.color = left.material.color == initialColor ? highlightColor : initialColor;
            rigth.material.color = rigth.material.color == initialColor ? highlightColor : initialColor;
            yield return new WaitForSeconds(1.0f);
        }
    }


    private void ManageHorizontalAxis(Vector2 inputValue, bool pressed)
    {
        if (inputValue.x == 0)
        {
            rigth.material.color = Color.white;
            left.material.color = Color.white;
            return;
        }
        if (inputValue.x > 0)
        {
            rigth.material.color = pressed ? Color.red : Color.white;
        }
        else if (inputValue.x < 0)
        {
            left.material.color = pressed ? Color.red : Color.white;
        }
    }

    private void ManageVerticalAxis(Vector2 inputValue, bool pressed)
    {
        if (inputValue.y == 0)
        {
            up.material.color = Color.white;
            down.material.color = Color.white;
            return;
        }
        if (inputValue.y > 0)
        {
            up.material.color = pressed ? Color.red : Color.white;
            down.material.color = Color.white;
        }
        else if (inputValue.y < 0)
        {
            down.material.color = pressed ? Color.red : Color.white;
            up.material.color = Color.white;
        }
    }
}