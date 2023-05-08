using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ModernWestern
{
    public class Delay
    {
        private bool value;

        private readonly WaitForSeconds Time;

        public Delay()
        {
            Time = new WaitForSeconds(1);
        }

        public Delay(float time)
        {
            Time = new WaitForSeconds(time);
        }

        public Delay(WaitForSeconds time, Action call, MonoBehaviour mono, out Coroutine routine)
        {
            routine = mono.StartCoroutine(Set(time, call));
        }

        public Delay(float time, Action call, MonoBehaviour mono, out Coroutine routine)
        {
            routine = mono.StartCoroutine(Set(new WaitForSeconds(time), call));
        }

        public Delay(WaitForSeconds time, Action call, GameObject gameObject, out Coroutine routine)
        {
            routine = gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(time, call));
        }

        public Delay(float time, Action call, GameObject gameObject, out Coroutine routine)
        {
            routine = gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(new WaitForSeconds(time), call));
        }

        public Coroutine Start(WaitForSeconds time, Action call, MonoBehaviour mono)
        {
            return mono.StartCoroutine(Set(time, call));
        }

        public Coroutine Start(WaitForSeconds time, Action call, GameObject gameObject)
        {
            return gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(time, call));
        }

        public Coroutine Start(Action call, MonoBehaviour mono)
        {
            return mono.StartCoroutine(Set(Time, call));
        }

        public Coroutine Start(Action call, GameObject gameObject)
        {
            return gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(Time, call));
        }

        public Coroutine Start<T>(T parameter, Action<T> call, MonoBehaviour mono)
        {
            return mono.StartCoroutine(Set(Time, parameter, call));
        }

        public Coroutine Start<T>(T parameter, Action<T> call, GameObject gameObject)
        {
            return gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(Time, parameter, call));
        }

        public Coroutine Start(float time, Action call, MonoBehaviour mono)
        {
            return mono.StartCoroutine(Set(new WaitForSeconds(time), call));
        }

        public Coroutine Start(float time, Action call, GameObject gameObject)
        {
            return gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(new WaitForSeconds(time), call));
        }

        public Coroutine Start<T>(WaitForSeconds time, T parameter, Action<T> call, MonoBehaviour mono)
        {
            return mono.StartCoroutine(Set(time, parameter, call));
        }

        public Coroutine Start<T>(WaitForSeconds time, T parameter, Action<T> call, GameObject gameObject)
        {
            return gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(time, parameter, call));
        }

        public Coroutine Start<T>(float time, T parameter, Action<T> call, MonoBehaviour mono)
        {
            return mono.StartCoroutine(Set(new WaitForSeconds(time), parameter, call));
        }

        public Coroutine Start<T>(float time, T parameter, Action<T> call, GameObject gameObject)
        {
            return gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(new WaitForSeconds(time), parameter, call));
        }

        public bool Start<T>(float time, T parameter, Func<T, bool> call, out Coroutine routine, MonoBehaviour mono)
        {
            routine = mono.StartCoroutine(Set(new WaitForSeconds(time), parameter, call));

            return value;
        }

        public bool Start<T>(float time, T parameter, Func<T, bool> call, out Coroutine routine, GameObject gameObject)
        {
            routine = gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(new WaitForSeconds(time), parameter, call));

            return value;
        }

        public bool Start<T>(WaitForSeconds time, T parameter, Func<T, bool> call, out Coroutine routine, MonoBehaviour mono)
        {
            routine = mono.StartCoroutine(Set(time, parameter, call));

            return value;
        }

        public bool Start<T>(WaitForSeconds time, T parameter, Func<T, bool> call, out Coroutine routine, GameObject gameObject)
        {
            routine = gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(time, parameter, call));

            return value;
        }

        private IEnumerator Set(WaitForSeconds time, Action call)
        {
            yield return time;

            call?.Invoke();
        }

        private IEnumerator Set<T>(WaitForSeconds time, T parameter, Action<T> call)
        {
            yield return time;

            call?.Invoke(parameter);
        }

        private IEnumerator Set<T>(WaitForSeconds time, T parameter, Func<T, bool> call)
        {
            yield return time;

            value = call?.Invoke(parameter) ?? false;
        }
    }

    /// <summary>
    /// Suspends the execution until the supplied time value is completed.
    /// </summary>
    public class Delay<T>
    {
        public Delay()
        {
        }

        public Delay(WaitForSeconds time, T parameter, Action<T> call, MonoBehaviour mono, out Coroutine routine)
        {
            routine = mono.StartCoroutine(Set(time, parameter, call));
        }

        public Delay(float time, T parameter, Action<T> call, MonoBehaviour mono, out Coroutine routine)
        {
            routine = mono.StartCoroutine(Set(new WaitForSeconds(time), parameter, call));
        }

        public Delay(WaitForSeconds time, T parameter, Action<T> call, GameObject gameObject, out Coroutine routine)
        {
            routine = gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(time, parameter, call));
        }

        public Delay(float time, T parameter, Action<T> call, GameObject gameObject, out Coroutine routine)
        {
            routine = gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(new WaitForSeconds(time), parameter, call));
        }

        private IEnumerator Set(WaitForSeconds time, T parameter, Action<T> call)
        {
            yield return time;

            call?.Invoke(parameter);
        }
    }

    /// <summary>
    /// Suspends the execution until the supplied delegate evaluates to true.
    /// </summary>
    public class DelayUntil
    {
        private Coroutine id;

        private MonoBehaviour mono;

        /// <summary>
        /// Suspends the execution until the supplied delegate evaluates to true.
        /// </summary>
        public Coroutine Start(Func<bool> predicate, Action call, MonoBehaviour mono)
        {
            this.mono = mono;

            if (mono.isActiveAndEnabled)
                return id = mono.StartCoroutine(Set(predicate, call));

            return null;
        }

        /// <summary>
        /// Suspends the execution until the supplied delegate evaluates to true.
        /// </summary>
        public Coroutine Start(Func<bool> predicate, Action call, GameObject gameObject)
        {
            mono = gameObject.GetComponent<MonoBehaviour>();

            return id = mono.StartCoroutine(Set(predicate, call));
        }

        /// <summary>
        /// Suspends the execution until the supplied delegate evaluates to true.
        /// </summary>
        public Coroutine Start<T>(Func<bool> predicate, T parameter, Action<T> call, MonoBehaviour mono)
        {
            this.mono = mono;

            return id = mono.StartCoroutine(Set(predicate, () => call?.Invoke(parameter)));
        }

        /// <summary>
        /// Suspends the execution until the supplied delegate evaluates to true.
        /// </summary>
        public Coroutine Start<T>(Func<bool> predicate, T parameter, Action<T> call, GameObject gameObject)
        {
            mono = gameObject.GetComponent<MonoBehaviour>();

            return id = mono.StartCoroutine(Set(predicate, () => call?.Invoke(parameter)));
        }

        public void Cancel()
        {
            if (mono != null && id != null)
            {
                mono.StopCoroutine(id);
            }
        }

        private IEnumerator Set(Func<bool> predicate, Action call)
        {
            yield return new WaitUntil(predicate);

            call?.Invoke();
        }
    }

    /// <summary>
    /// Suspends the execution until the supplied delegate evaluates to false.
    /// </summary>
    public class DelayWhile
    {
        /// <summary>
        /// Suspends the execution until the supplied delegate evaluates to false.
        /// </summary>
        public Coroutine Start(Func<bool> predicate, Action call, MonoBehaviour mono)
        {
            return mono.StartCoroutine(Set(predicate, call));
        }

        /// <summary>
        /// Suspends the execution until the supplied delegate evaluates to false.
        /// </summary>
        public Coroutine Start(Func<bool> predicate, Action call, GameObject gameObject)
        {
            return gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(predicate, call));
        }

        /// <summary>
        /// Suspends the execution until the supplied delegate evaluates to false.
        /// </summary>
        public Coroutine Start<T>(Func<bool> predicate, T parameter, Action<T> call, MonoBehaviour mono)
        {
            return mono.StartCoroutine(Set(predicate, () => call?.Invoke(parameter)));
        }

        /// <summary>
        /// Suspends the execution until the supplied delegate evaluates to false.
        /// </summary>
        public Coroutine Start<T>(Func<bool> predicate, T parameter, Action<T> call, GameObject gameObject)
        {
            return gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(predicate, () => call?.Invoke(parameter)));
        }

        /// <summary>
        /// Suspends the execution until the supplied delegate evaluates to false.
        /// </summary>
        private IEnumerator Set(Func<bool> predicate, Action call)
        {
            yield return new WaitWhile(predicate);

            call?.Invoke();
        }
    }

    /// <summary>
    /// Suspends the execution until the supplied number of frames is completed.
    /// </summary>
    public class DelayFrames
    {
        private bool value;

        public DelayFrames()
        {
        }

        public DelayFrames(Action call, MonoBehaviour mono, out Coroutine routine)
        {
            routine = mono.StartCoroutine(Set(call, null));
        }

        public DelayFrames(int frames, Action call, MonoBehaviour mono, out Coroutine routine)
        {
            routine = mono.StartCoroutine(Set(call, frames));
        }

        public DelayFrames(Action call, GameObject gameObject, out Coroutine routine)
        {
            routine = gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(call, null));
        }

        public DelayFrames(int frames, Action call, GameObject gameObject, out Coroutine routine)
        {
            routine = gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(call, frames));
        }

        public Coroutine Start(Action call, MonoBehaviour mono)
        {
            return mono.StartCoroutine(Set(call, null));
        }

        public Coroutine Start(int frames, Action call, MonoBehaviour mono)
        {
            return mono.StartCoroutine(Set(call, frames));
        }

        public Coroutine Start(Action call, GameObject gameObject)
        {
            return gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(call, null));
        }

        public Coroutine Start(int frames, Action call, GameObject gameObject)
        {
            return gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(call, frames));
        }

        public Coroutine Start<T>(T parameter, Action<T> call, MonoBehaviour mono)
        {
            return mono.StartCoroutine(Set(parameter, call, null));
        }

        public Coroutine Start<T>(int frames, T parameter, Action<T> call, MonoBehaviour mono)
        {
            return mono.StartCoroutine(Set(parameter, call, frames));
        }

        public Coroutine Start<T>(T parameter, Action<T> call, GameObject gameObject)
        {
            return gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(parameter, call, null));
        }

        public Coroutine Start<T>(int frames, T parameter, Action<T> call, GameObject gameObject)
        {
            return gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(parameter, call, frames));
        }

        public bool Start<T>(T parameter, Func<T, bool> call, out Coroutine routine, MonoBehaviour mono)
        {
            routine = mono.StartCoroutine(Set(parameter, call, null));

            return value;
        }

        public bool Start<T>(int frames, T parameter, Func<T, bool> call, out Coroutine routine, MonoBehaviour mono)
        {
            routine = mono.StartCoroutine(Set(parameter, call, frames));

            return value;
        }

        public bool Start<T>(T parameter, Func<T, bool> call, out Coroutine routine, GameObject gameObject)
        {
            routine = gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(parameter, call, null));

            return value;
        }

        public bool Start<T>(int frames, T parameter, Func<T, bool> call, out Coroutine routine, GameObject gameObject)
        {
            routine = gameObject.GetComponent<MonoBehaviour>().StartCoroutine(Set(parameter, call, frames));

            return value;
        }

        private IEnumerator Set(Action call, int? frames)
        {
            yield return frames.HasValue ? new WaitForFrames(frames.Value) : null;

            call?.Invoke();
        }

        private IEnumerator Set<T>(T parameter, Action<T> call, int? frames)
        {
            yield return frames.HasValue ? new WaitForFrames(frames.Value) : null;

            call?.Invoke(parameter);
        }

        private IEnumerator Set<T>(T parameter, Func<T, bool> call, int? frames)
        {
            yield return frames.HasValue ? new WaitForFrames(frames.Value) : null;

            value = call?.Invoke(parameter) ?? false;
        }

        private class WaitForFrames : CustomYieldInstruction
        {
            private readonly int TargetFrameCount;

            public WaitForFrames(int numberOfFrames)
            {
                TargetFrameCount = Time.frameCount + numberOfFrames;
            }

            public override bool keepWaiting => Time.frameCount < TargetFrameCount;
        }
    }
}