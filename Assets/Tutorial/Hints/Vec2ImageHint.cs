using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tutorial.Hints
{
    public enum Axis
    {
        Left,
        Right,
        Up,
        Down
    }

    public class Vec2ImageHint : ButtonHint
    {
        [SerializeField] private Axis value;
        
        protected override void ShowHint(InputAction.CallbackContext context)
        {
            Vector2 inputValue = context.ReadValue<Vector2>();
            bool show = false;
            switch (value)
            {
                case Axis.Left:
                    if (inputValue.x < 0)
                    {
                        show = true;
                    }
                    
                    break;
                case Axis.Right:
                    if (inputValue.x > 0)
                    {
                        show = true;
                    }
                    break;
                case Axis.Up:
                    if (inputValue.x > 0)
                    {
                        show = true;
                    }
                    break;
                case Axis.Down:
                    if (inputValue.x < 0)
                    {
                        show = true;
                    }
                    break;
                default:
                    show = false;
                    break;
            }
        }

        protected override void HideHint(InputAction.CallbackContext context)
        {
            switch (value)
            {
                case Axis.Left:
                    break;
                case Axis.Right:
                    break;
                case Axis.Up:
                    break;
                case Axis.Down:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}