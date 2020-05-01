namespace GoogleARCore.Examples.AugmentedFaces
{
    using System.Collections.Generic;
    using GoogleARCore;
    using UnityEngine;

    /// <summary>
    /// Helper component to update face mesh data.
    /// </summary>
    [RequireComponent(typeof(MeshFilter))]
    public class FaceFilterSwitch : MonoBehaviour
    {
        /// <summary>
        /// If true, this component will update itself using the first AugmentedFace detected by ARCore.
        /// </summary>
        public bool AutoBind = false;
        private AugmentedFace m_AugmentedFace = null;
        private List<AugmentedFace> m_AugmentedFaceList = null;

        // Keep previous frame's mesh polygon to avoid mesh update every frame.
        private List<Vector3> m_MeshVertices = new List<Vector3>();
        private List<Vector3> m_MeshNormals = new List<Vector3>();
        private List<Vector2> m_MeshUVs = new List<Vector2>();
        private List<int> m_MeshIndices = new List<int>();
        private Mesh m_Mesh = null;
        private bool m_MeshInitialized = false;

        private bool Filter_switch=false;
        /// <summary>
        /// Gets or sets the ARCore AugmentedFace object that will be used to update the face mesh data.
        /// </summary>
        public AugmentedFace AumgnetedFace
        {
            get
            {
                return m_AugmentedFace;
            }

            set
            {
                m_AugmentedFace = value;
                Update();
            }
        }

        /// <summary>
        /// The Unity Awake() method.
        /// </summary>
        public void Awake()
        {
            m_Mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = m_Mesh;
            m_AugmentedFaceList = new List<AugmentedFace>();
        }

        /// <summary>
        /// The Unity Update() method.
        /// </summary>
        public void Update()
        {
            {
                if (AutoBind)
                {
                    m_AugmentedFaceList.Clear();
                    Session.GetTrackables<AugmentedFace>(m_AugmentedFaceList, TrackableQueryFilter.All);
                    if (m_AugmentedFaceList.Count != 0)
                    {
                        m_AugmentedFace = m_AugmentedFaceList[0];
                    }
                }

                if (m_AugmentedFace == null)
                {
                    return;
                }
            }

            // Update game object position;
            transform.position = m_AugmentedFace.CenterPose.position;
            transform.rotation = m_AugmentedFace.CenterPose.rotation;

            _UpdateMesh();
        }

        /// <summary>
        /// Update mesh with a face mesh vertices, texture coordinates and indices.
        /// </summary>
        private void _UpdateMesh()
        {
            m_AugmentedFace.GetVertices(m_MeshVertices);
            m_AugmentedFace.GetNormals(m_MeshNormals);

            if (!m_MeshInitialized)
            {
                m_AugmentedFace.GetTextureCoordinates(m_MeshUVs);
                m_AugmentedFace.GetTriangleIndices(m_MeshIndices);

                // Only update mesh indices and uvs once as they don't change every frame.
                m_MeshInitialized = true;
            }

            GameObject.Find("FaceTexture").SetActive(Filter_switch);
            //if (a1 < 1)
            //{
            //    open = true;
            //    Mask.gameObject.SetActive(true);
            //}
            //else
            //{
            //    open = false;
            //    Filter.GetComponent<UIPosition>().timer = -6;
            //    //print(Mask.GetComponent<UIPosition>().timer);
            //    Mask.gameObject.SetActive(false);
            //}
        }

        public bool determine_mouth()
        {
            float a1 = m_MeshNormals[14].y - m_MeshNormals[13].y;
            float a2 = m_MeshNormals[87].y - m_MeshNormals[82].y;
            float a3 = m_MeshNormals[317].y - m_MeshNormals[312].y;
            //if(a1<0.86 && a2<0.86)
            //{
            //    if(a3<0.86)
            //    {
            //        print("02538");
            //        return true;
            //    }
            //}
            if(a1<0.95)
            {
                print("02538");
                return true;
            }
            return false;
        }

        public void Open_face_filter()
        {
            Filter_switch = true;
        }

    }
}
