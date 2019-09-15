using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Unity Speech Recognizer manager.
/// </summary>

public class SpeechRecognizerManager
{
    //각 넘버별로 액션을 정의 
    private const string JAVA_CLASS_NAME = "com.takohi.unity.plugins.SpeechRecognizerManager";
    public const string RESULT_SEPARATOR = "/::/";
    public const int EVENT_SPEECH_READY = -1; // On Speech ready.
    public const int EVENT_SPEECH_BEGINNING = -2; // On beginning of Speech.
    public const int EVENT_SPEECH_END = -3; // On end of Speech.
    public const int ERROR_NOT_INITIALIZED = -1; // Not initialized.
    public const int ERROR_AUDIO = 3; // Audio recording error.
    public const int ERROR_CLIENT = 5;  // Other client side errors.
    public const int ERROR_INSUFFICIENT_PERMISSIONS = 9; // Insufficient permissions
    public const int ERROR_NETWORK = 2; // Other network related errors.
    public const int ERROR_NETWORK_TIMEOUT = 1; // Network operation timed out.
    public const int ERROR_NO_MATCH = 7;    // No recognition result matched.
    public const int ERROR_RECOGNIZER_BUSY = 8; // RecognitionService busy.
    public const int ERROR_SERVER = 4;  // Server sends error status.
    public const int ERROR_SPEECH_TIMEOUT = 6;  // No speech input

    //UnityEngine namespace 안에있음
    //AndroidJavaObject는 java.lang.Object를 유니티상에서 표현한 것
    private static AndroidJavaObject srManager = null;

    //생성자 정의, 생성자 파라미터 gameObjectName은 뭐야? 여기서는 gameObject가 Main Camera이므로 name은 Main Camera
    public SpeechRecognizerManager(string gameObjectName)
    {
        //현재 구동되고 있는 플랫폼이 안드로이드가 아니라면 종료
        if (Application.platform != RuntimePlatform.Android)
            return;
        //안드로이드 플랫폼이 맞다면, 인스턴스 생성
        srManager = new AndroidJavaObject(JAVA_CLASS_NAME, new object[] {
            gameObjectName
        });
    }

    public static bool IsAvailable()
    {
        if (Application.platform != RuntimePlatform.Android)
            return false;

        //안드로이드 플랫폼이 맞다면, 인스턴스 생성
        //AndroidJavaClass는 java.lang.Class를 유니티상에서 표현한 것
        AndroidJavaClass jc = new AndroidJavaClass(JAVA_CLASS_NAME);
        return jc.CallStatic<bool>("isAvailable");
    }

    public void StartListening(int maxResults = 5, string language = null)
    {
        Debug.Log("StartListening");
        if (Application.platform != RuntimePlatform.Android)//WindowsEditor, Android
        {
            Debug.Log("StartListening_return");
            return;
        }

        //AndroidJavaObject의 객체 srManager, Java method중에서 startListening method call
        //startListening 함수를 호출한 뒤, 사용자가 말한 텍스트는 어디에 저장되며 어떻게 표현되는거지...?
        Debug.Log("srManager.Call StartListening");
        srManager.Call("startListening", language, maxResults);//language는 널값인데...?
        Debug.Log("StartListening_complete");
    }

    public void StopListening()
    {
        if (Application.platform != RuntimePlatform.Android)
            return;

        srManager.Call("stopListening");
    }

    public void CancelListening()
    {
        if (Application.platform != RuntimePlatform.Android)
            return;

        srManager.Call("cancel");
    }

    public void Release()
    {
        if (Application.platform != RuntimePlatform.Android)
            return;

        srManager.Call("release");
    }
}