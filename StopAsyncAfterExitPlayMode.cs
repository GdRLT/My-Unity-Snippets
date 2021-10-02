using System;
using System.Reflection;
using System.Threading;
using UnityEngine;

public class StopAsyncAfterExitPlayMode : MonoBehaviour
{
    void OnApplicationQuit()
    {
    #if UNITY_EDITOR
        var constructor = SynchronizationContext.Current.GetType().GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(int) }, null);
        var newContext = constructor.Invoke(new object[] { Thread.CurrentThread.ManagedThreadId });
        SynchronizationContext.SetSynchronizationContext(newContext as SynchronizationContext);
    #endif
    }
}
