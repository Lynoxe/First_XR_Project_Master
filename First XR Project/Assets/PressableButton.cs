using UnityEngine;
using UnityEngine.Events;

public class PressableButton : MonoBehaviour
{
    [SerializeField] private GameObject _buttonGO;
    [SerializeField] private float _heightOffset = 0.5f;
    public UnityEvent OnPress;
    public UnityEvent OnRelease;

    private GameObject _currentPresser;

    private void OnTriggerEnter(Collider other)
    {
        if (_currentPresser != null) return;
        
        _currentPresser = other.gameObject;
        _buttonGO.transform.localPosition -= Vector3.up * _heightOffset;

        OnPress?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == _currentPresser)
        {
            _currentPresser = null;
            _buttonGO.transform.localPosition += Vector3.up * _heightOffset;
            OnRelease?.Invoke();
        }
    }

}
