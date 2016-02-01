using System;
using System.Collections.Generic;
using System.Text;

namespace ResultManagement.DAObjects
{
    public class StudentSearchCriteria
    {
        #region Private Fields
        private int? studentId;

        private string batch;
        
        private string rollLike;
        private string rollExact;
        private string name;
        
        #endregion
        //****************************************************

        #region Properties
        /// <summary>
        /// Equal
        /// </summary>
        public int? StudentId
        {
            get { return this.studentId; }
            set { this.studentId = value; }
        }

        /// <summary>
        /// Equal
        /// </summary>
        public string Batch
        {
            get { return this.batch; }
            set
            {
                if (value == "")
                {
                    this.batch = null;
                }
                else
                {
                    this.batch = value;
                }
            }
        }

        
        /// <summary>
        /// Like '%%'
        /// </summary>
        public string RollLike
        {
            get
            {
                return this.rollLike;
            }

            set
            {
                if (value == "")
                {
                    this.rollLike = null;
                }
                else
                {
                    this.rollLike = value;
                }
            }
        }

        /// <summary>
        /// Equal
        /// </summary>
        public string RollExact
        {
            get
            {
                return this.rollExact;
            }

            set
            {
                if (value == "")
                {
                    this.rollExact = null;
                }
                else
                {
                    this.rollExact = value;
                }
            }
        }

        /// <summary>
        /// Like '%%'
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == "")
                {
                    this.name = null;
                }
                else
                {
                    this.name = value;
                }
            }
        }

        #endregion

    }
}
