using System;
using UnityEngine;

namespace AlexPallottini.Utils
{
    public class Timer
    {
        public event Action OnTimerEnd;
        private float _time;
        private float endTime;
        private readonly bool fromZero = true;
        public float CurrentTime
        {
            get
            {
                return _time;
            }
        }
        
        public Timer(float endTime = 1f, bool fromZero = true)
        {
            this.endTime = Mathf.Abs(endTime);
            this.fromZero = fromZero;
            _time = fromZero ? 0f : endTime;
        }

        public void Tick(float deltaTime)
        {
            if(fromZero)
            {
                _time += deltaTime;
                if(_time >= endTime)
                {
                    _time = endTime;
                    OnTimerEnd.Invoke();
                }
            }
            else
            {
                _time -= deltaTime;
                if(_time <= 0f)
                {
                    _time = 0f;
                    OnTimerEnd.Invoke();
                }
            }
        }

        public void RestartTimer()
        {
            _time = fromZero ? 0f : endTime;
        }

        public void ModifyTimer(float newEndTime)
        {
            newEndTime = Mathf.Abs(newEndTime);
            if(newEndTime != endTime)
            {
                endTime = newEndTime;
                RestartTimer();
            }
        }
    }
}
