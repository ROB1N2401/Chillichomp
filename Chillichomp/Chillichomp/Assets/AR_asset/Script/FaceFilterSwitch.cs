namespace GoogleARCore.Examples.AugmentedFaces
{
    using System.Collections;
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
        //Face filter gameobject
        public GameObject Filter;
        //face filter switch
        private bool Filter_switch=false;
        //Timer that detects the shake interval
        private float timer = 0;
        private float interval = 0;
        //head direction
        private Vector3 head_direction;
        //detects
        private bool head_move_right=false;
        private bool shake_heads=false;
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

            UpdateMesh();
        }

        /// <summary>
        /// Update mesh with a face mesh vertices, texture coordinates and indices.
        /// </summary>
        private void UpdateMesh()
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


            detection_shake_head();

            Filter.gameObject.SetActive(Filter_switch);
        }

        public bool DetermineMouth()
        {
            if(Filter_switch)
            {
                return false;
            }
            float a1 = m_MeshNormals[14].y - m_MeshNormals[13].y;

            //float a2 = m_MeshNormals[87].y - m_MeshNormals[82].y;
            //float a3 = m_MeshNormals[317].y - m_MeshNormals[312].y;
            if(a1<0.95)

            print("mouth_date"+a1);
            if(a1<0.97)

            {
                return true;
            }
            return false;
        }

        public void SetFaceFilterState(bool a)
        {
            Filter_switch = a;
        }
        public void detection_shake_head()
        {
            head_direction = m_AugmentedFace.CenterPose.rotation.eulerAngles;
            //print("head_direction " + head_direction);
            timer += Time.deltaTime;
            if(head_direction.y>25 && head_direction.y<60)
            {
                print("shake_heads" + shake_heads);
                head_move_right = true;
                interval = timer;
            }
            else if(head_move_right && (timer - interval) < 0.5f)
            {
                if (head_direction.y<338 && head_direction.y>300)
                {
                    shake_heads = true;
                    head_move_right = false;
                    StartCoroutine(initialization());
                }
            }
        }
        IEnumerator initialization()
        {
            yield return new WaitForSeconds(0.5f);
            shake_heads = false;
        }
        public bool determine_shake_heads()
        {
            return shake_heads;
        }
    }
}
