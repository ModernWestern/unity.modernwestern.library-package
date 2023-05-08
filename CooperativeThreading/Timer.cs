using System;
using UnityEngine;
using System.Collections;

namespace ModernWestern
{
    public class Timer
    {
        private readonly DelayUntil DelayUntil = new();

        private readonly WaitForSeconds Second = new(1);

        private readonly bool Backward;

        private readonly float StopAt;

        private MonoBehaviour mono;

        private Coroutine routine;

        private float count;

        public Timer(float stop)
        {
            StopAt = stop;
        }

        public Timer(float stop, bool backward)
        {
            count = backward ? stop : 0;

            StopAt = backward ? 0 : stop;

            Backward = backward;
        }

        public Coroutine Start(Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            return routine = mono.StartCoroutine(Routine(null, null, completed));
        }

        public Coroutine Start(Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            return routine = mono.StartCoroutine(Routine(null, null, completed));
        }

        public Coroutine Start(Action<float> time, Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            return routine = mono.StartCoroutine(Routine(null, time, completed));
        }

        public Coroutine Start(Action<float> time, Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            return routine = mono.StartCoroutine(Routine(null, time, completed));
        }

        public Coroutine Start(Action<string> time, Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            return routine = mono.StartCoroutine(Routine(null, f => time?.Invoke(f.ToString()), completed));
        }

        public Coroutine Start(Action<string> time, Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            return routine = mono.StartCoroutine(Routine(null, f => time?.Invoke(f.ToString()), completed));
        }

        public Coroutine Start(Action awake, Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            return routine = mono.StartCoroutine(Routine(awake, null, completed));
        }

        public Coroutine Start(Action awake, Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            return routine = mono.StartCoroutine(Routine(awake, null, completed));
        }

        public Coroutine Start(Action awake, Action<float> time, Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            return routine = mono.StartCoroutine(Routine(awake, time, completed));
        }

        public Coroutine Start(Action awake, Action<float> time, Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            return routine = mono.StartCoroutine(Routine(awake, time, completed));
        }

        public Coroutine Start(Action awake, Action<string> time, Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            return routine = mono.StartCoroutine(Routine(awake, f => time?.Invoke(f.ToString()), completed));
        }

        public Coroutine Start(Action awake, Action<string> time, Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            return routine = mono.StartCoroutine(Routine(awake, f => time?.Invoke(f.ToString()), completed));
        }

        public Coroutine Start(Func<bool> stopWhen, Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            return routine = mono.StartCoroutine(Routine(null, stopWhen, null, completed));
        }

        public Coroutine Start(Func<bool> stopWhen, Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            return routine = mono.StartCoroutine(Routine(null, stopWhen, null, completed));
        }

        public Coroutine Start(Func<bool> stopWhen, Action<float> time, Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            return routine = mono.StartCoroutine(Routine(null, stopWhen, time, completed));
        }

        public Coroutine Start(Func<bool> stopWhen, Action<float> time, Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            return routine = mono.StartCoroutine(Routine(null, stopWhen, time, completed));
        }

        public Coroutine Start(Func<bool> stopWhen, Action<string> time, Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            return routine = mono.StartCoroutine(Routine(null, stopWhen, f => time?.Invoke(f.ToString()), completed));
        }

        public Coroutine Start(Func<bool> stopWhen, Action<string> time, Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            return routine = mono.StartCoroutine(Routine(null, stopWhen, f => time?.Invoke(f.ToString()), completed));
        }

        public void Prepare(Func<bool> startWhen, Func<bool> stopWhen, Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            DelayUntil.Start(startWhen, () => { mono.StartCoroutine(Routine(null, stopWhen, null, completed)); }, mono);
        }

        public void Prepare(Func<bool> startWhen, Func<bool> stopWhen, Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            DelayUntil.Start(startWhen, () => { mono.StartCoroutine(Routine(null, stopWhen, null, completed)); }, mono);
        }

        public void Prepare(Func<bool> startWhen, Func<bool> stopWhen, Action<float> time, Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            DelayUntil.Start(startWhen, () => { mono.StartCoroutine(Routine(null, stopWhen, time, completed)); }, mono);
        }

        public void Prepare(Func<bool> startWhen, Func<bool> stopWhen, Action<float> time, Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            DelayUntil.Start(startWhen, () => { mono.StartCoroutine(Routine(null, stopWhen, time, completed)); }, mono);
        }

        public void Prepare(Func<bool> startWhen, Func<bool> stopWhen, Action<string> time, Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            DelayUntil.Start(startWhen, () => { mono.StartCoroutine(Routine(null, stopWhen, f => time?.Invoke(f.ToString()), completed)); }, mono);
        }

        public void Prepare(Func<bool> startWhen, Func<bool> stopWhen, Action<string> time, Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            DelayUntil.Start(startWhen, () => { mono.StartCoroutine(Routine(null, stopWhen, f => time?.Invoke(f.ToString()), completed)); }, mono);
        }

        public Coroutine Start(Action awake, Func<bool> stopWhen, Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            return routine = mono.StartCoroutine(Routine(awake, stopWhen, null, completed));
        }

        public Coroutine Start(Action awake, Func<bool> stopWhen, Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            return routine = mono.StartCoroutine(Routine(awake, stopWhen, null, completed));
        }

        public Coroutine Start(Action awake, Func<bool> stopWhen, Action<float> time, Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            return routine = mono.StartCoroutine(Routine(awake, stopWhen, time, completed));
        }

        public Coroutine Start(Action awake, Func<bool> stopWhen, Action<float> time, Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            return routine = mono.StartCoroutine(Routine(awake, stopWhen, time, completed));
        }

        public Coroutine Start(Action awake, Func<bool> stopWhen, Action<string> time, Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            return routine = mono.StartCoroutine(Routine(awake, stopWhen, f => time?.Invoke(f.ToString()), completed));
        }

        public Coroutine Start(Action awake, Func<bool> stopWhen, Action<string> time, Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            return routine = mono.StartCoroutine(Routine(awake, stopWhen, f => time?.Invoke(f.ToString()), completed));
        }

        public void Prepare(Action awake, Func<bool> startWhen, Func<bool> stopWhen, Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            DelayUntil.Start(startWhen, () => { mono.StartCoroutine(Routine(awake, stopWhen, null, completed)); }, mono);
        }

        public void Prepare(Action awake, Func<bool> startWhen, Func<bool> stopWhen, Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            DelayUntil.Start(startWhen, () => { mono.StartCoroutine(Routine(awake, stopWhen, null, completed)); }, mono);
        }

        public void Prepare(Action awake, Func<bool> startWhen, Func<bool> stopWhen, Action<float> time, Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            DelayUntil.Start(startWhen, () => { mono.StartCoroutine(Routine(awake, stopWhen, time, completed)); }, mono);
        }

        public void Prepare(Action awake, Func<bool> startWhen, Func<bool> stopWhen, Action<float> time, Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            DelayUntil.Start(startWhen, () => { mono.StartCoroutine(Routine(awake, stopWhen, time, completed)); }, mono);
        }

        public void Prepare(Action awake, Func<bool> startWhen, Func<bool> stopWhen, Action<string> time, Action completed, MonoBehaviour mono)
        {
            this.mono = mono;

            DelayUntil.Start(startWhen, () => { mono.StartCoroutine(Routine(awake, stopWhen, f => time?.Invoke(f.ToString()), completed)); }, mono);
        }

        public void Prepare(Action awake, Func<bool> startWhen, Func<bool> stopWhen, Action<string> time, Action completed, GameObject gameObject)
        {
            mono ??= gameObject.GetComponent<MonoBehaviour>();

            DelayUntil.Start(startWhen, () => { mono.StartCoroutine(Routine(awake, stopWhen, f => time?.Invoke(f.ToString()), completed)); }, mono);
        }

        public void Stop()
        {
            if (mono)
            {
                mono.StopCoroutine(routine);
            }
        }

        private IEnumerator Routine(Action awake, Action<float> time, Action completed)
        {
            awake?.Invoke();

            while (Backward ? (count >= StopAt) : (count <= StopAt))
            {
                time?.Invoke(Backward ? count-- : count++);

                yield return Second;
            }

            completed?.Invoke();
        }

        private IEnumerator Routine(Action awake, Func<bool> stopWhen, Action<float> time, Action completed)
        {
            awake?.Invoke();

            while ((Backward ? (count >= StopAt) : (count <= StopAt)) && !stopWhen())
            {
                time?.Invoke(Backward ? count-- : count++);

                yield return Second;
            }

            completed?.Invoke();

            routine = null;
        }
    }
}