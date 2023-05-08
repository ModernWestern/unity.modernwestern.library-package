using System;
using UnityEngine;
using System.Collections;

namespace ModernWestern
{
    public class Poll
    {
        private readonly WaitForSeconds TimeScale;

        public MonoBehaviour Mono { get; }

        public bool IsRunning { get; private set; }

        private Coroutine pollRoutine;

        private bool poll;

        /// <summary>
        /// Constructs a Poll instance.
        /// </summary>
        /// <param name="mono">The MonoBehaviour instance used for polling.</param>
        public Poll(MonoBehaviour mono)
        {
            Mono = mono;
        }

        /// <summary>
        /// Constructs a Poll instance.
        /// </summary>
        /// <param name="gameObject">The GameObject instance used for polling.</param>
        public Poll(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out MonoBehaviour mono))
            {
                Mono = mono;
            }

#if UNITY_EDITOR

            else
            {
                Debug.LogWarning("The GameObject does not contains a MonoBehaviour component.", gameObject);
            }
#endif
        }

        /// <summary>
        /// Constructs a Poll instance with a specified time scale, which represents the amount of time between each frame update.
        /// The time scale is calculated as 1 second divided by the rate.
        /// </summary>
        /// <param name="rate">The time scale of the Poll instance, expressed in seconds per frame.</param>
        /// <param name="mono">The MonoBehaviour instance used for polling.</param>
        public Poll(float rate, MonoBehaviour mono)
        {
            Mono = mono;

            TimeScale = new WaitForSeconds(1 / rate <= 0 ? Mathf.Abs(rate) : rate);
        }

        /// <summary>
        /// Constructs a Poll instance with a specified time scale, which represents the amount of time between each frame update.
        /// The time scale is calculated as 1 second divided by the rate.
        /// </summary>
        /// <param name="rate">The time scale of the Poll instance, expressed in seconds per frame.</param>
        /// <param name="gameObject">The GameObject instance used for polling.</param>
        public Poll(float rate, GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out MonoBehaviour mono))
            {
                Mono = mono;
            }

#if UNITY_EDITOR

            else
            {
                Debug.LogWarning("The GameObject does not contains a MonoBehaviour component.", gameObject);
            }
#endif
            TimeScale = new WaitForSeconds(1 / rate <= 0 ? Mathf.Abs(rate) : rate);
        }

        /// <summary>
        /// The poll gets updating ever and Poll.Stop must to be used to stop the routine. The predicate must to be declared as lambda "() => something == becameSomething"
        /// </summary>
        public void Start(Action update)
        {
            pollRoutine = TimeScale == null ? Mono.StartCoroutine(Set(null, update, null)) : Mono.StartCoroutine(SetTimeScale(null, update, null));
        }

        /// <summary>
        /// If the predicate "updateWhile" is null the poll gets updating ever and Poll.Stop must to be used to stop the routine. The predicate must to be declared as lambda "() => something == becameSomething"
        /// </summary>
        public void Start(Func<bool> updateWhile, Action update)
        {
            pollRoutine = TimeScale == null ? Mono.StartCoroutine(Set(updateWhile, null, update, null)) : Mono.StartCoroutine(SetTimeScale(null, update, null));
        }

        /// <summary>
        /// The poll gets updating ever and Poll.Stop must to be used to stop the routine. The predicate must to be declared as lambda "() => something == becameSomething"
        /// </summary>
        public void Start(Action awake, Action update)
        {
            pollRoutine = TimeScale == null ? Mono.StartCoroutine(Set(awake, update, null)) : Mono.StartCoroutine(SetTimeScale(awake, update, null));
        }

        /// <summary>
        /// If the predicate "updateWhile" is null the poll gets updating ever and Poll.Stop must to be used to stop the routine. The predicate must to be declared as lambda "() => something == becameSomething"
        /// </summary>
        public void Start(Func<bool> updateWhile, Action awake, Action update)
        {
            pollRoutine = TimeScale == null ? Mono.StartCoroutine(Set(updateWhile, awake, update, null)) : Mono.StartCoroutine(SetTimeScale(awake, update, null));
        }

        /// <summary>
        /// The poll gets updating ever and Poll.Stop must to be used to stop the routine. The predicate must to be declared as lambda "() => something == becameSomething"
        /// </summary>
        public void Start(Action awake, Action update, Action asleep)
        {
            pollRoutine = TimeScale == null ? Mono.StartCoroutine(Set(awake, update, asleep)) : Mono.StartCoroutine(SetTimeScale(awake, update, asleep));
        }

        /// <summary>
        /// If the predicate "updateWhile" is null the poll gets updating ever and Poll.Stop must to be used to stop the routine. The predicate must to be declared as lambda "() => something == becameSomething"
        /// </summary>
        public void Start(Func<bool> updateWhile, Action awake, Action update, Action asleep)
        {
            pollRoutine = TimeScale == null ? Mono.StartCoroutine(Set(updateWhile, awake, update, asleep)) : Mono.StartCoroutine(SetTimeScale(awake, update, asleep));
        }

        private IEnumerator Set(Action awake, Action update, Action asleep)
        {
            awake?.Invoke();

            IsRunning = false;

            while (poll)
            {
                yield return null;

                update?.Invoke();

                IsRunning = true;
            }

            asleep?.Invoke();

            IsRunning = false;

            Stop();
        }

        private IEnumerator Set(Func<bool> stop, Action awake, Action update, Action asleep)
        {
            awake?.Invoke();

            IsRunning = false;

            while (poll && stop())
            {
                yield return null;

                update?.Invoke();

                IsRunning = true;
            }

            asleep?.Invoke();

            IsRunning = false;

            Stop();
        }

        private IEnumerator SetTimeScale(Action awake, Action update, Action asleep)
        {
            awake?.Invoke();

            IsRunning = false;

            while (poll)
            {
                yield return TimeScale;

                update?.Invoke();

                IsRunning = true;
            }

            asleep?.Invoke();

            IsRunning = false;

            Stop();
        }

        public void Stop()
        {
            poll = false;

            IsRunning = false;

            if (pollRoutine != null)
            {
                Mono.StopCoroutine(pollRoutine);

                pollRoutine = null;
            }

            GC.Collect();
        }

        public static implicit operator bool(Poll exists)
        {
            return exists != null && exists.Mono;
        }
    }
}