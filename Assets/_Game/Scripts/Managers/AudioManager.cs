using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioManager : Singleton<AudioManager>
{
    public UnityEvent collectEvent;
    public UnityEvent collectBadEvent;
    public UnityEvent CollectSuperBadEvent;
}
