
namespace VRTK.Examples
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography;
    using UnityEngine;

    public class Draw : MonoBehaviour
    {
        private LineRenderer lineRenderer;
        private int positionCount = 0;
        bool isDrawing = false;
        public VRTK_InteractableObject linkedObject;

        protected virtual void OnEnable()
        {
            linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

            if (linkedObject != null)
            {
                linkedObject.InteractableObjectUsed += InteractableObjectUsed;
            }
        }

        protected virtual void OnDisable()
        {
            if (linkedObject != null)
            {
                linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
            }
        }

        protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false;

            }
            else
            {
                isDrawing = true;
                lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
                lineRenderer.startColor = Color.white;
                lineRenderer.endColor = Color.white;
                lineRenderer.startWidth = 0.01f;
                lineRenderer.endWidth = 0.01f;
                lineRenderer.positionCount = 2;
                lineRenderer.useWorldSpace = true;
                lineRenderer.SetPosition(0, gameObject.transform.position); //x,y and z position of the starting point of the line
                lineRenderer.SetPosition(1, gameObject.transform.position);
            }
        }
        void Update()
        {
            if (isDrawing)
            {
                lineRenderer.SetPosition(lineRenderer.positionCount++, gameObject.transform.position);
            }
        }
    }

}
