namespace OpenCvSharp.Demo
{
    using UnityEngine;
    using OpenCvSharp;
    using UnityEngine.UI;
    using Rect = UnityEngine.Rect;
    using System;
    using System.Linq;

    public class Transparent_BG : MonoBehaviour
    {
        public Image preview_Image;
        public Texture2D m_texture;
        public RawImage m_image_origin;
        public RawImage m_image_gray;
        public RawImage m_Image_binarization;
        public RawImage m_image_mask;
        public RawImage m_image_backgroundTransparent;

        public double v_thresh = 180;
        public double v_maxval = 255;

        bool done_Remove = false;

        public SpriteRenderer spp;
        public Image img;
        int i = 0;

        private void Update()
        {


            if (preview_Image.sprite == null) { }
            else if (preview_Image.sprite != null && !done_Remove &&  i == 0)
            {
                i = 3;
                m_texture = preview_Image.mainTexture as Texture2D;

                duplicateTexture(m_texture);

                remove_Background();

                done_Remove = true;
            }




        }



        Texture2D duplicateTexture(Texture2D source)
        {
            byte[] pix = source.GetRawTextureData();
            Texture2D readableText = new Texture2D(source.width, source.height, source.format, false);
            readableText.LoadRawTextureData(pix);
            readableText.Apply();
            return readableText;
        }

        private void remove_Background()
        {
            #region load texture
            Mat origin = Unity.TextureToMat(this.m_texture);
            m_image_origin.texture = Unity.MatToTexture(origin);
            #endregion

            #region  Gray scale image
            Mat grayMat = new Mat();
            Cv2.CvtColor(origin, grayMat, ColorConversionCodes.BGR2GRAY);
            m_image_gray.texture = Unity.MatToTexture(grayMat);
            #endregion

            #region Find Edge
            Mat thresh = new Mat();
            Cv2.Threshold(grayMat, thresh, v_thresh, v_maxval, ThresholdTypes.BinaryInv);

            m_Image_binarization.texture = Unity.MatToTexture(thresh);
            #endregion

            #region Create Mask
            Mat Mask = Unity.TextureToMat(Unity.MatToTexture(grayMat));
            Point[][] contours; HierarchyIndex[] hierarchy;
            Cv2.FindContours(thresh, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxNone, null);

            for (int i = 0; i < contours.Length; i++)
            {
                Cv2.DrawContours(Mask, new Point[][] { contours[i] }, 0, new Scalar(0, 0, 0), -1);
            }
            Mask = Mask.CvtColor(ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(Mask, Mask, v_thresh, v_maxval, ThresholdTypes.Binary);
            m_image_mask.texture = Unity.MatToTexture(Mask);
            #endregion

            #region TransparentBackground
            Mat transparent = origin.CvtColor(ColorConversionCodes.BGR2BGRA);
            unsafe
            {
                byte* b_transparent = transparent.DataPointer;
                byte* b_mask = Mask.DataPointer;
                float pixelCount = transparent.Height * transparent.Width;

                for (int i = 0; i < pixelCount; i++)
                {
                    if (b_mask[0] == 255)
                    {
                        b_transparent[0] = 0;
                        b_transparent[1] = 0;
                        b_transparent[2] = 0;
                        b_transparent[3] = 0;
                    }
                    b_transparent = b_transparent + 4;
                    b_mask = b_mask + 1;
                }
            }
            m_image_backgroundTransparent.texture = Unity.MatToTexture(transparent);
            #endregion


            Sprite abc = Sprite.Create(m_image_backgroundTransparent.texture as Texture2D, new Rect(0, 0, m_image_backgroundTransparent.texture.width, m_image_backgroundTransparent.texture.height), new Vector2(0.5f, 0.5f), 100.0f);

            spp.GetComponent<SpriteRenderer>().sprite = abc;
            PolygonCollider2D poly = spp.gameObject.GetComponent<PolygonCollider2D>();
            Destroy(poly.GetComponent<PolygonCollider2D>());
            poly.gameObject.AddComponent<PolygonCollider2D>();

            img.sprite = spp.sprite;
            img.useSpriteMesh = true;

        }



    }


}

