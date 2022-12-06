using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutLinePicks : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private float outlineScaleFactor;
    [SerializeField] private Color outlineColor;
    private Renderer outlineRenderer;

    void Start()
    {
        outlineRenderer = CreateOutline(outlineMaterial, outlineScaleFactor, outlineColor);
    }

    Renderer CreateOutline(Material outlineMat, float scaleFactor, Color color)
    {
        //Variable con el transform del objeto original
        Transform transform1 = this.transform;
        Quaternion originalRotation = transform1.rotation;

        //Crear objeto vacío que será el borde
        GameObject outlineObject = new GameObject(this.name + "_outline");
        //Asignarle la posición, rotación y escala del objeto original
        outlineObject.transform.position = transform1.position;
        outlineObject.transform.rotation = transform1.rotation;
        outlineObject.transform.localScale = transform1.localScale;
        //Asignarle como padre el objeto  original
        outlineObject.transform.SetParent(transform1);
        //Agregarle un componente MeshFilter y asignarle el mesh del objeto original
        MeshFilter myMeshFilter = outlineObject.AddComponent<MeshFilter>();
        myMeshFilter.mesh = GetComponent<MeshFilter>().mesh;
        Renderer rend = outlineObject.AddComponent<MeshRenderer>();

        MeshRenderer originalMesh = GetComponent<MeshRenderer>();

        //cambiar la rotación a la identidad para poder aplicar las correcciones
        transform.rotation = Quaternion.identity;

        //buscar el eje que representa la menor extensión
        float extentX = originalMesh.bounds.extents.x;
        float extentY = originalMesh.bounds.extents.y;
        float extentZ = originalMesh.bounds.extents.z;
        float minimo = Mathf.Min(extentX, extentY, extentZ);
        //calcular el ancho del borde
        float borderWidth = (minimo * scaleFactor) - minimo;

        //calcular el factor de escala por cada eje
        float scaleFactorX = (borderWidth / extentX) + 1;
        float scaleFactorY = (borderWidth / extentY) + 1;
        float scaleFactorZ = (borderWidth / extentZ) + 1;

        //calcular la corrección por cada eje
        float correccionX = scaleFactor - scaleFactorX;
        float correccionY = scaleFactor - scaleFactorY;
        float correccionZ = scaleFactor - scaleFactorZ;

        //disminuir la escala de acuerdo a la corrección
        outlineObject.transform.localScale -= new Vector3(correccionX, correccionY, correccionZ) / scaleFactor;

        //cambiar a la rotación original
        transform.rotation = originalRotation;

        rend.material = outlineMat;
        rend.material.SetColor("_OutlineColor", color);
        rend.material.SetFloat("_ScaleFactor", scaleFactor);
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        rend.enabled = false;

        return rend;
    }

    private void OnMouseEnter()
    {
        ActivateBorder();
    }

    private void OnMouseExit()
    {
        DeactivateBorder();
    }

    public void ActivateBorder()
    {
        outlineRenderer.enabled = true;
    }

    public void DeactivateBorder()
    {
        outlineRenderer.enabled = false;
    }
}
