using Tutorial.Hints;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Vec2ImageHint : HintBase
{
    [SerializeField] private Image up;
    [SerializeField] private Image down;
    [SerializeField] private Image left;
    [SerializeField] private Image rigth;

    protected override void ActionPerformedHandler(InputAction.CallbackContext context)
    {
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

    private void ManageHorizontalAxis(Vector2 inputValue, bool pressed)
    {
        if (inputValue.x == 0)
        {
            rigth.color = Color.white;
            left.color = Color.white;
            return;
        }
        if (inputValue.x > 0)
        {
            rigth.color = pressed ? Color.red : Color.white;
        }
        else if (inputValue.x < 0)
        {
            left.color = pressed ? Color.red : Color.white;
        }
    }

    private void ManageVerticalAxis(Vector2 inputValue, bool pressed)
    {
        if (inputValue.y == 0)
        {
            up.color = Color.white;
            down.color = Color.white;
            return;
        }
        if (inputValue.y > 0)
        {
            up.color = pressed ? Color.red : Color.white;
        }
        else if (inputValue.y < 0)
        {
            down.color = pressed ? Color.red : Color.white;
        }
    }
}