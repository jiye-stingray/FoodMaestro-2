using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T _instance;
    private static readonly object _lock = new object();        // 멀티 스레드 환경에서 싱글톤 인스턴스가 중복 생성되지 않도록 보호하는 역할을 함
    private static bool _isApplicationQuitting = false;

    public static T Instance
    {
        get
        {
            if (_isApplicationQuitting)
            {
                Debug.LogWarning(typeof(T).ToString() + " [Singleton] Instance will not be returned because the application is quitting.");
                _isApplicationQuitting = false;
            }

            lock (_lock)
            {
                // 한 번에 한 스레드만 실행 가능

                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject();
                        _instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (Singleton)";
                    }
                    DontDestroyOnLoad(_instance.gameObject);
                }
                return _instance;
            }
        }
    }


    // 애플리케이션이 종료될 때 싱글톤 인스턴스가 파괴되었음을 기록
    private void OnApplicationQuit()
    {
        _isApplicationQuitting = true;
    }

    // OnDestroy에서 인스턴스 관리
    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}