using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{


    public Image iconImage;
    //internal : ���� ����� �������� ���� ���� ������ �ٸ� ����������� ������ �Ұ����ϴ�. ������� ���� ������Ʈ ������ ������ ���̺귯���� �ǹ��Ѵ�.
    // ����Ƽ������ Inspector���� ������ �ȵǰ�, ��� �ٸ� ��ũ��Ʈ�� �ڵ忡���� ������ �����ϴ�. -> ���������� ���ȼ��� ���� Ȱ�뼺�� ���� �Ⱦ���.
    // ������Ÿ���� �� ���� ������ �ʿ��� ��� HideInInspector��� ����ϱ⵵ �Ѵ�.
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
    // Item �ʵ尡 null�� ��� false, null�� �ƴ� ��� true ��ȯ
    public bool hasItem { get { return item != null; } }

    public void OnDrag(PointerEventData data)
    {
        if (false == hasItem)
        {
            //�������� ���� ��� �巡�� �Ұ���
            return;
        }
        //RectTransform.positon : ��ũ�� �󿡼��� ��ġ
        iconImage.rectTransform.position = data.position;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // not ������ ! -> �������� ���ؼ� ! ��� false == �� ����Ѵ�
        if (false == hasItem)
        {
            //�������� ���� ��� �巡�� �Ұ���
            return;
        }

        // Transform.SetParent: ���̾��Ű ���� �θ� ��������
        // ���̾��Ű�� �θ� ��������. �Ķ���ͷ� null�� �Ҵ��� ��� �θ���� �� ������� �̵���.
        iconImage.rectTransform.SetParent(InventoryManger.Instance.equipPage);
        //�巡�װ� �����Ҷ� �κ� �Ŵ������� 1�� ����(�� �ڽ�)�� ���ý������� ����
        InventoryManger.Instance.selectedSlot = this;
    }



    public void OnEndDrag(PointerEventData data)
    {
        if (false == hasItem)
        {
            //�������� ���� ��� �巡�� �Ұ���
            return;
        }
        //�巡�װ� �������� ������ ���� ������: focused slot == this
        //�巡�װ� �������� �κ��丮 ������ �ƴҶ�: focused slot == null
        //��ȿ�� �巡��
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
        //anchoredPosition : ��Ŀ�κ��� ����� ��ġ
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
