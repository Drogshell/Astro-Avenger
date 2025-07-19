using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] private Vector2 moveSpeed;

    private Vector2 _offSet;
    private Material _material;

    private void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        _offSet = moveSpeed * Time.deltaTime;
        _material.mainTextureOffset += _offSet;
    }
}
