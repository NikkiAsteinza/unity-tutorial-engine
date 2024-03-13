using System.Collections;
using TutorialEngine.Hints;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;


	public class SimpleImageHint : HintBase
	{
		[SerializeField] protected Image image;
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
                SetImageColor(image.color == initialColor ?
                    highlightColor : initialColor);
                yield return new WaitForSeconds(1.0f);
            }
        }

		override protected void Start()
		{
			base.Start();
			initialColor = image.color;
		}

		private void SetPressedMaterial(bool isPressed)
		{
            SetImageColor(isPressed ? Color.red : initialColor);
		}

		private void SetImageColor(Color color)
		{
            image.color = color;
        }
	}