using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public interface ICorotineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}