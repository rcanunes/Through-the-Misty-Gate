using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMaster : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<PuzzleKey> keys;

    private void Update()
    {
        if (CheckKeys())
        {
            SetKeysDone();
            Activate();
        }
    }

    private void SetKeysDone()
    {
        foreach (PuzzleKey key in keys)
        {
            key.done = true;
            key.enabled = false;
        }
    }

    private bool CheckKeys()
    {
        foreach (PuzzleKey key in keys)
        {
            if (!key.active)
            {
                return false;
            }
        }
        return true;
    }

    public virtual void Activate()
    {
    }
}
