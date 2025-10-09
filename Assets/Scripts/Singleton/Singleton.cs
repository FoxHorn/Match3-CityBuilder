using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static bool destroy;

    public static T Instance
    {
        get
        {
            if (destroy) return null;

            if (instance == null)
            {
                T[] a = FindObjectsByType<T>(FindObjectsSortMode.None);

                if (a.Length > 0)
                    instance = a[0];

                if (a.Length > 1) {
                    for (int i = 1; i < a.Length; i++)
                        Destroy(a[i]);
                }

                if (instance == null) {
                    instance = new GameObject(typeof(T).ToString() + "_singleton").AddComponent<T>();
                }

                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }
    
    private void OnApplicationQuit()
    {
        destroy = true;
    }
}