using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TEXImportPreProcess : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        string lowTexPath = assetPath.ToLower();
        bool foundtexture = lowTexPath.IndexOf("/textures/") != -1;

        if (foundtexture)
        {
            bool foundBase      = lowTexPath.IndexOf("_albedo.") != -1;
            bool foundMask      = lowTexPath.IndexOf("_mask.") != -1;
            bool foundNormal    = lowTexPath.IndexOf("_normal.") != -1;
            bool foundEmissive  = lowTexPath.IndexOf("_emissive.") != -1;
            bool foundThickness = lowTexPath.IndexOf("_thickness.") != -1;

            // Common
            TextureImporter textureImporter = assetImporter as TextureImporter;
            textureImporter.maxTextureSize = 4096;

            // Normal Maps
            if (foundNormal)
            {
                textureImporter.textureType = TextureImporterType.NormalMap;
            }
            // Greyscale Maps
            if (foundMask)
            {
                textureImporter.sRGBTexture = false;
            }
            if (foundThickness)
            {
                textureImporter.sRGBTexture = false;
            }
        }
    }
}
