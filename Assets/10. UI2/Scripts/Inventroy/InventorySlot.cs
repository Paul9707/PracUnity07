using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{


    public Image iconImage;
    //internal : 같은 어셈블리 내에서만 접근 가능 하지만 다른 어셈블리에서는 접근이 불가능하다. 어셈블리란 같은 프로젝트 내에서 생성된 라이브러리를 의미한다.
    // 유니티에서는 Inspector에서 참조가 안되고, 대신 다른 스크립트의 코드에서는 참조가 가능하다. -> 현업에서는 보안성이 낮고 활용성이 낮아 안쓴다.
    // 프로토타입핑 등 빠른 구현이 필요할 경우 HideInInspector대신 사용하기도 한다.
    internal Item item = null;

    private void Start()
    {
        Item = item;
    }

    public virtual Item Item
    {
        get { return item; }
        set
        {
            item = value;
            if (item == null)
            {
                iconImage.enabled = false;
            }
            else
            {
                iconImage.enabled = true;
                iconImage.sprite = item.iconSprite;
            }
        }
    }

    public virtual bool TrySwap(Item item)
    {
        if (item is Weapon && hasItem)
        {
            if (this.Item is Weapon)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    // Item 필드가 null일 경우 false, null이 아닐 경우 true 반환
    public bool hasItem { get { return item != null; } }

    public void OnDrag(PointerEventData data)
    {
        if (false == hasItem)
        {
            //아이템이 없을 경우 드래그 불가능
            return;
        }
        //RectTransform.positon : 스크린 상에서의 위치
        iconImage.rectTransform.position = data.position;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // not 연산자 ! -> 가독성을 위해서 ! 대신 false == 을 사용한다
        if (false == hasItem)
        {
            //아이템이 없을 경우 드래그 불가능
            return;
        }

        // Transform.SetParent: 하이어라키 상의 부모를 지정해줌
        // 하이어라키상 부모를 지정해줌. 파라미터로 null을 할당할 경우 부모없이 최 상단으로 이동함.
        iconImage.rectTransform.SetParent(InventoryManger.Instance.equipPage);
        //드래그가 시작할때 인벤 매니저에게 1개 스롯(나 자신)을 선택슬롯으로 저장
        InventoryManger.Instance.selectedSlot = this;
    }



    public void OnEndDrag(PointerEventData data)
    {
        if (false == hasItem)
        {
            //아이템이 없을 경우 드래그 불가능
            return;
        }
        //드래그가 끝난곳이 시작한 곳과 같을때: focused slot == this
        //드래그가 끝난곳이 인벤토리 슬롯이 아닐때: focused slot == null
        //유효한 드래그
        if (InventoryManger.Instance.focusedSlot != this && InventoryManger.Instance.focusedSlot != null)
        {
      
            InventorySlot targetSlot = InventoryManger.Instance.focusedSlot;

            if (targetSlot.TrySwap(item))
            {
                Item tempItem = targetSlot.Item;

                targetSlot.Item = item;

                this.Item = tempItem;
            }
        }

        InventoryManger.Instance.selectedSlot = null;

        iconImage.rectTransform.SetParent(transform);
        //anchoredPosition : 앵커로부터 상대적 위치
        iconImage.rectTransform.anchoredPosition = Vector2.zero;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        InventoryManger.Instance.focusedSlot = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryManger.Instance.focusedSlot = null;
    }
}
