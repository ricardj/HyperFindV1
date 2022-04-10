using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T get;
    void Awake()
    {
        if (get == null)
        {
            get = (T)this;
        }
        else if (get != this)
            Destroy(gameObject);
    }
}

public abstract class PersistentSingleton<T> : MonoBehaviour where T : PersistentSingleton<T>
{
    public static T get;
    private void Awake()
    {
        if (get == null)
        {
            get = (T)this;
            DontDestroyOnLoad(get.gameObject);
        }else if(get != this)
        {
            Destroy(gameObject);
        }
    }
}