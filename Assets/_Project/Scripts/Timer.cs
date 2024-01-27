using System;
using System.Collections;
using UnityEngine;

namespace KrakJam24
{
    public class Timer : MonoBehaviour
    {
        public static event Action<int> OnStart;
        public static event Action<int> OnTick;
        public static event Action OnEnd;
        public static event Action OnTimesUp;

        int _time;

        WaitForSecondsRealtime waitForSecond = new WaitForSecondsRealtime(1);

        Coroutine _timer;

        public void Init(int time)
        {
            _time = time;
            _timer = StartCoroutine(Tick());
        }

        IEnumerator Tick()
        {
            OnStart?.Invoke(_time);

            while(_time > 0)
            {
                yield return waitForSecond;
                _time--;
                
                OnTick?.Invoke(_time);
            }

            OnTimesUp?.Invoke();
            OnEnd?.Invoke();
        }

        public void Stop()
        {
            StopCoroutine(_timer);
            OnEnd?.Invoke();
        }
    }
}
