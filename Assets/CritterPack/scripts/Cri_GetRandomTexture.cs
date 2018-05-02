using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cri_GetRandomTexture : MonoBehaviour {

	public Texture2D[] textures;
	public GameObject targetGameObject;
	private Renderer myRenderer;


	// Use this for initialization
	void Start () {
		if (!targetGameObject)
			targetGameObject = gameObject;   //if target is not set, then self is the target

		myRenderer=targetGameObject.GetComponent<Renderer>();

		myRenderer.material.mainTexture = textures [Random.Range (0, textures.Length)];


	}
	

}
