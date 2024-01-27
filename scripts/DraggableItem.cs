using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableItem : MonoBehaviour
{
    private Vector3 startPosition;
    private Camera mainCamera;
    private bool isDragging = false;
    private bool isOverDropZone = false;
    private GameObject dropZone;

    void Start()
    {
        mainCamera = Camera.main;
        startPosition = transform.position;
        dropZone = GameObject.FindWithTag("DropZone");

        if (dropZone == null)
        {
            Debug.LogError("DropZone not found!");
        }
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, startPosition.z);
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;

        if (isOverDropZone)
        {
            GetComponent<Collider2D>().enabled = false; // 使物体不可交互
            this.enabled = false; 
            CreateNewDraggableItem();
        }
        else
        {
            transform.position = startPosition; // 返回原位
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == dropZone)
        {
            isOverDropZone = true;
            Debug.Log("Entered DropZone");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == dropZone)
        {
            isOverDropZone = false;
            Debug.Log("Exited DropZone");
        }
    }

    private void CreateNewDraggableItem()
    {
        GameObject newItem = Instantiate(gameObject, startPosition, Quaternion.identity);
        newItem.GetComponent<Collider2D>().enabled = true; // 确保新物体的Collider是启用的
        newItem.GetComponent<DraggableItem>().enabled = true; // 确保新物体的DraggableItem脚本是启用的
    }
}
