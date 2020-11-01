//CodeMonkey

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler, IPointerUpHandler
{
    public bool gameObjectInstantiated;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private PlayerRotation touchPOV;
   
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        touchPOV = FindObjectOfType<PlayerRotation>();

    }
    private void Start()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.5f;
        eventData.pointerDrag.GetComponent<Image>().rectTransform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        GameManager.instance.playerRotation.enabled = false;

        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {

        transform.position = eventData.position;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {

            if (eventData.pointerDrag != null)
            {
                Debug.Log("OnDrag sprite name: " + eventData.pointerDrag.GetComponent<Image>().sprite.name + " OnDrag hit: " + hit.collider.name);
                if (eventData.pointerDrag.GetComponent<Image>().sprite.name == hit.collider.name)
                {
                    canvasGroup = eventData.pointerDrag.GetComponent<CanvasGroup>();
                    canvasGroup.alpha = 1f;
                }
                else
                {
                    canvasGroup = eventData.pointerDrag.GetComponent<CanvasGroup>();
                    canvasGroup.alpha = 0.5f;
                }


            }
        }


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        GameManager.instance.playerRotation.enabled = true;
        eventData.pointerDrag.GetComponent<Image>().rectTransform.localScale = new Vector3(1, 1, 1);
        rectTransform.localPosition = Vector2.zero;
        canvasGroup.blocksRaycasts = true;


    }



    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.instance.currentItemDrag = this;
        if (!eventData.dragging && !gameObjectInstantiated)
        {
            GetComponentInParent<ItemSlotObserver>().Interact();
            gameObjectInstantiated = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        touchPOV.enabled = true;
    }
}
