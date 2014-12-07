﻿using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{

	private Transform transformCache;
	private Transform childTransformCache;
	private SpriteRenderer spriteRenderer;

	public void Explode()
	{
		Explosion.Explode(transformCache.position, 1.0f, 0.5f);
		TimeScale.Set(0.75f, 0.05f);
		this.Recycle();
	}

	public void Back()
	{
		spriteRenderer.sortingLayerName = "WallBack";
	}
	public void Front()
	{
		spriteRenderer.sortingLayerName = "Wall";
	}

	public void Spawn()
	{
		LeanTween.scaleY(childTransformCache.gameObject, 1.0f, 1.0f)
			.setEase(LeanTweenType.easeOutSine);
	}

	void Awake()
	{
		transformCache = transform;
	}

	void OnEnable()
	{
		childTransformCache = transformCache.FindChild("Wall");
		spriteRenderer = childTransformCache.GetComponent<SpriteRenderer>();

		childTransformCache.localScale = new Vector3(1.0f, 0, 1.0f);
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
