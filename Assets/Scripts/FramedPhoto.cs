using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramedPhoto : MonoBehaviour
{
    [SerializeField] Transform scalerObject;
    [SerializeField] GameObject imageObject;
    [SerializeField] GameObject highlightObject;
    [SerializeField] Collider boundingCollider;
    MovePicture movePicture;
    ResizePicture resizePicture;
    int layer;
    bool isEditing;
    ImageInfo imageInfo;

    public void SetImage(ImageInfo image)
    {
        imageInfo = image;
        Renderer renderer = imageObject.GetComponent<Renderer>();
        Material material = renderer.material;
        material.SetTexture("_MainTex", imageInfo.texture);
        AdjustScale();

    }
    public void AdjustScale()
    {
        Vector2 scale = ImagesData.AspectRatio(imageInfo.width, imageInfo.height);
        scalerObject.localScale = new Vector3(scale.x, scale.y, 1f);
    }
    public void Highlight(bool show)
    {
        if (highlightObject)
            highlightObject.SetActive(show);
    }
    private void Awake()
    {
        movePicture = GetComponent<MovePicture>();
        resizePicture = GetComponent<ResizePicture>();
        movePicture.enabled = false;
        resizePicture.enabled = false;
        layer = LayerMask.NameToLayer("PlacedObjects");
        Highlight(false);
    }
    public void BeingEdited(bool editing)
    {
        Highlight(editing);
        movePicture.enabled = true;
        resizePicture.enabled = true;
        isEditing = editing;
    }
    void OnTriggerStay(Collider other)
    {
        const float spacing = 0.1f;
        if (isEditing && other.gameObject.layer == layer)
        {
            Bounds bounds = boundingCollider.bounds;
            if (other.bounds.Intersects(bounds))
            {
                Vector3 centerDistance = bounds.center - other.bounds.center;
                Vector3 distOnPlane = Vector3.ProjectOnPlane(centerDistance, transform.forward);
                Vector3 direction = distOnPlane.normalized;
                float distanceToMoveThisFrame = bounds.size.x * spacing;
                transform.Translate(direction * distanceToMoveThisFrame);
            }
        }
    }
}

