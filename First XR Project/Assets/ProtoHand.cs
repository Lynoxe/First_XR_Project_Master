using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoHand : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSelect(bool enable)
    {
        if (enable)
            _animator.SetTrigger("Selected");
        else
            _animator.SetTrigger("Deselected");
    }

    public void SetPointing(bool enable)
    {
        _animator.SetBool("Pointing", enable);
    }
}
