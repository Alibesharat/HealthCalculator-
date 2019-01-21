using System;

namespace HealthCalculator
{
    public class Fitness
    {
        private const string messageHighRisk = " خطر سلامتی در حد بالا ";
        private const string messageMidiumRisk = " خطر سلامتی در حد متوسط ";
        private const string messageLowRisk = "خطر سلامتی در حد کم ";
        public Fitness()
        {

        }

        /// <summary>
        /// محاسبه شاخص توده بدنی
        /// </summary>
        /// <param name="height">قد به سانتی متر</param>
        /// <param name="Weight">وزن به  کیوگرم</param>
        /// <returns></returns>
       
        public (double, string) BMI(double height,double Weight)
        {
            if (height <= 0 || Weight <= 0)
            {
                return (-1, "پارامتر قد و وزن صحیح وارد نشده است");
            }
            else
            {
                height = height / 100;
                var result = Weight / (height * height);
                string message = "";
                if (result < 16.5)
                    message = "کمبود وزن شدید";
                else if (result >= 16.15 && result < 18.5)
                    message = "کمبود وزن";
                else if (result >= 18.5 && result < 25)
                    message = "عادی";
                else if (result >= 25 && result < 30)
                    message = "اضافه وزن ";
                else if (result >= 30 && result < 35)
                    message = "چاقی کلاس ۱ ";
                else if (result >= 35 && result < 40)
                    message = "چاقی کلاس 2 ";
                else if (result >= 40)
                    message = "چاقی کلاس 3";
                return (result, message);


            }
        }

        /// <summary>
        /// محاسبه کاری مورد نیاز
        /// </summary>
        /// <param name="height">قد به سانتی متر</param>
        /// <param name="Weight">وزن به کیلوگرم</param>
        /// <param name="age"> سن  </param>
        /// <param name="gender"> جنسیت  </param>
        /// <param name="activityStatuse">وضعیت فعالیت</param>
        /// <returns></returns>
        public double BMR(double height, double Weight, int age, bool gender, ActivityStatuse activityStatuse)
        {


            double BMiReuslt;
            double result;
            if (gender==false)
            {
                BMiReuslt = 655 + (9.6 * Weight) + (1.8 * height) - (4.7 * age);
            }
            else
            {
                BMiReuslt = 66 + (13.7 * Weight) + (5 * height) - (6.8 * age);
            }

            switch (activityStatuse)
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

        /// <summary>
        /// محاسبه وزن مناسب
        /// </summary>
        /// <param name="height">قد به سانتی متر</param>
        /// <param name="gender">وزن به کیلوگرم</param>
        /// <returns></returns>
        //public double IBW(double height,bool gender)
        //{
        //    if (height <= 0)
        //    {
        //        return -1;
        //    }
            

        //    var Inch_height = height / 2.54;
        //    double res;
        //    switch (gender)
        //    {
        //        case true:
        //            var baseHeight = 150;
        //            var baseWeight = 47.8;
        //            var yourHeghit =(int) height - baseHeight;
        //            var diff =(int) yourHeghit / 2.54;
                    
        //            var addedWeight = diff * 2.3;
                   
        //            res = baseWeight + addedWeight;
        //            break;
        //        case false:
        //            var baseHeight1 = 152.5 / 2.54;
        //            var diff1 = Inch_height - baseHeight1;
        //            var news = diff1 * 3;
        //            var baseWeight1 = 45.5;
        //            var addedWeight1 = news+baseWeight1;
        //            res = addedWeight1;
        //            break;
        //        default:
        //            throw new Exception("gender is not valid in range");
        //    }

        //    return res;
        //}


        /// <summary>
        /// محاسبه نسب کمر و لگن
        /// </summary>
        /// <param name="waist">دور کمر</param>
        /// <param name="Pelvis">دور لگن</param>
        /// <param name="gender">جنسیت</param>
        /// <returns></returns>
        public (double, string) WHR(double waist, double Pelvis, bool gender)
        {

            if (waist <= 0 || Pelvis <= 0)
            {
                return (-1, "پارامتر دور لگن و دور کمر صحیح وارد نشده است");
            }
            double result = waist / Pelvis;

            switch (gender)
            {
                case true:
                    return ManWHRCalc(result);
                case false:
                    return WomanWHRCalc(result);
                default:
                    throw new Exception("Gender is not in valid ");

            }
        }


        /// <summary>
        /// محاسبه نسبت کمر و لگن برای مردان
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private (double res, string messages) ManWHRCalc(double result)
        {
            if (result >= 0.95)
            {
                return (result, messageLowRisk);
            }
            else if (result > .09 && result < 1)
            {
                return (result, messageMidiumRisk);
            }
            return (result, messageHighRisk);
        }


        /// <summary>
        /// محاسبه نسبت کمر و لگن برای زن ها
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private (double res, string messages) WomanWHRCalc(double result)
        {
            if (result >= 0.8)
            {
                return (result, messageLowRisk);
            }
            else if (result >= 0.81 && result <= 0.85)
            {
                return (result, messageMidiumRisk);
            }
            return (result, messageHighRisk);
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
