using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCalculator
{
    public class BMR
    {

        private ActivityStatuse _activityStatuse;
        private BMI _bmi;


        public BMR(BMI bmi, ActivityStatuse activityStatuse)
        {
            _bmi = bmi;
            _activityStatuse = activityStatuse;
          

        }

        /// <summary>
        /// محاسبه کالری مورد نیاز
        /// </summary>
        /// <returns></returns>
        public double Calc()
        {
            double BMiReuslt = _bmi.Calc().Item1;
            if (BMiReuslt == -1)
            {
                return -1;
            }
            double result;
            switch (_activityStatuse)
            {
                case ActivityStatuse.Hyperactive:
                    result = BMiReuslt * 1.9;
                    break;
                case ActivityStatuse.active:
                    result = BMiReuslt * 1.725;
                    break;
                case ActivityStatuse.normal:
                    result = BMiReuslt * 1.55;
                    break;
                case ActivityStatuse.low:
                    result = BMiReuslt * 1.375;
                    break;
                case ActivityStatuse.none:
                    result = BMiReuslt * 1.2;
                    break;
                default:
                    throw new Exception("activityStatuse  Is Not in Valid Range");

            }
            return result;
        }


    }

    /// <summary>
    /// وضعیت فعالیت
    /// </summary>
    public enum ActivityStatuse
    {
        /// <summary>
        /// فعالیت   شدید
        /// </summary>
        Hyperactive,
        /// <summary>
        /// فعالیت زیاد 
        /// </summary>
        active,
        /// <summary>
        /// فعالیت عادی
        /// </summary>
        normal,
        /// <summary>
        /// فعالیت پایین
        /// </summary>
        low,
        /// <summary>
        /// بدون فعالیت
        /// </summary>
        none

    }
}
