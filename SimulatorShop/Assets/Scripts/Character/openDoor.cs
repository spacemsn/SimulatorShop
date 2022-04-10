using UnityEngine;
using UnityEngine.UI;

public class openDoor : MonoBehaviour
{
    bool isOpenedR;
    bool isOpenedL;

    [SerializeField] Animator _animatorR;
    [SerializeField] Animator _animatorL;

    public void Open()
    {
        _animatorR.SetBool("isOpenedR", isOpenedR);
        isOpenedR = !isOpenedR;

        _animatorL.SetBool("isOpenedL", isOpenedL);
        isOpenedL = !isOpenedL;
    }
}

