using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

namespace com.Klazapp.Utility
{
    public class ErrorHandler : MonoBehaviour
    {
        #region Variables
        [Header("Canvas")]
        public Canvas canvas;

        [Header("Error Text")] 
        public TextMeshProUGUI errorTitleText;
        public TextMeshProUGUI errorDescriptionText;

        private string errorTitle;
        private string errorDescription;
        #endregion

        #region Lifecycle Flow
        private void OnEnable()
        {
            ErrorEventManager.OnTriggerError += OnTriggerErrorCallback;
        }

        private void OnDisable()
        {
            ErrorEventManager.OnTriggerError -= OnTriggerErrorCallback;
        }
        #endregion

        #region Buttons
        public void CloseButtonPressed()
        {
            DisableCanvas();
        }
        #endregion
        
        #region Modules
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void EnableCanvas()
        {
            canvas.enabled = true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void DisableCanvas()
        {
            canvas.enabled = false;
        }
        #endregion

        #region Callbacks
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void OnTriggerErrorCallback(string errorTitleMessage, string errorDescMessage)
        {
            errorTitle = errorTitleMessage;
            errorDescription = errorDescMessage;
            HandleError();
        }
        #endregion
        
        #region Error Handling
        private void HandleError()
        {
            errorTitleText.SetText(errorTitle);
            errorDescriptionText.SetText(errorDescription);
            EnableCanvas();
        }
        #endregion
    }
}