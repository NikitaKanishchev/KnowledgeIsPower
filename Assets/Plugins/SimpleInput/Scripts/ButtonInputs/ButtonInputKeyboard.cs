﻿using UnityEngine;

namespace Plugins.SimpleInput.Scripts.ButtonInputs
{
	public class ButtonInputKeyboard : MonoBehaviour
	{
#pragma warning disable 0649
		[SerializeField]
		private KeyCode key;
#pragma warning restore 0649

		public global::SimpleInput.ButtonInput button = new global::SimpleInput.ButtonInput();

		private void OnEnable()
		{
			button.StartTracking();
			global::SimpleInput.OnUpdate += OnUpdate;
		}

		private void OnDisable()
		{
			button.StopTracking();
			global::SimpleInput.OnUpdate -= OnUpdate;
		}

		private void OnUpdate()
		{
			button.value = Input.GetKey( key );
		}
	}
}