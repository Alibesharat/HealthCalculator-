using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCalculator
{
   public class WHR
    {
        private double _Pelvis { get; set; }
        private double _Waist { get; set; }
        private bool _gender { get; set; }

        private const string messageHighRisk = "شما در معرض خطر سلامتی در حد بالا هستید";
        private const string messageMidiumRisk = "شمار در معرض خطر سلامتی در حد متوسط هستید";
        private const string messageLowRisk = "شما در معرض سلامتی در حد کم هستید";
       


        public WHR(double waist,double Pelvis,bool gender)
        {
            _Waist = waist;
            _Pelvis = Pelvis;
            _gender = gender;
        }


        public (double,string) Calc()
        {
            if(_Waist<=0 || _Pelvis <= 0)
            {
                return (-1,"پارامتر دور لگن و دور کمر صحیح وارد نشده است");
            }
            double result = _Waist / _Pelvis;
           
            switch (_gender)
            {
                case true:
                   return manCalc(result);
                case false:
                    return WomanCalc(result);
                default:
                    throw new Exception("Gender is not in valid ");
                   
            }
           
        }

        private (double res, string messages) manCalc(double result)
        {
            if (result >= 0.95)
            {
                return (result, messageLowRisk);
            }else if(result>.09 && result < 1)
            {
                return (result, messageMidiumRisk);
            }
            return (result, messageHighRisk);
        }

        private (double res, string messages) WomanCalc(double result)
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
}
