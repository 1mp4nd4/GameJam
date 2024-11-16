using System;
using System.Collections.Generic;
using UnityEngine;

public class GameModule : MonoBehaviour
{
    public event Action<bool> SequenceEvent;

    public void OnSequenceEvent(bool isSuccess)
    {
        SequenceEvent?.Invoke(isSuccess);
    }

    public class Clickable : MonoBehaviour
    {
        public int Index { get; set; }
        public delegate void ClickAction();
        public event ClickAction OnClick;

        private void OnMouseDown()
        {
            OnClick?.Invoke();
        }
    }
}