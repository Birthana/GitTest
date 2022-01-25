using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Attacked.");
    }
}
