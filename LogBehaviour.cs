using UnityEngine;

public class LogBehaviour : MonoBehaviour
{
    [SerializeField] LogMode LogFilter = LogMode.none;

    protected void LogFatal  (string message) { Log(message, LogMode.fatal); }
    protected void LogError  (string message) { Log(message, LogMode.error); }
    protected void LogWarning(string message) { Log(message, LogMode.warning); }
    protected void LogInfo   (string message) { Log(message, LogMode.info); }
    protected void LogDebug  (string message) { Log(message, LogMode.debug); }

    protected void Log (string message, LogMode mode) 
    { 
        Logger.log(mode, LogFilter, message, gameObject.name); 
    }
}
