using System;
using UnityEngine;
using System.Collections;

namespace ModernWestern
{
    public class Loop
    {
        private readonly MonoBehaviour Mono;

        private WaitForSeconds Frequency;

        private Coroutine routine;

        /// <summary>
        /// Frequency in seconds.
        /// </summary>
        public Loop(float frequency, MonoBehaviour mono)
        {
            Frequency = new WaitForSeconds(frequency);

            Mono = mono;
        }

        public void Start(Action call, float? overrideFrequency = null)
        {
            if (overrideFrequency.HasValue)
            {
                Frequency = new WaitForSeconds(overrideFrequency.Value);
            }

            routine = Mono.StartCoroutine(Set(call));
        }

        public void Start<T>(T parameter, Action<T> call, float? overrideFrequency)
        {
            if (overrideFrequency.HasValue)
            {
                Frequency = new WaitForSeconds(overrideFrequency.Value);
            }

            routine = Mono.StartCoroutine(Set(parameter, call));
        }

        public void Stop()
        {
            if (routine == null || !Mono)
            {
                return;
            }

            Mono.StopCoroutine(routine);

            routine = null;
        }

        private IEnumerator Set(Action call)
        {
            while (true)
            {
                yield return Frequency;

                call?.Invoke();

                if (routine == null)
                {
                    yield break;
                }
            }
        }

        private IEnumerator Set<T>(T parameter, Action<T> call)
        {
            while (true)
            {
                yield return Frequency;

                call?.Invoke(parameter);

                if (routine == null)
                {
                    yield break;
                }
            }
        }
    }
}