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
        private bool _filterSwitch = false;
        //Timer that detects the shake interval
        private float _timer = 0;
        private float _interval = 0;
        //head direction
        private Vector3 _headDirection;
        //detects
        private bool _headMoveRight = false;
        private bool _shakeHeads = false;
        //head position
        public Pose HeadPose;
        /// <summary>
        /// Gets or sets the ARCore AugmentedFace object that will be used to update the face mesh data.
        /// </summary>
        public AugmentedFace AugmentedFace
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
            HeadPose = m_AugmentedFace.CenterPose;
            DetectHeadShaking();
            Filter.gameObject.SetActive(_filterSwitch);
        }

        public bool DetermineMouth()
        {
            if (GameObject.Find("GameObjectControl").GetComponent<ThermometerControl>().CheckHitRoof())
            {
                return false;
            }
            float a1 = m_MeshNormals[14].y - m_MeshNormals[13].y;
            //float a2 = m_MeshNormals[87].y - m_MeshNormals[82].y;
            //float a3 = m_MeshNormals[317].y - m_MeshNormals[312].y;
            if (a1 < 0.95)
            {
                return true;
            }
            return false;
        }

        public void SetFaceFilterState(bool a)
        {
            _filterSwitch = a;
        }

        public void DetectHeadShaking()
        {
            _headDirection = m_AugmentedFace.CenterPose.rotation.eulerAngles;
            //print("head_direction " + _headDirection);
            _timer += Time.deltaTime;
            _shakeHeads = false;
            if (_headDirection.y > 25 && _headDirection.y < 60)
            {
                _headMoveRight = true;
                _interval = _timer;
            }
            else if (_headMoveRight && (_timer - _interval) < 0.5f)
            {
                if (_headDirection.y < 345 && _headDirection.y > 300)
                {
                    _shakeHeads = true;
                    _headMoveRight = false;
                    //StartCoroutine(initialization());
                }
            }
        }

        //IEnumerator Initialization()
        //{
        //    yield return new WaitForSeconds(0.5f);
        //    shake_heads = false;
        //}
        public bool DetermineShakeHeads()
        {
            return _shakeHeads;
        }
    }
}
