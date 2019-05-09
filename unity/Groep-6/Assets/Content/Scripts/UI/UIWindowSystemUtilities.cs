using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public static class UIWindowSystemUtilities
{
    public static void switchStates(int _targetState, List<GameObject[]> _UIObjectArrayLists)
    {
        for (int i = 0; i < _UIObjectArrayLists.Count; i++)
        {
            if (i != _targetState)
            {
                var objectsToBeDisabled = _UIObjectArrayLists[i].Except(_UIObjectArrayLists[_targetState]).ToList();
                foreach (var objectToBeDisabled in objectsToBeDisabled)
                {
                    objectToBeDisabled.SetActive(false);
                }
            }
            else
            {
                var objectsToBeEnabled = _UIObjectArrayLists[i];
                foreach (var objectToBeEnabled in objectsToBeEnabled)
                {
                    objectToBeEnabled.SetActive(true);
                }
            }
        }
    }
}
