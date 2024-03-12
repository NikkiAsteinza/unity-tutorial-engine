using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Tutorial.Hints
{
	public class SimpleImageHint : HintBase
	{
		[SerializeField] protected Image image;
		private Color initialColor;

		override protected void ActionCanceledHandler(InputAction.CallbackContext context)
		{
			SetHintMaterial(true);
		}

		override protected void ActionPerformedHandler(InputAction.CallbackContext context)
		{
			StopCoroutine(highlightCoroutine);
			SetHintMaterial(false);
		}

		protected override IEnumerator HighLightCoroutine()
		{
            while (true)
            {
                image.color = image.color == initialColor ? highlightColor : initialColor;
                yield return new WaitForSeconds(1.0f);
            }
        }

		override protected void Start()
		{
			base.Start();
			initialColor = image.color;
		}

		private void SetHintMaterial(bool showHint)
		{
            image.color = showHint ? Color.red : initialColor;
		}
	}
}