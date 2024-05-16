using System;

namespace com.Klazapp.Utility
{
    public static class ErrorEventManager
    {
        public static event Action<string, string> OnTriggerError;
        public static void InvokeOnError(string errorTitleMessage, string errorDescMessage)
        {
            OnTriggerError?.Invoke(errorTitleMessage, errorDescMessage);
        }
    }
}
