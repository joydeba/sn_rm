using System;
using System.Collections.Generic;
using System.Text;

namespace ResultManagement.DAObjects
{
    public class Marks
    {
        #region Private Members

        private int? marksID;
        private bool isRetake = false;
        private int attendence = 0;
        private int ct_or_viva = 0;
        private int sa_or_secA = 0;
        private int secB = 0;
        private int total;

        public int Total
        {
            get { return attendence + ct_or_viva + sa_or_secA + secB; }
        }

        #endregion

        #region Properties

        public int? MarksID
        {
            get { return marksID; }
            set { marksID = value; }
        }
        
        public bool? IsRetake
        {
            get { return isRetake; }
            set {
                if (value == null)
                    isRetake = false;
                else
                    isRetake = (bool)value;
            }
        }
        
        public int? Attendence
        {
            get { return attendence; }
            set {
                if (value == null)
                    attendence = 0;
                else
                    attendence = (int)value;
            }
        }
       
        public int? Ct_or_Viva
        {
            get { return ct_or_viva; }
            set
            {
                if (value == null)
                    ct_or_viva = 0;
                else
                    ct_or_viva = (int)value;
            }
        }
        
        public int? SA_or_SecA
        {
            get { return sa_or_secA; }
            set {
                if (value == null)
                    sa_or_secA = 0;
                else
                    sa_or_secA = (int)value;
            }
        }
        
        public int? SecB
        {
            get { return secB; }
            set {
                if (value == null)
                    secB = 0;
                else
                    secB = (int)value;
            }
        }

        #endregion

    }
}
