using DevToDev.Analytics;
using UnityEngine;

public class DTDObject : MonoBehaviour
{
    void Start()
    { 
        #if UNITY_ANDROID
                DTDAnalytics.Initialize("5bd4b689-8b3c-0f5d-8c2b-7c2a7e74c235");
        #elif UNITY_IOS
                DTDAnalytics.Initialize("IosAppID");
        #elif UNITY_WEBGL
                DTDAnalytics.Initialize("WebAppID");
        #elif UNITY_STANDALONE_WIN
                DTDAnalytics.Initialize("winAppID");
        #elif UNITY_STANDALONE_OSX
                DTDAnalytics.Initialize("OsxAppID");
        #elif UNITY_WSA
                DTDAnalytics.Initialize("5bd4b689-8b3c-0f5d-8c2b-7c2a7e74c235");
        #endif

        var config = new DTDAnalyticsConfiguration
        {
            ApplicationVersion = "0.0.1",
            LogLevel = DTDLogLevel.No,
            TrackingAvailability = DTDTrackingStatus.Enable,
            CurrentLevel = 1,
            UserId = "unique_userId"
        };
    }
}