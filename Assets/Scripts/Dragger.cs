using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Dragger : MonoBehaviour
{
    public LayerMask cardStackLayer;
    public LayerMask cardLayer;
    private CardStack previousStack;
    private Transform currentCard;

    private void Update()
    {
        CheckIfDragging();
        Drag();
        CheckIfDropping();
    }

    private RaycastHit2D GetRaycast(LayerMask layer)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100, layer);
        return hit;
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z += 1;
        return mousePosition;
    }

    private void CheckIfDragging()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = GetRaycast(cardLayer);
            if (hit)
            {
                previousStack = hit.transform.parent.GetComponent<CardStack>();
                currentCard = hit.transform;
                currentCard.GetComponent<SortingGroup>().sortingOrder = 100;
            }
        }
    }

    private void Drag()
    {
        if (currentCard == null)
            return;
        currentCard.transform.position = GetMousePosition();
    }

    private void CheckIfDropping()
    {
        if (Input.GetMouseButtonDown(0) && currentCard != null)
        {
            if (CheckIfUnderNewCardStack())
                MoveToNewCardStack();
            else
                ReturnToNewCardStack();
        }
    }

    private void MoveToNewCardStack()
    {
        RaycastHit2D hit = GetRaycast(cardStackLayer);
        currentCard.position = hit.transform.position;
        CardStack newStack = hit.transform.gameObject.GetComponent<CardStack>();
        currentCard.SetParent(newStack.transform);
        newStack.AddCard(currentCard.gameObject.GetComponent<CardDisplay>());
        newStack.DisplayStack();
        previousStack.RemoveCard(currentCard.gameObject.GetComponent<CardDisplay>());
        previousStack.DisplayStack();
        currentCard = null;
    }

    private void ReturnToNewCardStack()
    {
        currentCard.position = previousStack.transform.position;
        previousStack.DisplayStack();
    }

    private bool CheckIfUnderNewCardStack()
    {
        bool result = false;
        RaycastHit2D hit = GetRaycast(cardStackLayer);
        if (hit)
        {
            CardStack newStack = hit.collider.GetComponent<CardStack>();
            if (newStack != null && !previousStack.Equals(newStack))
                result = true;
        }
        return result;
    }



}
