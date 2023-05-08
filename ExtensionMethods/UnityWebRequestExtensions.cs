using UnityEngine.Networking;

public static class UnityWebRequestExtensions
{
    public static bool HasSucceeded(this UnityWebRequest self)
    {
#if UNITY_2020_1_OR_NEWER
        
        return self.result == UnityWebRequest.Result.Success;
#else
        return !self.isHttpError && !self.isNetworkError;
#endif
    }
}