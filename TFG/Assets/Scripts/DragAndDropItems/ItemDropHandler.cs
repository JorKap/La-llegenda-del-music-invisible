using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    private CanvasGroup canvasGroup;
    //RaycastHit hit;
    private Animator animator;
    private ZAxisDrag zAxisDrag;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {

            Debug.Log("hit collider name(Drop): " + hit.collider.name);
            Debug.Log("Drop Item: " + eventData.pointerDrag.GetComponent<Image>().sprite.name);
            if (eventData.pointerDrag.GetComponent<Image>().sprite.name == hit.collider.name)
            {
                Debug.Log("Sprite name:" + eventData.pointerDrag.GetComponent<Image>().sprite.name);
                hit.collider.transform.GetChild(0).gameObject.SetActive(true);
                eventData.pointerDrag.GetComponent<Image>().enabled = false;
                eventData.pointerDrag.GetComponent<Image>().sprite = null;
                Item itemSlot = eventData.pointerDrag.GetComponentInParent<InventorySlot>().item;
                Debug.Log("ItemSlot name" + itemSlot.name);
                Inventory.instance.Remove(itemSlot);

                animator = hit.collider.transform.GetComponent<Animator>();
                zAxisDrag = hit.collider.transform.GetComponent<ZAxisDrag>();

                if (animator != null)
                {
                    animator.enabled = true;
                    Debug.Log("Animate");
                   // animator.SetBool("Animate", true);
                    StartCoroutine(StopAnimation());
                }
            }
        }

    }

    private IEnumerator StopAnimation()
    {
        Debug.Log("Coroutine");
        yield return new WaitForSeconds(1.1f);
       // animator.SetBool("Animate", false);
        animator.enabled = false;
        if (zAxisDrag != null)
        {
            zAxisDrag.enabled = true;
            zAxisDrag.keyOnPlace = true;
        }

    }

}
