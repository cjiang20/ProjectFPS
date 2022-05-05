using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image ProgressImage;

    private UnityEvent<float> OnProgress;
    [SerializeField] private UnityEvent OnCompleted;

    private Coroutine AnimationCoroutine;

    [SerializeField] private Transform Target;
    [SerializeField] private Vector3 Offset;

    private void Update()
    {
        if(Target != null)
        {
            transform.position = Target.position + Offset;
        }
    }
    public void SetTarget(Transform target) {
        Target = target;
    }

    public void SetProgress(float Progress) {
        if (Progress != ProgressImage.fillAmount && Progress > 0)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            ProgressImage.fillAmount = Progress;
        }
    }
}